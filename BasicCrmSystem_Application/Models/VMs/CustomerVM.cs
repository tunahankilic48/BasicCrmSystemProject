namespace BasicCrmSystem_Application.Models.VMs
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int RegionId { get; set; }
    }
}
