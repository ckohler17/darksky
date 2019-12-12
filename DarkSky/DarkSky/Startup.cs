using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DarkSky.Startup))]
namespace DarkSky
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
