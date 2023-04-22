using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterRentals.Models
{
    public class SearchQuery
    {
        public string queryString { get; set; }
        public int queryType { get; set; }
        //0: Everything
        //1: Title (Title)
        //2: Description (Plot)
        //3: Release Date (Released)
        //4: Genre (Genre)
        //5: Cast (Actors)
        //6: Rating /5 (imbdRating)

    }
}