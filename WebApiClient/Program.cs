using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Request GetValue...");
      RunClients("GetValue", 40);
      Console.WriteLine("All tasks completed");

      Console.WriteLine("\nPress any key");
      Console.ReadLine();

      Console.WriteLine("Request GetValueAsync...");
      RunClients("GetValueAsync", 40);
      Console.WriteLine("All tasks completed");

      Console.WriteLine("\nPress any key");
      Console.ReadLine();
    }

    private static void RunClients(string actionName, int tasksCount)
    {
      var tasks = Enumerable.Range(1, tasksCount).Select(i => ResultTask(i, actionName)).ToList();
      while (tasks.Count > 0)
      {
        var array = tasks.ToArray();
        var i = Task.WaitAny(array);
        var task = array[i];
        Console.WriteLine(task.Result);
        tasks.Remove(task);
      }
    }

    private static async Task<string> ResultTask(int id, string actionName)
    {
      var client = new HttpClient {BaseAddress = new Uri("http://localhost:9000/api/Values/")};

      var resp = await client.GetAsync($"{actionName}?id={id}");
      //var resp = await client.GetAsync("GetValue?id=" + id);

      resp.EnsureSuccessStatusCode();
      return await resp.Content.ReadAsStringAsync();
    }
  }

}
