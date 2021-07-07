using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using API.Data;
using API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Users
{
    public class List
    {
        public class Query : IRequest<IEnumerable<AppUser>> {}

        public class Handler : IRequestHandler<Query, IEnumerable<AppUser>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<AppUser>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Users.ToListAsync();
            }
        }
    }
}