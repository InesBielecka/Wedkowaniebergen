using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wedkowaniebergen.Startup))]
namespace Wedkowaniebergen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
