using System;
using Projecto.Domain.Interfaces;

namespace Projecto.Domain.Entities
{
    public abstract class BaseEntity : ICreated
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public DateTime CreatedUtc { get; set; }
        
        public int Id { get; private set; }
        public string CreatedBy { get; set; } = "Unknown";
    }
}