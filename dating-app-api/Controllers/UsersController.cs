using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sp.DatingApp.Data;
using Sp.DatingApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;

        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();

            return users;
        }

        // api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }

        
        [HttpPost]
        public async void PostUser(AppUser user)
        {
            await context.Users.AddAsync(user);
            context.SaveChanges();
        }
    }
}
