using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MagniFinance.Web.Startup))]

namespace MagniFinance.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
