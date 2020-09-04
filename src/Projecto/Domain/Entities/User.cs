namespace Projecto.Domain.Entities
{
    public class User : BaseEntity
    {
        public string PrimaryEmail { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
    }
}