using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BlockbusterRentals.Models
{
    public class SearchResult
    {

        public string Title { get; set; }


        [Display(Name = "Release Date")]
        public string Released { get; set; }

        public string Runtime { get; set; }

        public string Genre { get; set; }


        [Display(Name = "Cast")]

        public string Actors { get; set; }

        [Display(Name = "Description")]

        public string Plot { get; set; }

        public string imdbId { get; set; }


        [Display(Name = "Rating / 5")]

        public string imdbRating { get; set; }





    }
}