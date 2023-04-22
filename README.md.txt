## Solr Setup
### (1) Create the new dataset Solr Collection
`bin\solr create -c blockbuster -s 2 -rf 2`
### (2) Index the provided Movie Data; run this command in your Solr doqnload directory
java -jar -Dc=blockbuster -Dauto example\exampledocs\post.jar C:\Users\<your_user>\Desktop\movieData\*.json
