using BasicCrmSystem_Application.Enums;
using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Application.Services.TokenService;
using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;

namespace BasicCrmSystem_Application.Services.AccountService
{
    internal class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public AccountService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResultVM> Login(LoginDTO model)
        {

            User user = await _userRepository.GetDefault(x => x.Username == model.Username);
            if (user == null)
            {
                return new LoginResultVM(Result.Failed, "Girilen kullanıcı adı bulunamadı!");
            }
            if (user.Password != model.Password)
            {
                return new LoginResultVM(Result.Failed, "Girilen parola yanlış!!!");
            }
            LoginResultVM response = new LoginResultVM(Result.Success, "Giriş başarılı!");
            GenerateTokenResponseDTO generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequestDTO { UserName = model.Username });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            return response;
        }
    }
}
