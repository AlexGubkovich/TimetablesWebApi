using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        Task<IEnumerable<Group>> GetAllGroups();
        Task<Group> GetGroupById(int id);
        Task CreateGroup(Group group);
        void UpdateGroup(Group group);
        Task DeleteGroup(int id);

    }
}
