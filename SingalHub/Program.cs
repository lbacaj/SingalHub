using SignalREngine;
using System;

namespace SingalHub
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:8080";

            

            try
            {
                Startup.StartServer();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Startup.StopServer();
            }

        }

       
    }


    
}
