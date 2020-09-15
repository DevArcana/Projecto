using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Projecto.Authentication;
using Projecto.Infrastructure.Persistance;
using Projecto.Projects.Models;

namespace Projecto.Projects.Queries
{
    public class ListProjectsQuery : IRequest<IEnumerable<ProjectDto>>
    {
    }

    public class ListProjectsQueryHandler : IRequestHandler<ListProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly UserContext _userContext;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ListProjectsQueryHandler(UserContext userContext, AppDbContext context, IMapper mapper)
        {
            _userContext = userContext;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(ListProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Projects
                .AsNoTracking()
                .Include(x => x.Owner)
                .Where(x => x.Owner.Id == _userContext.User!.Id)
                .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}