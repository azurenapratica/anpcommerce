using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AzureNaPratica
{
    public static class AddQueue
    {
        [FunctionName("AddQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, 
            [Queue("pedido-queue", Connection = "AzureWebJobsStorage")]IAsyncCollector<string> queueItem, 
            ILogger log)
        {
            log.LogInformation("Function de novo Pedido inciada."); 

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync(); 
            await queueItem.AddAsync(requestBody); 

            log.LogInformation("Function de novo Pedido finalizada."); 

            return new OkObjectResult($"Obrigado! Seu pedido ja esta sendo processado.");
        }
    }
}
