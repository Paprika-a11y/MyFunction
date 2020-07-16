using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionForTest;

namespace FnReadSecretFromVault
{
    public class HttpTriggerFunction
    {
        private readonly IRepository _repository;

        public HttpTriggerFunction(IRepository repository)
        {
            _repository = repository;
        }

        [FunctionName("HttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var someData = _repository.GetData();
            return new OkObjectResult(someData);
        }
    }
}

