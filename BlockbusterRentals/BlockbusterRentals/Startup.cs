using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlockbusterRentals.Startup))]
namespace BlockbusterRentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
