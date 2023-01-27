using Timetables.Core.IRepository.Base;
using Timetables.Data.Models;

namespace Timetables.Core.IRepository
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        Task<IEnumerable<Group>> GetAllGroups(bool trackChanges);
        Task<Group> GetGroupById(int id, bool trackChanges);
        Task CreateGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(Group id);

    }
}
