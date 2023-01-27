using Microsoft.EntityFrameworkCore;
using Timetables.Core.IRepository;
using Timetables.Core.Repository.Base;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class TimetableRepository : RepositoryBase<Timetable>, ITimetableRepository
    {
        public TimetableRepository(TimetableDbContext context) : base(context) { }

        public async Task<IEnumerable<Timetable>> GetAllTimetables()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Timetable> GetTimetableById(int id)
        {
            return await Context.Timetables.FindAsync(id);
        }

        public async Task<IEnumerable<Timetable>> GetTimetablesByGroupId(int groupId)
        {
            return await FindByCondition(t => t.GroupId == groupId)
                .Include(p => p.Classes)
                .Include(p => p.Subjects).ThenInclude(p => p.Teacher)
                .ToListAsync();
        }

        public async Task CreateTimetable(Timetable timetable)
        {
            await Create(timetable);
        }

        public void UpdateTimetable(Timetable timetable)
        {
            Update(timetable);
        }

        public async Task DeleteTimetable(int id)
        {
            var timetable = await Context.Timetables.FindAsync(id);
            Delete(timetable);
        }
    }
}
