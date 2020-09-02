using System;

namespace Projecto.Domain.Interfaces
{
    public interface IUpdated
    {
        DateTime? UpdatedUtc { get; set; }
        string? UpdatedBy { get; set; }
    }
}