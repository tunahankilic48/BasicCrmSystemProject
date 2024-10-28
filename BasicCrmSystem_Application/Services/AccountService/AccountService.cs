using BasicCrmSystem_Application.Enums;
using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Application.Services.TokenService;
using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace BasicCrmSystem_Application.Services.AccountService
{
    internal class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ILogger _logger;
        public AccountService(IUserRepository userRepository, ITokenService tokenService, ILogger<User> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<LoginResultVM> Login(LoginDTO model)
        {

            User user = await _userRepository.GetDefault(x => x.Username == model.Username);
            if (user == null)
            {
                _logger.LogInformation("Kullanıcı Bulunamadı",$"UserName: {model.Username}");
                return new LoginResultVM(Result.Failed, "Girilen kullanıcı adı bulunamadı!");
            }
            if (user.Password != model.Password)
            {
                _logger.LogInformation("Kullanıcı Bulundu. Parola yanlış", $"UserName: {model.Username}");
                return new LoginResultVM(Result.Failed, "Girilen parola yanlış!!!");
            }
            LoginResultVM response = new LoginResultVM(Result.Success, "Giriş başarılı!");
            GenerateTokenResponseDTO generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequestDTO { UserName = model.Username });

            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;
            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            _logger.LogInformation("Giriş Başarılı", $"UserName: {model.Username}", $"Authentication Token: {response.AuthToken}");

            return response;
        }
    }
}
