using BlockbusterRentals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BlockbusterRentals.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //public Genre Genre { get; set; }

        //[Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        //[Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        //[Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        //[Display(Name = "Number in Stock")]
        [Required]
        public int NumberInStock { get; set; }
    }
}