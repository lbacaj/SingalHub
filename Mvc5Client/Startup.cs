using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5Client.Startup))]
namespace Mvc5Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
