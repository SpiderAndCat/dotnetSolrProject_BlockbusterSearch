using BlockbusterRentals.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockbusterRentals.ViewModels
{
    public class SearchAgainViewModel
    {
        public SearchQuery SearchQuery { get; set; }
        public SolrQueryResults<BlockbusterRentals.Models.SearchResult> SearchResult { get; set; }
    }
}