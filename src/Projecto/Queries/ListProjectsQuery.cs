using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Projecto.Infrastructure.Auth;
using Projecto.Infrastructure.Persistance;
using Projecto.Models;

namespace Projecto.Queries
{
    public class ListProjectsQuery : IRequest<IEnumerable<ProjectDto>>
    {
    }

    public class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly UserContext _userContext;
        private readonly AppDbContext _context;

        public ListProjectsQueryHandler(UserContext userContext, AppDbContext context)
        {
            _userContext = userContext;
            _context = context;
        }

        public Task<IEnumerable<ProjectDto>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
        {
            var user = _userContext.User;
            throw new System.NotImplementedException();
        }
    }
}