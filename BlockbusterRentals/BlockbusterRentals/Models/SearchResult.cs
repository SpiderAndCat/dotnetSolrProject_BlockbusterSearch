using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SolrNet.Attributes;

namespace BlockbusterRentals.Models
{
    public class SearchResult
    {
        [SolrField("Title")]
        public string Title { get; set; }

        [SolrField("Released")]
        [Display(Name = "Release Date")]
        public string Released { get; set; }

        [SolrField("Runtime")]
        public string Runtime { get; set; }

        [SolrField("Genre")]
        public string Genre { get; set; }

        [SolrField("Actors")]
        [Display(Name = "Cast")]
        public string Actors { get; set; }

        [Display(Name = "Description")]
        [SolrField("Plot")]

        public string Plot { get; set; }

        [SolrField("imdbId")]
        public string imdbId { get; set; }

        [SolrField("imdbRating")]
        [Display(Name = "Rating / 5")]
        public string imdbRating { get; set; }





    }
}

