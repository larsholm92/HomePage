using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sondergaardholm.Startup))]
namespace sondergaardholm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
