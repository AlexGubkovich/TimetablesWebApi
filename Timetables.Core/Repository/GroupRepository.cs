using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.IRepository;
using Timetables.Core.Repository.Base;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(TimetableDbContext context) : base(context) { }

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Group> GetGroupById(int id)
        {
            return await Context.Groups.FindAsync(id);
        }

        public async Task CreateGroup(Group group)
        {
            await Create(group);
        }

        public void UpdateGroup(Group group)
        {
            Update(group);
        }

        public async Task DeleteGroup(int id)
        {
            var group = await Context.Groups.FindAsync(id);
            Delete(group);
        }
    }
}
