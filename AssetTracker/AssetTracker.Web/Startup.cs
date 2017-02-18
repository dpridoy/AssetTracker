using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetTracker.Web.Startup))]
namespace AssetTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
