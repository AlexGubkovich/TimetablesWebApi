using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.DTOs.TeacherDTOs;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;
using ILogger = Serilog.ILogger;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class TeachersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;
        private readonly ILogger logger;

        public TeachersController(IUnitOfWork repository, IMapper mapper, ILogger logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetTeachers()
        {
            var teachers = await repository.Teacher.GetAllTeachers(false);

            if (teachers.Count() < 0)
            {
                return NoContent();
            }

            var teachersDTO = mapper.Map<IEnumerable<TeacherDTO>>(teachers);

            return Ok(teachersDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTeacherById(int id)
        {
            var teacher = await repository.Teacher.GetTeacherById(id, false);

            if (teacher == null)
            {
                return NotFound();
            }

            var teacherDTO = mapper.Map<TeacherDTO>(teacher);

            return Ok(teacherDTO); ;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeacher(CreateTeacherDTO createTeacher)
        {
            var teacherEntity = mapper.Map<Teacher>(createTeacher);
            await repository.Teacher.CreateTeacher(teacherEntity);
            await repository.SaveAsync();

            var teacherToReturn = mapper.Map<TeacherDTO>(teacherEntity);

            return CreatedAtAction("GetTeacherById", new { id = teacherEntity.Id }, teacherToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTeacher(int id, UpdateTeacherDTO updateTeacher)
        {
            var teacherEntity = await repository.Teacher.GetTeacherById(id, true);
            if(teacherEntity == null)
            {
                logger.Information($"Teacher with id: {id} doesn't exist in the database");
                return NotFound();
            }

            mapper.Map(updateTeacher, teacherEntity);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var teacher = await repository.Teacher.GetTeacherById(id, false);
            if (teacher == null)
            {
                logger.Information($"Teacher with id: {id} doesn't exist in the database");
                return NotFound();
            }
            repository.Teacher.DeleteTeacher(teacher);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
