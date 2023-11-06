using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartyProductMVC.Startup))]
namespace PartyProductMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
