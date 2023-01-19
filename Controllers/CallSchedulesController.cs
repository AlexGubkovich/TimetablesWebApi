using AutoMapper;
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
        public async Task<ActionResult<CallSchedule>> GetCallSchedule()
        {
            var callSchedule = await context.CallSedules.Include(p => p.Lessons).SingleOrDefaultAsync(s => s.IsActive == true);

            if(callSchedule != null)
            {
                CallScheduleDTO callScheduleDTO = mapper.Map<CallScheduleDTO>(callSchedule);
                return Ok(callScheduleDTO);
            }

            return NoContent();
        }
    }
}
