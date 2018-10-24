using System;

namespace Listing.Model
{
    public class ListingDetail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int MemberId { get; set; }

    }
}
