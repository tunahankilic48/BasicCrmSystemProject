namespace BasicCrmSystem_Application.Models.DTOs
{
    internal class GenerateTokenResponseDTO
    {
        public string? Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}
