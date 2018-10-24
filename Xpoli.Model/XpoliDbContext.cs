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


        private void LoadData() {
            this.Listings.Add(new ListingDetail { Name = "Amazing Views", CategoryId=100, Description="House with views", Id=1, MemberId=1 });
            this.Listings.Add(new ListingDetail { Name = "Near CBD", CategoryId = 100, Description = "apartment near to CBD", Id = 2, MemberId = 1 });
            this.Listings.Add(new ListingDetail { Name = "3b house in Mt Eden", CategoryId = 100, Description = "house in Mt Eden", Id = 3, MemberId = 2 });
            this.Listings.Add(new ListingDetail { Name = "Life Style block", CategoryId = 100, Description = "a lot of space", Id = 4, MemberId = 2 });
            this.Listings.Add(new ListingDetail { Name = "Room mate wanted", CategoryId = 100, Description = "help me with my rent", Id = 5, MemberId = 3 });

            this.Members.Add(new Member { Id = 1, FirstName = "John", LastName = "Doe" });
            this.Members.Add(new Member { Id = 2, FirstName = "Brian", LastName = "Lara" });
            this.Members.Add(new Member { Id = 3, FirstName = "Ricky", LastName = "Pointing" });
            this.SaveChanges();
        }
    }


}
