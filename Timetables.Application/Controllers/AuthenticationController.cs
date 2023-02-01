using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.DTOs.UserDTOs;
using ILogger = Serilog.ILogger;

namespace Timetables.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AuthenticationController(ILogger logger,
            IMapper mapper, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(UserForRegistrationDTO registrationDTO)
        {
            var user = mapper.Map<IdentityUser>(registrationDTO);

            var result = await userManager.CreateAsync(user, registrationDTO.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            if (registrationDTO.Roles != null)
            {
                foreach (var role in registrationDTO.Roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        return BadRequest($"Role {role} doesn't exist");
                }

                await userManager.AddToRolesAsync(user, registrationDTO.Roles);
            }

            return StatusCode(201);
        }

    }
}
