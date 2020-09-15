using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Projecto.Authentication;
using Projecto.Infrastructure.Persistance;
using Projecto.Projects.Models;

namespace Projecto.Projects.Commands
{
    public class CreateProjectCommand : IRequest<ProjectDto>
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
    {
        private readonly UserContext _userContext;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProjectCommandHandler> _logger;

        public CreateProjectCommandHandler(AppDbContext context, ILogger<CreateProjectCommandHandler> logger, UserContext userContext, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _userContext = userContext;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Debug.Assert(_userContext.User != null, "_userContext.User != null");
            _logger.LogInformation("User {user} wants to create a new project: {request}", _userContext.User.DisplayName, request);

            var project = new Project(_userContext.User, request.Name, request.Slug, request.Description);

            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Couldn't create project...");
                throw;
            }

            return _mapper.Map<ProjectDto>(project);
        }
    }
}