using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Test
{
    public static class Create
    {
        [FunctionName("Create")]
        public static async Task Run([QueueTrigger("pedido-queue", Connection = "AzureWebJobsStorage")]string queueItem, ILogger log)
        {
            log.LogInformation($"Function PedidoQueue foi iniciada.");

            var strSQL = string.Empty;
            var identifier = Guid.NewGuid().ToString();
            var data = JsonConvert.DeserializeObject<List<Pedido>>(queueItem); 

            foreach (var item in data)
            {
                strSQL += $"INSERT INTO Pedido (Identifier, [Name], Price) VALUES ('{ identifier }', '{ item.Name }', '{ item.Price }') ";
            }

            var strConn = Environment.GetEnvironmentVariable("sqlconn");

            using (var conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand(strSQL, conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        
            log.LogInformation($"Function PedidoQueue foi finalizada.");
        }
    }
}
