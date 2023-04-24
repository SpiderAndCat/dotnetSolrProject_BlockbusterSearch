![homepage](https://user-images.githubusercontent.com/130514366/233876718-50f12ca1-9c64-40b3-821d-0327be8e4807.PNG)
# Welcome To Blockbuster
**BlockBuster Search** brings our catalogue of classic & new movies to your fingertips.
Search by movie Title, Cast, Ratings, and more.

![cast search](https://user-images.githubusercontent.com/130514366/233876725-1bd122cd-005c-463b-a3bc-4c5367e79562.PNG)

![rating search](https://user-images.githubusercontent.com/130514366/233876731-747f83c7-0aeb-4fc0-8f0c-038ce04f5882.PNG)

# For Users / Testing

## Solr Setup

### Download Java for Windows (if you don't already have it)
Download Java from www.java.com \n
Follow the prompts for download and install of Java for Windows

### Download Solr for Windows (if you don't already have it)
Download `Solr 8.11.2` Binary Release `solr-8.11.2.zip` for Windows.\nWhen the download is complete, unzip the file, and open the main directory in terminal: `cd solr-8.11.2\solr-8.11.2`

### (1) Start the Solr localhost server
It will run by default on `localhost:8983`\n
Start by running: `bin\solr start`

### (2) Create the new Blockbuster Solr Collection (will migrate Indexed data later)
(This part will not work if you do not have Java installed)\n 
In your terminal, run the following commands, and follow the prompts as they appear:\n
(1) `bin\solr create -c blockbuster -s 1 -rf 1`
// We are doing 1 shard and replica, for this demo. \n
// For ease of use,  will prevent potential bugs -- when trying to restart the Solr service, where some replicas / ports may be inactive, thereby not permitting search
\n\n

### (3) You will manually need to set each Column to string before indexing

### 4) Index the provided Movie Data; run this command in your Solr doqnload directory
java -jar -Dc=blockbuster -Dauto example\exampledocs\post.jar C:\Users\<your_user>\Desktop\movieData\*.json

### (5) Shutdown server after use
`bin\solr stop -all`

### (6) Resume server
`bin\solr start -c -p 8983 -s example\cloud\node1\solr`

**troubleshoot:** if errors are encoutered, try to delete all replicas on second port. have 1 replica per shard

## ASP.NET App Setup
### (1) Open the Visual Studio Project in the GitHub repo by double clicking the file `BlockbusterRentals\BlockbusterRentals.sln`
All Package dependancies should be included in the Git repo. If not, you will need to use PM> to: `install-package SolrNet`

###
**troubleshoot:** On some machines, the Solr dataset migration may not line up to the same Node naming convention. This will cause the Solr file migration, and the Visual Studio code, to be out of sync.

Make sure to change 


### DISCLAIMER: 
The movie data was gathered with the OMDb API. Movie data is not guarenteed to be accurate, and it has not been screened for inappropriate or offensive content. There are about 3,000 movie entries, since many of the several-thousand Movie records retreieved from the OMDb database were not official IMDb movie record Ids -- ie, Movie Ids are random, and some Id numbers do not pertain to an actual movie.
