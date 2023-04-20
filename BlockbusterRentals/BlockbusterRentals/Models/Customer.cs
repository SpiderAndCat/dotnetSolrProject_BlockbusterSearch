using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlockbusterRentals.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public string Birthday { get; set; }

        public bool IsSubscribedToNewsletter  { get; set; }

        public MembershipType MembershipType { get; set; } // a Navigation property

        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; } // a Navigation property, used as the foeign key bc convention
    }
}