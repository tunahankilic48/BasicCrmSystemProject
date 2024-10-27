using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;

namespace BasicCrmSystem_Application.Services.AccountService
{
    public interface IAccountService
    {
        Task<LoginResultVM> Login(LoginDTO model);
    }
}
