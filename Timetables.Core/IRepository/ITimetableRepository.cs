using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface ITimetableRepository : IRepositoryBase<Timetable>
    {
        Task<IEnumerable<Timetable>> GetAllTimetables(bool trackChanges);
        Task<Timetable> GetTimetableById(int id, bool trackChanges);
        Task<IEnumerable<Timetable>> GetTimetablesByGroupId(int groupId, bool trackChanges);
        Task CreateTimetable(Timetable timetable);
        void UpdateTimetable(Timetable timetable);
        void DeleteTimetable(Timetable timetable);
    }
}
