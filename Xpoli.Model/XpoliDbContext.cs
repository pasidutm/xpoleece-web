using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Listing.Model
{
    public class XpoliDbContext : DbContext
    {
        public XpoliDbContext(DbContextOptions<XpoliDbContext> options)
            : base(options)
        {
            LoadData();

        }

        public DbSet<ListingDetail> Listings { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<LoginDetails> Logins { get; set; }

        public DbSet<StatusDetails> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        private void LoadData()
        {
            this.Listings.Add(new ListingDetail { Name = "Amazing Views", CategoryId = 100, Description = "House with views", Id = 1, MemberId = 1 });
            this.Listings.Add(new ListingDetail { Name = "Near CBD", CategoryId = 100, Description = "apartment near to CBD", Id = 2, MemberId = 1 });
            this.Listings.Add(new ListingDetail { Name = "3b house in Mt Eden", CategoryId = 100, Description = "house in Mt Eden", Id = 3, MemberId = 2 });
            this.Listings.Add(new ListingDetail { Name = "Life Style block", CategoryId = 100, Description = "a lot of space", Id = 4, MemberId = 2 });
            this.Listings.Add(new ListingDetail { Name = "Room mate wanted", CategoryId = 100, Description = "help me with my rent", Id = 5, MemberId = 3 });

            this.Members.Add(new Member { Id = 1, FirstName = "John", LastName = "Doe" });
            this.Members.Add(new Member { Id = 2, FirstName = "Brian", LastName = "Lara" });
            this.Members.Add(new Member { Id = 3, FirstName = "Ricky", LastName = "Pointing" });

            this.Status.Add(new StatusDetails { Id = 200, Status = "OK", Description = "Standard response for successful HTTP requests" });
            this.Status.Add(new StatusDetails { Id = 201, Status = "Created", Description = "The request has been fulfilled and resulted in a new resource being created. The newly created resource can be referenced by the URI(s) returned in the entity of the response" });
            this.Status.Add(new StatusDetails { Id = 202, Status = "Accepted", Description = "The request has been accepted for processing, but the processing has not been completed." });
            this.Status.Add(new StatusDetails { Id = 301, Status = "Moved Permanently", Description = "The requested resource has been assigned a new permanent URI and any future references to this resource SHOULD use one of the returned URIs. Clients with link editing capabilities ought to automatically re-link references to the Request-URI to one or more of the new references returned by the server" });
            this.Status.Add(new StatusDetails { Id = 307, Status = "Temporary Redirect", Description = "The requested resource resides temporarily under a different URI. Since the redirection MAY be altered on occasion, the client SHOULD continue to use the Request-URI for future requests. " });
            this.Status.Add(new StatusDetails { Id = 400, Status = "Bad Request", Description = "The request could not be understood by the server due to malformed syntax. The client SHOULD NOT repeat the request without modifications." });
            this.Status.Add(new StatusDetails { Id = 401, Status = "Unauthorized", Description = "The request requires user authentication. The response MUST include a WWW-Authenticate header field" });
            this.Status.Add(new StatusDetails { Id = 404, Status = "Not Found", Description = "The server has not found anything matching the Request-URI. " });
           //
            this.Status.Add(new StatusDetails { Id = 200, Status = "OK", Description = "Standard response for successful HTTP requests" });

            this.SaveChanges();
        }
    }


}
