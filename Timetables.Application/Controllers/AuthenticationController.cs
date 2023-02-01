using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timetables.Core.AuthService;
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
        private readonly IAuthenticationManager authManager;

        public AuthenticationController(ILogger logger,
            IMapper mapper, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            IAuthenticationManager authManager)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authManager = authManager;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
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

        [HttpPost("login")]
        public async Task<ActionResult> Authenticate(UserForAuthenticationDTO user)
        {
            if(!await authManager.ValidateUser(user))
            {
                logger.Information($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password.");
                return Unauthorized();
            }

            return Ok(new { Token = await authManager.CreateToken() });
        }

    }
}
