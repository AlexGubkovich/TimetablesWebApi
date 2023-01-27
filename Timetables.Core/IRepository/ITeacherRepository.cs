using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers(bool trackChanges);
        Task<Teacher> GetTeacherById(int id, bool trackChanges);
        Task CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
    }
}
