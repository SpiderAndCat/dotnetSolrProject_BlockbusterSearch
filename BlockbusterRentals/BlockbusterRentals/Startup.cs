using Microsoft.Owin;
using Owin;
using BlockbusterRentals.Models;
using Microsoft.Extensions.DependencyInjection;
using SolrNet;
using System;

[assembly: OwinStartupAttribute(typeof(BlockbusterRentals.Startup))]
namespace BlockbusterRentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Add SolrNet services
            var solrUrl = "http://localhost:8983/solr/blockbuster_shard1_replica_n1"; // Solr URL
            services.AddSolrNet(solrUrl); // Register Solr connection with DI container
            Console.Write("hi");
        }
    }

}
