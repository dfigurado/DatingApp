using System.Threading;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using MediatR;

namespace API.Application.Users
{
    public class User
    {
        public class Query : IRequest<AppUser>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppUser>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<AppUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);
                return user; 
            }
        }
    }
}