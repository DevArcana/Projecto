using Projecto.Common.Entities;

namespace Projecto.Authentication
{
    public class User : BaseEntity
    {
        public string PrimaryEmail { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
    }
}