# AspNetWebApi2WithAsync
Using of async/await in ASP.NET Web API 2

The repo contains two projects:

WebApiSelfHost project contains ASP.NET Web API 2 self hosted server with two methods:
 - GetValue() returns value synchroniously after Sleep operation;
 - GetValueAsync() returns value asynchroniously after await operation.
 
 WebApiClient project contains console application which invokes server's methods in many tasks.
 
 There is a different in two methods invocation behaviour.
