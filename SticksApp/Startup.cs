using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SticksApp.Startup))]
namespace SticksApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
