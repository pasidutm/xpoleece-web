
using System.Collections.Generic;
using System.Linq;
using Listing.Model;
using Microsoft.AspNetCore.Mvc;

namespace Listing.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly XpoliDbContext _context;

        public ListingsController(XpoliDbContext context)
        {
            _context = context;            
        }
               
        public List<ListingDetail> GetAll()
        {
            return null; //write code here
        }

       
        public ListingDetail GetById(int id)
        {
            return null; //write code here
        }

        [HttpPost]
        public int Create(ListingDetail item)
        {
            return 1; //write code here   
        }

        [HttpPut("{id}")]
        public int Update(int id, ListingDetail item)
        {
            return 1; //write code here       
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return 1; //write code here      
        }
    }
}