using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Timetables.Core.DTOs.GroupDTOs;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class GroupsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;
        private readonly Serilog.ILogger logger;

        public GroupsController(IUnitOfWork repository, IMapper mapper, Serilog.ILogger logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetGroups()
        {
            var groups = await repository.Group.GetAllGroups(trackChanges: false);

            if (groups.Count() < 0)
            {
                return NoContent();
            }

            var groupsDTO = mapper.Map<IEnumerable<GroupDTO>>(groups);

            return Ok(groupsDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetGroupById(int id)
        {
            var group = await repository.Group.GetGroupById(id, false);

            if (group == null)
            {
                return NotFound();
            }

            var groupDTO = mapper.Map<GroupDTO>(group);
            return Ok(groupDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(CreateGroupDTO createGroup)
        {
            var groupEntity = mapper.Map<Group>(createGroup);
            await repository.Group.CreateGroup(groupEntity);
            await repository.SaveAsync();

            var groupToReturn = mapper.Map<GroupDTO>(groupEntity);

            return CreatedAtAction("GetGroupById", new { id = groupEntity.Id }, groupToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateGroup(int id, UpdateGroupDTO updateGroup)
        {
            var groupEntity = await repository.Group.GetGroupById(id, true);
            if (groupEntity == null)
            {
                logger.Information($"Group with id: {id} doesn't exist in the database");
                return NotFound();
            }

            mapper.Map(updateGroup, groupEntity);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            var group = await repository.Group.GetGroupById(id, false);
            if (group == null)
            {
                logger.Information($"Group with id: {id} doesn't exist in the database");
                return NotFound();
            }

            repository.Group.DeleteGroup(group);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
