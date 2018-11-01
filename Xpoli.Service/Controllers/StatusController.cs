
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Listing.Model;
using Microsoft.AspNetCore.Mvc;

namespace Listing.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly XpoliDbContext _context;
        private readonly IUrlHelper _urlHelper;

        public StatusController(XpoliDbContext context)
        {
            _context = context;
            
        }

        [HttpGet] //HTTP 200
        public ActionResult<List<StatusDetails>> Get()
        {
            return _context.Status.ToList();
        }

        //201 The request has been fulfilled and resulted in a new resource being created. 
        //The newly created resource can be referenced by the URI(s) returned in the entity of the response
        [HttpPost]
        public ActionResult Save()
        {
            //write code
            return null;
        }

        //202
        [HttpPost]
        [Route("process")]
        public ActionResult ProcessLongRunningTask()
        {
            
        }


        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<StatusDetails> GetById(int id)
        {
            if (id == 300)
            {                
                var url = Url.Link("GetById",307).Replace("/300", "/307");
                return RedirectPermanent(url);
            }
            var item = _context.Status.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

    }
}