using BasicCrmSystem_Application.Enums;

namespace BasicCrmSystem_Application.Models.VMs
{
    public class LoginResultVM
    {
        public LoginResultVM(Result result, string message)
        {
            Result = result;
            Message = message;
        }

        public Result Result { get; set; }
        public string Message { get; set; }
        public bool? AuthenticateResult { get; set; }
        public string? AuthToken { get; set; }
        public DateTime? AccessTokenExpireDate { get; set; }
    }
}
