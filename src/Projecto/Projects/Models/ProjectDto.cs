using System;
using Projecto.Infrastructure.AutoMapper;

namespace Projecto.Projects.Models
{
    public class ProjectDto : IMapFrom<Project>
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
    }
}