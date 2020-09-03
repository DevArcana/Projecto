namespace Projecto.Domain.Entities
{
    public class User : BaseUpdateableEntity
    {
        public string PrimaryEmail { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
    }
}