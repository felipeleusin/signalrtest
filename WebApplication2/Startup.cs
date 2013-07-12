using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Nancy;
using Owin;

namespace WebApplication2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConf = new HubConfiguration()
            {
                EnableCrossDomain = true,
                EnableDetailedErrors = true
            };

            app.MapHubs(hubConf).UseNancy(new DefaultNancyBootstrapper());
        }
    }

    public class SimpleHub : Hub
    {
        public void Message(string message)
        {
            Clients.All.message(message);
        }
    }

    public class PingModule : NancyModule
    {
        public PingModule()
        {
            Get["/"] = _ => "Ping!";
        }
    }
}