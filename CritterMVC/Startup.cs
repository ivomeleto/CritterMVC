using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CritterMVC.Startup))]
namespace CritterMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
