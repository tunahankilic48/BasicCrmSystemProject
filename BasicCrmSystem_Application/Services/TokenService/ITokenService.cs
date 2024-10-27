using BasicCrmSystem_Application.Models.DTOs;

namespace BasicCrmSystem_Application.Services.TokenService
{
    internal interface ITokenService
    {
        public Task<GenerateTokenResponseDTO> GenerateToken(GenerateTokenRequestDTO request);
    }
}
