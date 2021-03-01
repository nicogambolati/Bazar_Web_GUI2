using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bazar_Web.Startup))]
namespace Bazar_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
