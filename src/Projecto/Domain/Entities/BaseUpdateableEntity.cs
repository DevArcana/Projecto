using System;
using Projecto.Domain.Interfaces;

namespace Projecto.Domain.Entities
{
    public abstract class BaseUpdateableEntity : BaseEntity, IUpdated
    {
        public DateTime? UpdatedUtc { get; set; }
        public string? UpdatedBy { get; set; }
    }
}