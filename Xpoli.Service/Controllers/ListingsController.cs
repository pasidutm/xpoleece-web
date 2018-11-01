
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listing.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<List<ListingDetail>>> GetAll()
        {
            return await _context.Listings.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetListing")] //Named Routes
        public ActionResult<ListingDetail> GetById(int id)
        {
            var item = _context.Listings.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }               

        [HttpPost]
        public IActionResult Create(ListingDetail item)
        {
            _context.Listings.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetListing", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ListingDetail item)
        {
            var listing = _context.Listings.Find(id);
            if (listing == null)
            {
                return NotFound();
            }

            listing.Description = item.Description;
            listing.Name = item.Name;

            _context.Listings.Update(listing);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var listing = _context.Listings.Find(id);
            if (listing == null)
            {
                return NotFound();
            }

            _context.Listings.Remove(listing);
            _context.SaveChanges();
            return NoContent();
        }
    }
}