namespace BasicCrmSystem_Domain.Entities
{
    public class Role : IBaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Navigation Property
        public List<User>? Users { get; set; }
    }
}
