using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SolrNet;
using SolrNet.Impl;
using System.Diagnostics;
using CommonServiceLocator;
using SolrNet.Attributes;

namespace SolrTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Startup.Init<Movie>("http://localhost:8983/solr/blockbuster_shard1_replica_n1");
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Movie>>();
            var result = solr.Query(new SolrQuery("Plot:*"));
            Debug.WriteLine(result.GetType()); // returns SolrNet.SolrQueryResults`1[SolrTesting.Movie]


        }

        
    }

    public class Movie
    {
        [SolrField("Title")]
        public string Title { get; set; }

        [SolrField("Released")]

        public string Released { get; set; }


        [SolrField("Runtime")]
        public string Runtime { get; set; }

        [SolrField("Genre")]

        public string Genre { get; set; }


        [SolrField("Actors")]

        public string Actors { get; set; }

        [SolrField("Plot")]

        public string Plot { get; set; }

        [SolrField("imdbId")]

        public string imdbId { get; set; }


        [SolrField("imdbRating")]

        public string imdbRating { get; set; }
    }
}
