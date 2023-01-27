using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface ITimetableRepository : IRepositoryBase<Timetable>
    {
        Task<IEnumerable<Timetable>> GetTimetablesByGroupId(int groupId);
        Task<IEnumerable<Timetable>> GetAllTimetables();
        Task<Timetable> GetTimetableById(int id);
        Task CreateTimetable(Timetable timetable);
        void UpdateTimetable(Timetable timetable);
        Task DeleteTimetable(int id);
    }
}
