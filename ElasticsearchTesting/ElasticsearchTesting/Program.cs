using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nest;
using System.Diagnostics;
using System.Reflection;


namespace ElasticsearchTesting
{
    public class Person
    {

        public int Id { get; set; }

        public string Firstname { get; set; }


        public string Lastname { get; set; }

     
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            ElasticClient client = new ElasticClient(new ConnectionSettings()
                .DefaultIndex("index_two")
                .RequestTimeout(TimeSpan.FromSeconds(30))
            );
            Debug.WriteLine("Begin \n\n" );

        if(client.Indices.Exists("my_index").Exists)
            {
                Debug.WriteLine("my_index index exists \n\n");

            }
        else
            {
                Debug.WriteLine("my_index index No exists \n\n");

            }

            if (client.Indices.Exists("index_two").Exists)
            {
                Debug.WriteLine("index_two index exists \n\n");

            }
            else
            {
                Debug.WriteLine("index_two index No exists \n\n");

            }
            /*
            var createIndexResponse = client.Indices.Create("index_two", c => c
              
                    .Map<Person>(m => m
                        .Properties(ps => ps
                            .Text(t => t
                                .Name(p => p.Firstname)
                            )
                            .Text(t => t
                                .Name(p => p.Lastname)
                            )

                        )
                    )
                
            );
            */
            if (client.Indices.Exists("index_two").Exists)
            {
                Debug.WriteLine("index_two indexs exists \n\n");

            }
            else
            {
                Debug.WriteLine("index_two index No exists \n\n");

            }






            var searchResult = new Person
            {
               
                Id = 1,
                Firstname = "Spider-Man",
                       Lastname = "Hi"

             
            };
            var indexResponse = client.IndexDocument(searchResult);

            if(!indexResponse.IsValid)
            {
                Debug.WriteLine("Index ERROR!\n\n" + indexResponse.DebugInformation);


            } else
            {
                Debug.WriteLine("Index Success!\n\n");

            }


            var searchResponse = client.Search<Person>(s => s
                .AllIndices()
                .Query(q => q
                    .MatchAll()
                )
            );
            Debug.WriteLine("Results: \n\n");

            foreach (var hit in searchResponse.Hits)
            {
                Debug.WriteLine("Hit:");

                Debug.WriteLine(hit.Source.Firstname);

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
