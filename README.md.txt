## Solr Setup
### (1) Create the new dataset Solr Collection
`bin\solr create -c blockbuster -s 2 -rf 2`

### (2) You will manually need to set each Column to string before indexing

### (3) Index the provided Movie Data; run this command in your Solr doqnload directory
java -jar -Dc=blockbuster -Dauto example\exampledocs\post.jar C:\Users\<your_user>\Desktop\movieData\*.json


## Solr .NET Integration
`PM> install-package SolrNet`
```
using SolrNet;
//...

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
```

### (4) Shutdown server after use
`bin\solr stop -all`

### (5) Resume server
`bin\solr start -c -p 8983 -s example\cloud\node1\solr`

troubleshoot: delete all replicas on second port. have 1 replica per shard