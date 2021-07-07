using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.Entities;
using API.Application.Users;
using System.Linq;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        
        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> List()
        {
            var query = new List.Query();
            var response = await Mediator.Send(query);

            return response.ToList();
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await Mediator.Send(new User.Query { Id = id});
        }
    }
}