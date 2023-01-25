using Timetables.Core.DTOs.ScheduleDTOs;
using Timetables.Core.Models;
using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface IScheduleRepository
    {
        Task<IList<Schedule>> GetAllAsync();
        Task<Schedule> GetActiveAsync();
        Task<Schedule> GetById(int id);
        Task<RepositoryResponse> CreateAsync(Schedule Schedule);
        Task<RepositoryResponse> SetIsActiveAsync(PatchScheduleDTO patchSchedule);
        Task<RepositoryResponse> UpdateAsync(Schedule updateSchedule);
        Task<RepositoryResponse> DeleteAsync(int id);
    }
}
