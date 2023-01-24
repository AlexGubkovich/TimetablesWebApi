using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TimetablesProject.Data;
using TimetablesProject.IRepository;
using TimetablesProject.Models.DTO.ScheduleDTO;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IScheduleRepository repository;
        private readonly ILogger logger;

        public SchedulesController( 
            IScheduleRepository repository,
            IMapper mapper,
            ILogger logger = null)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ScheduleDTO>> GetActiveSchedule()
        {
            var schedule = await repository.GetActiveAsync();

            if (schedule == null)
            {
                return NoContent();
            }

            ScheduleDTO scheduleDTO = mapper.Map<ScheduleDTO>(schedule);

            return Ok(scheduleDTO);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Schedule>>> GetSchedules()
        {
            var schedules = await repository.GetAllAsync();

            if (schedules == null)
            {
                return NoContent();
            }

            return Ok(schedules);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSchedule(CreateScheduleDTO createDTO)
        {
            var Schedule = mapper.Map<Schedule>(createDTO);
            var result = await repository.CreateAsync(Schedule);

            if (!result.Success)
            {
                logger.LogError(result.Error);
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSchedule(UpdateScheduleDTO updateSchedule)
        {
            var result = await repository.UpdateAsync(mapper.Map<Schedule>(updateSchedule));

            if (!result.Success)
            {
                logger.LogWarning(result.Error);
                return BadRequest();
            }

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> SetIsActiveSchedule(int id, bool isActive)
        {
            var result = await repository.SetIsActiveAsync(id, isActive);

            if (!result.Success)
            {
                logger.LogTrace(result.Error);
                return NotFound();
            }          

            return Ok();
        }

        [HttpDelete()]
        public async Task<ActionResult> DeleteSchedule(int id)
        {
            var result = await repository.DeleteAsync(id);
            if (!result.Success)
            {
                logger.LogTrace(result.Error);
                return NotFound();
            }

            return Ok();
        }
    }
}
