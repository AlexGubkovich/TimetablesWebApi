using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.DTOs.CallScheduleDTO;
using Timetables.Core.IRepository;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;


namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IScheduleRepository repository;
        private readonly ILogger<SchedulesController> logger;

        public SchedulesController(
            IScheduleRepository repository,
            IMapper mapper,
            ILogger<SchedulesController> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet(Name = "All")]
        public async Task<ActionResult<List<Schedule>>> GetSchedules()
        {
            var schedules = await repository.GetAllAsync();

            if (schedules == null)
            {
                return NoContent();
            }

            return Ok(schedules);
        }

        [HttpGet("active/lessons")]
        public async Task<ActionResult<ScheduleDTO>> GetActiveScheduleLessons()
        {
            var schedule = await repository.GetActiveAsync();

            if (schedule == null)
            {
                return NoContent();
            }

            return Ok(mapper.Map<ScheduleDTO>(schedule));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(int id)
        {
            var schedule = await repository.GetById(id);

            if (schedule == null)
            {
                return NoContent();
            }

            return Ok(schedule);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSchedule(CreateScheduleDTO createDTO)
        {
            var schedule = mapper.Map<Schedule>(createDTO);
            var result = await repository.CreateAsync(schedule);

            if (!result.Success)
            {
                logger.LogError(result.Error);
                return BadRequest();
            }

            return CreatedAtAction("GetScheduleById", new { id = schedule.Id }, schedule);
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
        public async Task<ActionResult> SetIsActiveSchedule(PatchScheduleDTO patchSchedule)
        {
            var result = await repository.SetIsActiveAsync(patchSchedule);

            if (!result.Success)
            {
                logger.LogTrace(result.Error);
                return NotFound();
            }          

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSchedule(int id)
        {
            var result = await repository.DeleteAsync(id);
            if (!result.Success)
            {
                logger.LogInformation(result.Error);
                return NotFound();
            }

            return Ok();
        }
    }
}
