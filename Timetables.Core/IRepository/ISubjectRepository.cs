using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjects(bool trackChanges);
        Task<Subject> GetSubjectById(int id, bool trackChanges);
        Task<IEnumerable<Subject>> GetSubjectsByIds(List<int> subjectsIds, bool trackChanges);
        Task CreateSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void DeleteSubject(Subject id);
    }
}
