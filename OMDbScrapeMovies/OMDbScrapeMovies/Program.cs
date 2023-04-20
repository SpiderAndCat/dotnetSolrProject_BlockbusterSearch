using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace MovieScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiUrl = "http://www.omdbapi.com/?i=tt{0:0000000}&apikey=YOUR_API_KEY";

            int index = 1000010;
            int numMovies = 890;
            // Completed 900 movies starting at index 100,000

            //Next, 999 movies starting at 415000

            //Then, 999 movies starting at 1015000

            //Last, 999 movies starting at 

            // create a list to hold the movie data
            List<Movie> movies = new List<Movie>();

            // loop through the first 100 official IMDb ids and fetch movie data
            for (int i = index; i <= index + numMovies; i++)
            {
                string imdbId = i.ToString("0000000");
                string url = string.Format(apiUrl, imdbId);
                Console.WriteLine(i);

                // create a web request to the OMDb API
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                // get the web response from the API
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // read the response stream
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            // parse the JSON data into a Movie object
                            string jsonData = reader.ReadToEnd();
                            Movie movie = JsonConvert.DeserializeObject<Movie>(jsonData);

                            // add the movie to the list
                            movies.Add(movie);
                        }
                    }
                }
            }

            // create a directory to store the movie data files
            string dataDir = "MovieData";
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // save each movie's data to a separate JSON file
            foreach (Movie movie in movies)
            {
                string fileName = Path.Combine(dataDir, $"{movie.ImdbId}.json");
                string jsonData = JsonConvert.SerializeObject(movie, Formatting.Indented);
                File.WriteAllText(fileName, jsonData);
            }

            Console.WriteLine($"Scraped and saved {movies.Count} movies.");
        }
    }

    class Movie
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Released")]
        public string Released { get; set; }

        [JsonProperty("Runtime")]
        public string Runtime { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Actors")]
        public string Actors { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
    }
}
