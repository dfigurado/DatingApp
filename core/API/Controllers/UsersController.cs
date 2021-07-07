using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.Entities;
using API.Application.User;

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
        public async Task<IEnumerable<AppUser>> List()
        {
            var query = new List.Query();
            var response = await Mediator.Send(query);

            return response;
        }
    }
}