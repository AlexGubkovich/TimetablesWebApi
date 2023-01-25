using Microsoft.EntityFrameworkCore;
using Timetables.Core.DTOs.ScheduleDTOs;
using Timetables.Core.IRepository;
using Timetables.Core.Models;
using Timetables.Data;
using Timetables.Data.Models;

namespace Timetables.Core.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly TimetableDbContext context;

        public ScheduleRepository(TimetableDbContext context)
        {
            this.context = context;
        }

        public async Task<Schedule> GetActiveAsync()
        {
            return await context.Schedules
                .Include(p => p.Lessons)
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.IsActive == true);
        }

        public async Task<IList<Schedule>> GetAllAsync()
        {
            return await context.Schedules.Include(p => p.Lessons).AsNoTracking().ToListAsync();
        }

        public async Task<Schedule> GetById(int id)
        {
            return await context.Schedules.FindAsync(id);
        }

        public async Task<RepositoryResponse> CreateAsync(Schedule schedule)
        {
            try
            {
                schedule.IsActive = false;
                var lessons = schedule.Lessons;

                await context.Lessons.AddRangeAsync(lessons);
                await context.Schedules.AddAsync(schedule);
                await context.SaveChangesAsync();

                return new RepositoryResponse { Success = true };
            }
            catch (DbUpdateException ex)
            {
                return new RepositoryResponse { Success = false, Error = ex.Message };
            }
        }

        public async Task<RepositoryResponse> DeleteAsync(int id)
        {
            var schedule = await context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return new RepositoryResponse { Success = false, Error = "There is no such schedule" };
            }
            context.Schedules.Remove(schedule);
            await context.SaveChangesAsync();

            return new RepositoryResponse { Success = true };
        }

        public async Task<RepositoryResponse> SetIsActiveAsync(PatchScheduleDTO patchSchedule)
        {
            var scheduleCurrent = await context.Schedules.FindAsync(patchSchedule.Id);

            if (scheduleCurrent == null)
            {
                return new RepositoryResponse { Success = false, Error = "There is no such schedule" };
            }

            await ChangeIsActive(scheduleCurrent, patchSchedule.IsActive);

            return new RepositoryResponse { Success = true };
        }

        public async Task<RepositoryResponse> UpdateAsync(Schedule updateSchedule)
        {
            try
            {
                var schedule = await context.Schedules.Include(p => p.Lessons).FirstOrDefaultAsync(p => p.Id == updateSchedule.Id);

                if (schedule == null)
                {
                    return new RepositoryResponse { Success = false, Error = "There is no such schedule" };
                }

                await ChangeIsActive(schedule, updateSchedule.IsActive);

                schedule.Name = updateSchedule.Name;
                schedule.IsActive = updateSchedule.IsActive;

                var lessons = updateSchedule.Lessons;
                if (!schedule.Lessons.SequenceEqual(lessons))
                {
                    context.Lessons.RemoveRange(schedule.Lessons);
                    context.Lessons.AddRange(lessons);
                    schedule.Lessons = lessons;
                }

                context.Schedules.Update(schedule);
                await context.SaveChangesAsync();

                return new RepositoryResponse { Success = true };
            }
            catch (DbUpdateException ex)
            {
                return new RepositoryResponse { Success = false, Error = ex.Message };
            }
        }

        private async Task ChangeIsActive(Schedule scheduleCurrent, bool isActive)
        {
            var Schedule = await context.Schedules.SingleOrDefaultAsync(s => s.IsActive == true);
            if (Schedule != null)
            {
                if (Schedule.Id == scheduleCurrent.Id)
                {
                    Schedule.IsActive = isActive;
                    context.Schedules.Update(Schedule);
                    await context.SaveChangesAsync();
                }
                else
                {
                    if (isActive == true)
                    {
                        Schedule.IsActive = false;
                        context.Schedules.Update(Schedule);
                    }

                    scheduleCurrent.IsActive = isActive;
                    context.Schedules.Update(scheduleCurrent);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                scheduleCurrent.IsActive = isActive;
                context.Schedules.Update(scheduleCurrent);
                await context.SaveChangesAsync();
            }
        }
    }
}
