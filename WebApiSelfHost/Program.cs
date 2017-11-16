using System;
using Microsoft.Owin.Hosting;

namespace WebApiSelfHost
{
  class Program
  {
    static void Main(string[] args)
    {
      const string baseAddress = "http://localhost:9000/";

      // Start OWIN host 
      using (WebApp.Start<Startup>(baseAddress))
      {
        Console.WriteLine("A controller is hosted on URL:" + baseAddress);
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
      }
    }
  }
}
