using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiSelfHost
{
  [RoutePrefix("api/Values")]
  public class ValuesController : ApiController
  {
    [Route("GetValue")]
    public string GetValue(int id)
    {
      Console.WriteLine("Begin GetValue(" + id + ")");
      Thread.Sleep(5000);
      Console.WriteLine("End GetValue(" + id + ")");
      return "value" + id;
    }

    [Route("GetValueAsync")]
    public async Task<string> GetValueAsync(int id)
    {
      Console.WriteLine("Begin GetValueAsync("+id+")");
      await Task.Delay(5000);
      Console.WriteLine("End GetValueAsync(" + id + ")");
      return await Task.FromResult("value" + id);
    }
  }
}
