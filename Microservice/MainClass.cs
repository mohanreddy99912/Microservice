using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace Microservice
{
    public class MainClass
    {
        private const string BaseAddress = "http://*:5855";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("Microservice Started...");
                string readVal = Console.ReadLine();
                while (string.IsNullOrEmpty(readVal))
                {
                    Thread.Sleep(5000);
                    readVal = Console.ReadLine();
                }
            }
        }
    }

}
