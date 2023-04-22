using BlockbusterRentals.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolrNet;

namespace BlockbusterRentals.ViewModels
{
    public class SearchAgainViewModel
    {
        public SearchQuery SearchQuery { get; set; }
        public SolrQueryResults<BlockbusterRentals.Models.SearchResult> SearchResult { get; set; }
    }
}