using BasicCrmSystem_Application.Enums;

namespace BasicCrmSystem_Application.Models.VMs
{
    public class ResultVM
    {
        public ResultVM(Result result, string message)
        {
            Result = result;
            Message = message;
        }

        public Result Result { get; set; }
        public string Message { get; set; }
    }
}
