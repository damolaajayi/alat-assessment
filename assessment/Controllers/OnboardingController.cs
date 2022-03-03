using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {
        private readonly OnboardingInterface _onboarding;
        private readonly ILoggerManager _logger;
        public OnboardingController(OnboardingInterface onboarding, ILoggerManager logger)
        {
            _onboarding = onboarding;
            _logger = logger;
        }

        [HttpGet]
        [Route("Getallusers")]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation("Getting all users");
            var resp = await _onboarding.GetAllUsers();
            if(resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }


        [HttpPost]
        [Route("adduser")]
        public async Task<IActionResult> AddUser(string PhoneNumber, Onboard onboard)
        {
            _logger.LogInformation("Creating user");
            var resp = await _onboarding.CreateNewUser(PhoneNumber, onboard);
            return Ok(resp);
        }


        [HttpPost]
        [Route("getallbanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            var resp = await _onboarding.GetAllBanks();
            return Ok(resp);
        }
    }
}
