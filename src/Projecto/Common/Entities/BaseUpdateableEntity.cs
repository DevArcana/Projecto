using System;
using Projecto.Common.Entities.Interfaces;

namespace Projecto.Common.Entities
{
    public abstract class BaseUpdateableEntity : BaseEntity, IUpdated
    {
        public DateTime? UpdatedUtc { get; set; }
    }
}