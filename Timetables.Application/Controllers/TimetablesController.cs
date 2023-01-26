using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timetables.Core.DTOs.TimetableDTOs;
using Timetables.Data;
using Timetables.Data.Models;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimetablesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly TimetableDbContext context;

        public TimetablesController(TimetableDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("byGroup/{groupId:int}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<Timetable>> GetTimetablesForGroup(int groupId)
        {
            var ff = RouteData.Values.Values.FirstOrDefault();
            var timetables = await context.Timetables.Where(t => t.GroupId == groupId)
                .Include(p => p.Classes)
                .Include(p => p.Subjects).ThenInclude(p => p.Teacher)
                .AsSplitQuery()
                .ToListAsync();

            if (timetables.Count > 0)
            {
                IEnumerable<TimetableDTO> timetablesDTO = mapper.Map<IEnumerable<TimetableDTO>>(timetables);

                return Ok(timetablesDTO);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTimetable(UpdateTimetabeDTO updateTimetabe)
        {
            return Ok();
        }
    }
}
