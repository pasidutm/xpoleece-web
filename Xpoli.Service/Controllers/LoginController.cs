
using System.Collections.Generic;
using System.Linq;
using Listing.Model;
using Microsoft.AspNetCore.Mvc;

namespace Listing.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         private readonly XpoliDbContext _context;

        public LoginController(XpoliDbContext context)
        {
            _context = context;
        }

        [HttpPost]      
        public IActionResult CheckPassword(LoginDetails item)
        {
            _context.Logins.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetListing", new { id = item.MemberId }, item);
        }
    }
}