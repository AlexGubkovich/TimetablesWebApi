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

        public SubjectsController(IUnitOfWork repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            var subjects = await repository.Subject.GetAllSubjects();

            if (subjects.Count() < 0)
            {
                return NoContent();
            }

            return Ok(subjects);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Subject>> GetSubjectById(int id)
        {
            var subject = await repository.Subject.GetSubjectById(id);

            if (subject == null)
            {
                return NoContent();
            }

            return Ok(subject); ;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubject(CreateSubjectDTO createSubject)
        {
            var subject = mapper.Map<Subject>(createSubject);
            await repository.Subject.CreateSubject(subject);
            await repository.SaveAsync();

            return CreatedAtAction("GetGroupById", new { id = subject.Id }, subject);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubject(Subject updateSubject)
        {
            repository.Subject.UpdateSubject(updateSubject);
            await repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSubject(int id)
        {
            await repository.Subject.DeleteSubject(id);
            await repository.SaveAsync();

            return Ok();
        }
    }
}
