using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listing.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Xpoli.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly XpoliDbContext _context;

        public MembersController(XpoliDbContext context)
        {
            _context = context;
        }

        // GET: api/Member
        [HttpGet]
        public List<Member> Get()
        {
            return _context.Members.ToList();
        }

        // GET: api/Member/5
        [HttpGet("{id}", Name = "Get")]
        public Member Get(int id)
        {
            var item = _context.Members.Find(id);
            if (item == null)
            {
                return null;
            }
            return item;
        }

        // POST: api/Member
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Member/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
