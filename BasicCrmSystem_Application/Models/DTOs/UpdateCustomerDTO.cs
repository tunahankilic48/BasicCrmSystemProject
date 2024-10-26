namespace BasicCrmSystem_Application.Models.DTOs
{
    public class UpdateCustomerDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int RegionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    }
}
