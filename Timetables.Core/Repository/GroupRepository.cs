using Microsoft.EntityFrameworkCore;
using Timetables.Core.IRepository;
using Timetables.Core.Repository.Base;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(TimetableDbContext context) : base(context) { }

        public async Task<IEnumerable<Group>> GetAllGroups(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Group> GetGroupById(int id, bool trackChanges) =>
            await FindByCondition(g => g.Id == id, trackChanges)
                .SingleOrDefaultAsync();

        public async Task CreateGroup(Group group) => await Create(group);

        public void UpdateGroup(Group group) => Update(group);

        public void DeleteGroup(Group group) => Delete(group);
    }
}
