using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProject_Arif.Startup))]
namespace MVCProject_Arif
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
