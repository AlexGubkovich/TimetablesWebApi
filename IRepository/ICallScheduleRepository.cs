using TimetablesProject.Data;
using TimetablesProject.Models;
using TimetablesProject.Models.DTO.ScheduleDTO;

namespace TimetablesProject.IRepository
{
    public interface IScheduleRepository
    {
        Task<IList<Schedule>> GetAllAsync();
        Task<Schedule> GetActiveAsync();
        Task<RepositoryResponse> CreateAsync(Schedule Schedule);
        Task<RepositoryResponse> SetIsActiveAsync(int id, bool IsActive);
        Task<RepositoryResponse> UpdateAsync(Schedule updateSchedule);
        Task<RepositoryResponse> DeleteAsync(int id);
    }
}
