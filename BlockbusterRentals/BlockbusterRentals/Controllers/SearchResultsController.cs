using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using BlockbusterRentals.Models;
using CommonServiceLocator;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Diagnostics;
using BlockbusterRentals.ViewModels;
using Newtonsoft.Json.Linq;

namespace BlockbusterRentals.Controllers
{
    public class SearchResultsController : Controller
    {





        // GET: SearchResults
        public ActionResult Index()
        {
           

            SearchAgainViewModel display = new SearchAgainViewModel
            {
                SearchResult = new SolrQueryResults<BlockbusterRentals.Models.SearchResult> { },
                SearchQuery = new SearchQuery
                {
                    queryString = "",
                    queryType = 0
                }

            };
            return View(display);
        }

        

        public ActionResult Search(SearchAgainViewModel again)
        {
            Console.WriteLine("Starting query");
            //Debug.WriteLine("Query: " + q + f);

            Console.WriteLine("Starting query");
            //SolrNet.Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n2");
            Console.WriteLine("Starting query");
            if (!ServiceLocator.IsLocationProviderSet)
            {
                SolrNet.Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n2");
            }
            //Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n1");


            //0: Everything
            //1: Title (Title)
            //2: Description (Plot)
            //3: Release Date (Released)
            //4: Genre (Genre)
            //5: Cast (Actors)
            //6: Rating /5 (imbdRating)
            string field = "*";
            string query = again.SearchQuery.queryString;
            switch (again.SearchQuery.queryType)
            {
                case 0:
                    field = "*";
                    break;
                case 1:
                    field = "Title";
                    break;
                case 2:
                    field = "Plot";
                    break;
                case 3:
                    field = "Released";
                    break;
                case 4:
                    field = "Genre";
                    break;
                case 5:
                    field = "Actors";
                    break;
                case 6:
                    field = "imdbRating";
                    break;
                default:
                    field = "*";
                    break;
            }



            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchResult>>();
            var searchFor = "";

            if (field == "*")
            {
                searchFor = $"*{query}*";
            }
            else if (field == "imdbRating")
            {
                searchFor = $"imdbRating:{query}.*";
            }
            else
            {
                searchFor = $"{field}:*{query}*";

            }
            Debug.WriteLine("\n\n\n\n\n```" + searchFor + "```");
            var result = solr.Query(new SolrQuery(searchFor));
            Debug.WriteLine("Type\n\n\n" + result.GetType()); // returns SolrNet.SolrQueryResults`1[SolrTesting.Movie]
            foreach (var r in result)
            {
                Debug.WriteLine("REsult: " + r.imdbRating);
            }

            SearchAgainViewModel display = new SearchAgainViewModel
            {
                SearchResult = result,
                SearchQuery = new SearchQuery
                {
                    queryString = again.SearchQuery.queryString,
                    queryType = again.SearchQuery.queryType
                }

            };
            return View(display);
        }
    }
}

