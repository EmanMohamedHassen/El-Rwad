using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartGate.ElRwad.Portal.Startup))]
namespace SmartGate.ElRwad.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
