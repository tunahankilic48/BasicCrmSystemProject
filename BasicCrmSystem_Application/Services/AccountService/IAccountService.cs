using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;

namespace BasicCrmSystem_Application.Services.AccountService
{
    internal interface IAccountService
    {
        Task<ResultVM> Login(LoginDTO model);
    }
}
