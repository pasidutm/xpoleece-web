
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

        [HttpGet]
        public ActionResult<List<ListingDetail>> GetAll()
        {
            return _context.Listings.ToList();
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
            var todo = _context.Listings.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Description = item.Description;
            todo.Name = item.Name;

            _context.Listings.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.Listings.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Listings.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}