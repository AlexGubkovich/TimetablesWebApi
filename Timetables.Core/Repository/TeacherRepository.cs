using Microsoft.EntityFrameworkCore;
using Timetables.Core.IRepository;
using Timetables.Core.Repository.Base;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(TimetableDbContext context) : base(context) { }

        public async Task<IEnumerable<Teacher>> GetAllTeachers(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Teacher> GetTeacherById(int id, bool trackChanges) =>
            await FindByCondition(t => t.Id == id, trackChanges)
                .SingleOrDefaultAsync();

        public async Task CreateTeacher(Teacher teacher) => await Create(teacher);

        public void UpdateTeacher(Teacher teacher) => Update(teacher);

        public void DeleteTeacher(Teacher teacher) => Delete(teacher);
    }
}
