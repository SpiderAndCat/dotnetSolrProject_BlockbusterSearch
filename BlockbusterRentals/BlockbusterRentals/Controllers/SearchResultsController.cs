




using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using BlockbusterRentals.Models;

namespace BlockbusterRentals.Controllers
{
    public class SearchResultsController : Controller
    {

        // Set up ElasticSearch

        ElasticClient client = new ElasticClient(new ConnectionSettings(new Uri("http://localhost:9200"))
            .DefaultIndex("Index/movieData"));



        // GET: SearchResults
        public ActionResult Index()
        {
            Console.WriteLine("Starting query");
            // Structure teh search query
            var searchResponse = client.Search<SearchResult>(s => s
            .Query(q => q
                .Match(m => m
                    .Field(f => f.Title)
                    .Query("Her Wicked Ways")
                    )
                )
            );

            // Extract the search results into the MVC domain model SearchResult
            List<SearchResult> results = new List<SearchResult>();
            Console.WriteLine("Showing hits");

            foreach (var hit in searchResponse.Hits)
            {
                Console.WriteLine("Hit:");

                results.Add(hit.Source);
            }

            return View(results);
        }
    }
}

