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

namespace BlockbusterRentals.Controllers
{
    public class SearchResultsController : Controller
    {


       


        // GET: SearchResults
        public ActionResult Index()
        {
            Console.WriteLine("Starting query");
            SolrNet.Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n1");

            //Startup.Init<SearchResult>("http://localhost:8983/solr/blockbuster_shard1_replica_n1");
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SearchResult>>();
            var result = solr.Query(new SolrQuery("*:*"));
            Debug.WriteLine("Type\n\n\n" + result.GetType()); // returns SolrNet.SolrQueryResults`1[SolrTesting.Movie]
            foreach (var r in result)
            {
                Debug.WriteLine("REsult: " + r.Title);
            } 
            return View(result);
        }
    }
}

