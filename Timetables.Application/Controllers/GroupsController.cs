using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.DTOs.GroupDTO;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;

        public GroupsController(IUnitOfWork repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var groups = await repository.Group.GetAllGroups();

            if (groups.Count() < 0)
            {
                return NoContent();
            }

            return Ok(groups);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Group>> GetGroupById(int id)
        {
            var group = await repository.Group.GetGroupById(id);

            if (group == null)
            {
                return NoContent();
            }

            return Ok(group);;
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(CreateGroupDTO createGroup)
        {
            var group = mapper.Map<Group>(createGroup);
            await repository.Group.CreateGroup(group);
            await repository.SaveAsync();

            return CreatedAtAction("GetGroupById", new { id = group.Id }, group);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGroup(Group updateGroup)
        {
            repository.Group.UpdateGroup(updateGroup);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            await repository.Group.DeleteGroup(id);
            await repository.SaveAsync();

            return Ok();
        }
    }
}
