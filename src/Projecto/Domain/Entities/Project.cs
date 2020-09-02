using System;
using System.Text.RegularExpressions;

namespace Projecto.Domain.Entities
{
    public class Project : BaseUpdateableEntity
    {
        private string _name = null!;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Project's name not be empty.");
                }
                
                if (value.Length > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Project's name must have at maximum 100 characters.");
                }

                _name = value;
            }
        }
        
        private string _slug = null!;
        public string Slug
        {
            get => _slug;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Project's identifier not be empty.");
                }
                
                if (value.Length > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Project's identifier must have at maximum 100 characters.");
                }
                
                if (!Regex.IsMatch(value, "^[\\w](-\\w)*$"))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Project's identifier must match ^[\\w](-\\w)*$");
                }

                _slug = value;
            }
        }
        
        private string? _description;
        public string? Description
        {
            get => _description;
            set
            {
                if (value != null)
                {
                    if (value.Length > 500)
                    {
                        throw new ArgumentOutOfRangeException(nameof(value), value, "Project's description must have at maximum 500 characters.");
                    }
                }

                _description = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }

        private Project()
        {
            // Needed by EF Core
        }
        
        public Project(string name, string slug, string? description)
        {
            Name = name;
            Slug = slug;
            Description = description;
        }
    }
}