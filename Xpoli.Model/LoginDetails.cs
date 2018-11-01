using System;
using System.Collections.Generic;
using System.Text;

namespace Listing.Model
{
    public class LoginDetails
    {
        public int Id {get; set;}
        public int MemberId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
       
    }
}
