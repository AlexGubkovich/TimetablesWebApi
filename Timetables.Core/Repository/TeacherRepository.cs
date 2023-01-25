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

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await Context.Teachers.FindAsync(id);
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            await Create(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            Update(teacher);
        }

        public async Task DeleteTeacher(int id)
        {
            var teacher = await Context.Teachers.FindAsync(id);
            Delete(teacher);
        }
    }
}
