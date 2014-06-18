using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using SignalREngine;

[assembly: OwinStartup(typeof(SignalREngine.Startup))]

namespace SignalREngine
{
    public class Startup
    {
        static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private static IDisposable _runningInstance;
        private static string _url;
        // Your startup logic
        public static void StartServer(string url = null)
        {
            _url = url;
            var cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(RunSignalRServer, TaskCreationOptions.LongRunning
                                  , cancellationTokenSource.Token);
            Console.WriteLine("Url provided: {0}", _url);
        }

        private static void RunSignalRServer(object task)
        {
            //Set a URL if none is there
            if (String.IsNullOrEmpty(_url))
                _url = "http://localhost:8080";

            Console.WriteLine("Server running on {0}", _url);

            _runningInstance = WebApp.Start(_url);
        }

        public static void StopServer()
        {
            _cancellationTokenSource.Cancel();
            _runningInstance.Dispose();
        }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(CorsOptions.AllowAll);
            //app.MapSignalR();
            
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                };

                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
             
        }
    }
}
