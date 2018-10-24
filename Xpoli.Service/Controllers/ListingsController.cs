
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
        public List<ListingDetail> GetAll()
        {
            return _context.Listings.ToList();
        }

        [HttpGet("{id}", Name = "GetListing")] //Named Routes
        public ListingDetail GetById(int id)
        {
            var item = _context.Listings.Find(id);            
            return item;
        }

        [HttpPost]
        public int Create(ListingDetail item)
        {
            _context.Listings.Add(item);
            return _context.SaveChanges();         
        }

        [HttpPut("{id}")]
        public int Update(int id, ListingDetail item)
        {
            var listingDetail = _context.Listings.Find(id);
            if (listingDetail == null)
            {
                return -1;
            }

            listingDetail.Description = item.Description;
            listingDetail.Name = item.Name;

            _context.Listings.Update(listingDetail);
            return _context.SaveChanges();
           
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var listingDetail = _context.Listings.Find(id);
            if (listingDetail == null)
            {
                return -1;
            }

            _context.Listings.Remove(listingDetail);
            return _context.SaveChanges();
            
        }
    }
}