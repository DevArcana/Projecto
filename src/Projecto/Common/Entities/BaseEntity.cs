using System;
using Projecto.Common.Entities.Interfaces;

namespace Projecto.Common.Entities
{
    public abstract class BaseEntity : ICreated
    {
        public DateTime CreatedUtc { get; set; }
     
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public int Id { get; private set; }
    }
}