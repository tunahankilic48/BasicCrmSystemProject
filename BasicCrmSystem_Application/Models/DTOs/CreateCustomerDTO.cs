namespace BasicCrmSystem_Application.Models.DTOs
{
    public class CreateCustomerDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int RegionId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
