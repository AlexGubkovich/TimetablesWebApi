﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
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
        private readonly Serilog.ILogger logger;

        public TimetablesController(IUnitOfWork repository, IMapper mapper, Serilog.ILogger logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet("byGroup/{groupId:int}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult> GetTimetablesByGroupId(int groupId)
        {
            var timetables = await repository.Timetable.GetTimetablesByGroupId(groupId, false);

            if (timetables.Any())
            {
                IEnumerable<TimetableDTO> timetablesDTO = mapper.Map<IEnumerable<TimetableDTO>>(timetables);

                return Ok(timetablesDTO);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetTimetables()
        {
            var timetables = await repository.Timetable.GetAllTimetables(false);

            if (timetables.Count() < 0)
            {
                return NoContent();
            }

            var timetablesDTO = mapper.Map<IEnumerable<TimetableDTO>>(timetables);

            return Ok(timetablesDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTimetableById(int id)
        {
            var timetable = await repository.Timetable.GetTimetableById(id, false);

            if (timetable == null)
            {
                return NotFound();
            }

            var timetableDTO = mapper.Map<TimetableDTO>(timetable);

            return Ok(timetableDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTimetable(CreateTimetableDTO createTimetable)
        {
            var groupEntity = await repository.Group.GetGroupById(createTimetable.GroupId, true);
            if (groupEntity == null)
            {
                logger.Information($"Group with id: {createTimetable.GroupId} doesn't exist in the database");
                return NotFound($"Group with id: {createTimetable.GroupId} doesn't exist in the database");
            }

            List<Subject> subjectEntities = new();
            foreach (var subjectId in createTimetable.SubjectIds)
            {
                var subjectEntity = await repository.Subject.GetSubjectById(subjectId, true);
                if(subjectEntity == null)
                {
                    logger.Information($"Subject with id: {subjectId} doesn't exist in the database");
                    return NotFound($"Subject with id: {subjectId} doesn't exist in the database");
                }

                subjectEntities.Add(subjectEntity);
            }

            var timetableEntity = mapper.Map<Timetable>(createTimetable);
            timetableEntity.Group = groupEntity;
            timetableEntity.Subjects = subjectEntities;

            await repository.Timetable.CreateTimetable(timetableEntity);
            await repository.SaveAsync();

            var timetableToReturn = mapper.Map<TimetableDTO>(timetableEntity);

            return CreatedAtAction("GetTimetableById", new { id = timetableEntity.Id }, timetableToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTimetable(int id, UpdateTimetabeDTO updateTimetable)
        {
            var timetableEntity = await repository.Timetable.GetTimetableById(id, true);

            if (timetableEntity == null)
            {
                logger.Information($"Timetable with id: {id} doesn't exist in the database");
                return NotFound();
            }

            mapper.Map(updateTimetable, timetableEntity);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTimetable(int id)
        {
            var timetable = await repository.Timetable.GetTimetableById(id, false);
            if(timetable == null)
            {
                logger.Information($"Timetable with id: {id} doesn't exist in the database");
                return NotFound();
            }

            repository.Timetable.DeleteTimetable(timetable);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
