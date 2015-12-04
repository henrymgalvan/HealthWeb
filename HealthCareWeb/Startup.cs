using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthCareWeb.Startup))]
namespace HealthCareWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
