using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(int id);
    }
}
