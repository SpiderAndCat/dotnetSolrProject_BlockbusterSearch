using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nest;
using System.Diagnostics;


namespace ElasticsearchTesting
{
    public class SearchResult
    {
        public string Title { get; set; }


        public string Released { get; set; }

        public string Runtime { get; set; }

        public string Genre { get; set; }



        public string Actors { get; set; }


        public string Plot { get; set; }

        public string imdbId { get; set; }



        public string imdbRating { get; set; }
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            ElasticClient client = new ElasticClient(new ConnectionSettings().DefaultIndex("searchresult"));
            Debug.WriteLine("Index names! \n\n" );
          

            var searchResult = new SearchResult
            {
                      Title = "Spider-Man",
                       Released = "Jan 1 2002",
                        Runtime = "180 mins",
                        Genre = "Superhero",
                        Actors = "Jordan Ash, Kayla Carrera, Kira Croft, Tony DeSergio",
                        Plot = "There was a guy",
                        imdbId = "tt1000018",
                        imdbRating = "4"

             
            };

            var indexResponse = client.IndexDocument(searchResult);

            if(!indexResponse.IsValid)
            {
                Debug.WriteLine("Index ERROR!\n\n");


            } else
            {
                Debug.WriteLine("Index Success!\n\n");

            }


            var searchResponse = client.Search<SearchResult>(s => s
                .Query(q => q
                    .MatchAll()
                )
            );
            Debug.WriteLine("Results: \n\n");

            foreach (var hit in searchResponse.Hits)
            {
                Debug.WriteLine("Hit:");

                Debug.WriteLine(hit.Source.Title);

            }

            Debug.WriteLine("\n\nend of results\n\n");

        }
    }
}

/*
 * var searchResults = new List<SearchResult>
            {

                new SearchResult
                {
                      Title = "Spider-Man",
                       Released = "Jan 1 2002",
                        Runtime = "180 mins",
                        Genre = "Superhero",
                        Actors = "Jordan Ash, Kayla Carrera, Kira Croft, Tony DeSergio",
                        Plot = "There was a guy",
                        imdbId = "tt1000018",
                        imdbRating = "4"

                },
                new SearchResult
                {

                    Title = "Spider-Man 2",
                       Released = "Jan 1 2010",
                        Runtime = "160 mins",
                        Genre = "Superhero",
                        Actors = "Jordan Ash, Kayla Carrera, Kira Croft, Tony DeSergio",
                        Plot = "There was a guy again",
                        imdbId = "tt1000018",
                        imdbRating = "5"

                },
                new SearchResult
                {

                    Title = "Batman",
                       Released = "Mar 1 2010",
                        Runtime = "60 mins",
                        Genre = "Superhero",
                        Actors = "Jordan Ash, Kayla Carrera, Kira Croft, Tony DeSergio",
                        Plot = "There was a new guy again",
                        imdbId = "tt1000018",
                        imdbRating = "2"

                },
                new SearchResult
                {

                    Title = "Bruce Almighty",
                       Released = "Mar 1 2010",
                        Runtime = "60 mins",
                        Genre = "Comedy",
                        Actors = "Jim Carey, Kayla Carrera, Kira Croft, Tony DeSergio",
                        Plot = "There was a guy who thought he could do it all",
                        imdbId = "tt1000018",
                        imdbRating = "4"

                }
            };
 * */
