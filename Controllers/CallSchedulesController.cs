using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimetablesProject.Data;
using TimetablesProject.Models;
using TimetablesProject.Models.DTO;

namespace TimetablesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallSchedulesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly TimetableDbContext context;

        public CallSchedulesController(TimetableDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<CallScheduleDTO>> GetActiveCallSchedule()
        {
            var callSchedule = await context.CallSchedules.Include(p => p.Lessons).AsNoTracking().SingleOrDefaultAsync(s => s.IsActive == true);

            if (callSchedule != null)
            {
                CallScheduleDTO callScheduleDTO = mapper.Map<CallScheduleDTO>(callSchedule);
                return Ok(callScheduleDTO);
            }

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<CallSchedule>> GetCallSchedules()
        {
            var callSchedule = await context.CallSchedules.Include(p => p.Lessons).AsNoTracking().ToListAsync();

            if (callSchedule != null)
            {
                return Ok(callSchedule);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCallSchedule(CreateCallScheduleDTO CreateDTO)
        {
            bool isExist = await context.CallSchedules.AnyAsync(p => p.Name == CreateDTO.Name);
            if (!isExist)
            {
                var callSchedule = mapper.Map<CallSchedule>(CreateDTO);
                callSchedule.IsActive = false;

                var lessons = mapper.Map<List<Lesson>>(callSchedule.Lessons);
                await context.Lessons.AddRangeAsync(lessons);

                await context.CallSchedules.AddAsync(callSchedule);

                await context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCallSchedule(CallSchedule UpdateCallSchedule)
        {
            try
            {
                UpdateCallSchedule.Lessons = null;
                await ChangeIsActive(UpdateCallSchedule, UpdateCallSchedule.IsActive);

                context.CallSchedules.Update(UpdateCallSchedule);

                await context.SaveChangesAsync();


            }
            catch (DbUpdateException)
            {
                return NotFound();
            }


            //if (callScheduleToUpdate != null)
            //{
            //    callScheduleToUpdate = UpdateCallSchedule;

            //    context.Lessons.UpdateRange(callScheduleToUpdate.Lessons);
            //    callScheduleToUpdate.Lessons = null;

            //    context.CallSchedules.Update(callScheduleToUpdate);
            //    await context.SaveChangesAsync();

            //    await ChangeIsActive(callScheduleToUpdate, callScheduleToUpdate.IsActive);

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> SetCallScheduleActive(int Id, bool IsActive)
        {
            var callScheduleCurrent = await context.CallSchedules.FindAsync(Id);

            if (callScheduleCurrent != null)
            {
                await ChangeIsActive(callScheduleCurrent, IsActive);
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCallSchedule(int Id)
        {
            var callSchedule = await context.CallSchedules.FindAsync(Id);
            if (callSchedule != null)
            {
                context.CallSchedules.Remove(callSchedule);
                await context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        private async Task ChangeIsActive(CallSchedule callScheduleCurrent, bool IsActive)
        {
            var callSchedule = await context.CallSchedules.SingleOrDefaultAsync(s => s.IsActive == true);
            if (callSchedule != null)
            {
                if (callSchedule.Id == callScheduleCurrent.Id)
                {
                    callSchedule.IsActive = IsActive;
                    context.CallSchedules.Update(callSchedule);
                    await context.SaveChangesAsync();
                }
                else
                {
                    if(IsActive == true)
                    {
                        callSchedule.IsActive = false;
                        context.CallSchedules.Update(callSchedule);
                    }

                    callScheduleCurrent.IsActive = IsActive;
                    context.CallSchedules.Update(callScheduleCurrent);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                callScheduleCurrent.IsActive = IsActive;
                context.CallSchedules.Update(callScheduleCurrent);
                await context.SaveChangesAsync();
            }
        }
    }
}
