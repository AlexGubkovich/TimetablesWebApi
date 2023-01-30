using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.DTOs.SubjectsDTOs;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork repository;
        private readonly Serilog.ILogger logger;

        public SubjectsController(IUnitOfWork repository, IMapper mapper, Serilog.ILogger logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetSubjects()
        {
            var subjects = await repository.Subject.GetAllSubjects(false);

            if (subjects.Count() < 0)
            {
                return NoContent();
            }

            var subjectsDTO = mapper.Map<IEnumerable<SubjectDTO>>(subjects);

            return Ok(subjectsDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetSubjectById(int id)
        {
            var subject = await repository.Subject.GetSubjectById(id, false);

            if (subject == null)
            {
                return NotFound();
            }

            var subjectDTO = mapper.Map<SubjectDTO>(subject);

            return Ok(subjectDTO); ;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubject(CreateSubjectDTO createSubject)
        {
            var teacherEntity = await repository.Teacher.GetTeacherById(createSubject.TeacherId.Value, true);
            if(teacherEntity == null)
            {
                return NotFound($"Teacher with id: {createSubject.TeacherId} doesn't exist in the database");
            }

            var subjectEntity = mapper.Map<Subject>(createSubject);
            subjectEntity.Teacher = teacherEntity;

            await repository.Subject.CreateSubject(subjectEntity);
            await repository.SaveAsync();

            var subjectToReturn = mapper.Map<SubjectDTO>(subjectEntity);

            return CreatedAtAction("GetSubjectById", new { id = subjectEntity.Id }, subjectToReturn);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateSubject(int id, UpdateSubjectDTO updateSubject)
        {
            var subjectEntity = await repository.Subject.GetSubjectById(id, true);
            if (subjectEntity == null)
            {
                logger.Information($"Subject with id: {id} doesn't exist in the database");
                return NotFound();
            }

            var teacherEntity = await repository.Teacher.GetTeacherById(updateSubject.TeacherId.Value, true);
            if (teacherEntity == null)
            {
                return NotFound($"Teacher with id: {updateSubject.TeacherId} doesn't exist in the database");
            }

            mapper.Map(updateSubject, subjectEntity);
            subjectEntity.Teacher = teacherEntity;

            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            var subject = await repository.Subject.GetSubjectById(id, false);
            if(subject == null)
            {
                logger.Information($"Subject with id: {id} doesn't exist in the database");
                return NotFound();
            }

            repository.Subject.DeleteSubject(subject);
            await repository.SaveAsync();

            return NoContent();
        }
    }
}
