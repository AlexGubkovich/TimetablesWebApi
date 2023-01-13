using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TimetablesProject.Data;
using TimetablesProject.Models;
using TimetablesProject.Models.DTO;

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

        [HttpGet("{groupId:int}")]
        public async Task<ActionResult<Timetable>> GetTimetablesForGroup(int groupId)
        {
            var ff = RouteData.Values.Values.FirstOrDefault();
            var timetables = await context.Timetables.Where(t => t.GroupId == groupId)
                .Include(p => p.Classes)
                .Include(p => p.Subjects).ThenInclude(p => p.Teacher)
                .ToListAsync();

            if(timetables.Count > 0)
            {
                var timetablesDTO = mapper.Map<IEnumerable<Timetable>, IEnumerable<TimetableDTO>>(timetables);
         
                return Ok(timetablesDTO);
            }

            return NotFound();
        }
    }
}
