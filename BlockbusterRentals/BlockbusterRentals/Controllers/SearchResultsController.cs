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
            Console.WriteLine("Starting query");
            if (!ServiceLocator.IsLocationProviderSet)
            {
                SolrNet.Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n2");
            }
            //Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n1");
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchResult>>();
            var result = solr.Query(new SolrQuery("*:*"));
            Debug.WriteLine("Type\n\n\n" + result.GetType()); // returns SolrNet.SolrQueryResults`1[SolrTesting.Movie]
            foreach (var r in result)
            {
                Debug.WriteLine("REsult: " + r.Title);
            }

            SearchAgainViewModel display = new SearchAgainViewModel
            {
                SearchResult = result,
                SearchQuery = new SearchQuery
                {
                    queryString = "",
                    queryType = 1
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





            // Basic Search
            //var result = solr.Query(new SolrQuery(searchFor));

            if (field == "*")
            {
                searchFor = query;

                // More advanced
                // searchFor = $"{field}:{query}";

                // Basic Search
                var result = solr.Query(new SolrQuery(searchFor));



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
            else if(field != "Genre")
            {

                // More advanced
                searchFor = $"{field}:{query}";

                // Basic Search
                var result = solr.Query(new SolrQuery(searchFor));



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
            else
            {
                //Facet Search
                var result = solr.Query(SolrQuery.All, new QueryOptions
                {
                    Rows = 0,
                    Facet = new FacetParameters
                    {
                        Queries = new[] { new SolrFacetFieldQuery(field) }
                    }

                });

                foreach(var facet in result.FacetFields[field])
                {
                    Debug.WriteLine("{0}: {1}", facet.Key, facet.Value);
                    Debug.WriteLine(result.FacetFields[field].GetType());
                    Debug.WriteLine(facet.GetType());
                    Debug.WriteLine(facet.ToString());


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
}

