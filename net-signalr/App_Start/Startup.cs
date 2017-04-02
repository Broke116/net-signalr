using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(net_signalr.App_Start.Startup))]

namespace net_signalr.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}