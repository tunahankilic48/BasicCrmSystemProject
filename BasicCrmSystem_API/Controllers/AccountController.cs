using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Application.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrmSystem_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async  Task<IActionResult> Login(LoginDTO model)
        {
            LoginResultVM result = await _accountService.Login(model);
            if(result.Result == BasicCrmSystem_Application.Enums.Result.Failed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Message);
        }
    }
}
