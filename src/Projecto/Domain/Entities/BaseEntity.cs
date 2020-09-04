using System;
using Projecto.Domain.Interfaces;

namespace Projecto.Domain.Entities
{
    public abstract class BaseEntity : ICreated
    {
        public DateTime CreatedUtc { get; set; }
     
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public int Id { get; private set; }
    }
}