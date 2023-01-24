using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimetablesProject.Data;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        //private readonly IMapper mapper;
        private readonly TimetableDbContext context;

        public GroupsController(TimetableDbContext context, IMapper mapper)
        {
            //this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var groups = await context.Groups.ToListAsync();

            if (groups.Count > 0)
            {
                return Ok(groups);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Group>>> CreateGroup()
        {
            var groups = await context.Groups.ToListAsync();

            if (groups.Count > 0)
            {
                return Ok(groups);
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Group>>> UpdateGroup()
        {
            var groups = await context.Groups.ToListAsync();

            if (groups.Count > 0)
            {
                return Ok(groups);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Group>>> DeleteGroup()
        {
            var groups = await context.Groups.ToListAsync();

            if (groups.Count > 0)
            {
                return Ok(groups);
            }

            return NoContent();
        }
    }
}
