using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timetables.Core.DTOs.TimetableDTOs;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetablesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;

        public TimetablesController(IUnitOfWork repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet("byGroup/{groupId:int}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<Timetable>> GetTimetablesByGroupId(int groupId)
        {
            var timetables = await repository.Timetable.GetTimetablesByGroupId(groupId);

            if (timetables.Any())
            {
                IEnumerable<TimetableDTO> timetablesDTO = mapper.Map<IEnumerable<TimetableDTO>>(timetables);

                return Ok(timetablesDTO);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timetable>>> GetTimetables()
        {
            var timetables = await repository.Timetable.GetAllTimetables();

            if (timetables.Count() < 0)
            {
                return NoContent();
            }

            return Ok(timetables);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Timetable>> GetTimetableById(int id)
        {
            var timetable = await repository.Timetable.GetTimetableById(id);

            if (timetable == null)
            {
                return NoContent();
            }

            return Ok(timetable);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(CreateTimetableDTO createTimetable)
        {
            var timetable = mapper.Map<Timetable>(createTimetable);
            await repository.Timetable.CreateTimetable(timetable);
            await repository.SaveAsync();

            return CreatedAtAction("GetTimetableById", new { id = timetable.Id }, timetable);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTimetable(Timetable updateTimetable)
        {
            repository.Timetable.UpdateTimetable(updateTimetable);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTimetable(int id)
        {
            await repository.Timetable.DeleteTimetable(id);
            await repository.SaveAsync();

            return Ok();
        }
    }
}
