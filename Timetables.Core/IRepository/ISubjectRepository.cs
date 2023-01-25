using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.DTOs;
using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task CreateSubject(Subject subject);
        void UpdateSubject(Subject subject);
        Task DeleteSubject(int id);
    }
}
