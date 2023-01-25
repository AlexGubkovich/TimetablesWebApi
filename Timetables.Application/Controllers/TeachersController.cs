using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.DTOs.TeacherDTOs;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;

        public TeachersController(IUnitOfWork repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var teachers = await repository.Teacher.GetAllTeachers();

            if (teachers.Count() < 0)
            {
                return NoContent();
            }

            return Ok(teachers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await repository.Teacher.GetTeacherById(id);

            if (teacher == null)
            {
                return NoContent();
            }

            return Ok(teacher); ;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeacher(CreateTeacherDTO createTeacher)
        {
            var teacher = mapper.Map<Teacher>(createTeacher);
            await repository.Teacher.CreateTeacher(teacher);
            await repository.SaveAsync();

            return CreatedAtAction("GetGroupById", new { id = teacher.Id }, teacher);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTeacher(Teacher updateTeacher)
        {
            repository.Teacher.UpdateTeacher(updateTeacher);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            await repository.Teacher.DeleteTeacher(id);
            await repository.SaveAsync();

            return Ok();
        }
    }
}
