using BlockbusterRentals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BlockbusterRentals.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Display(Name = "Date Of Birth")]
        public string Birthday { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //public MembershipType MembershipType { get; set; } // a Navigation property
        public MembershipTypeDto MembershipType { get; set; }

        //[Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; } // a Navigation property, used as the foeign key bc convention
    }
}