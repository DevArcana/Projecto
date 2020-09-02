using System;

namespace Projecto.Domain.Interfaces
{
    public interface ICreated
    {
        string CreatedBy { get; set; }
        DateTime CreatedUtc { get; set; }
    }
}