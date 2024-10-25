namespace BasicCrmSystem_Domain.Entities
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation Property
        public Role? Role { get; set; }
    }
}
