using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterRentals.Models
{
    public class MembershipType
    { 
        public byte Id { get; set; } // for use in Foreign Key!
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

    }
}