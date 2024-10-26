using BasicCrmSystem_Application.Enums;
using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;

namespace BasicCrmSystem_Application.Services.AccountService
{
    internal class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultVM> Login(LoginDTO model)
        {
            User user = await _userRepository.GetDefault(x => x.Username == model.Username);
            if (user == null)
            {
                return new ResultVM(Result.Failed,"Girilen kullanıcı adı bulunamadı!");
            }
            if (user.Password != model.Password)
            {
                return new ResultVM(Result.Failed, "Girilen parola yanlış!!!");
            }
            return new ResultVM(Result.Success, "Giriş başarılı!");
        }
    }
}
