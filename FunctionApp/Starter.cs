using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using software_design_and_architecture_3_colleges;

namespace FunctionApp
{
    public static class Starter
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = TriggerProgramMethod(name);

            return new OkObjectResult(responseMessage);
        }

        private static string TriggerProgramMethod(string name)
        {
            string output = "";
            Movie movie = new Movie("Matthijs de dinosaurus");
            MovieScreening movieScreening = new MovieScreening(movie, DateTime.Now.AddDays(4), 10);

            output += movie.ToString() + "\n";
            output += movieScreening.ToString() + "\n";

            Order order1 = new Order(1, true);
            Order order2 = new Order(2, false);

            // Order 1

            // 12 + 0 + 10 = 22,-

            MovieTicket movieTicket1 = new MovieTicket(3, 11, true, movieScreening);
            MovieTicket movieTicket2 = new MovieTicket(3, 12, false, movieScreening);
            MovieTicket movieTicket3 = new MovieTicket(3, 13, false, movieScreening);

            order1.AddSeatReservation(movieTicket1);
            order1.AddSeatReservation(movieTicket2);
            order1.AddSeatReservation(movieTicket3);

            output += "Price order 1: " + order1.CalculatePrice();

            // Order 2

            // (13 + 0 + 10 + 0 + 10 + 0 + 13 + 0) * 0.9 = 41,4

            MovieTicket movieTicket4 = new MovieTicket(7, 11, true, movieScreening);
            MovieTicket movieTicket5 = new MovieTicket(7, 12, false, movieScreening);
            MovieTicket movieTicket6 = new MovieTicket(7, 13, false, movieScreening);
            MovieTicket movieTicket7 = new MovieTicket(4, 11, true, movieScreening);
            MovieTicket movieTicket8 = new MovieTicket(4, 12, false, movieScreening);
            MovieTicket movieTicket9 = new MovieTicket(4, 13, false, movieScreening);
            MovieTicket movieTicket10 = new MovieTicket(5, 1, true, movieScreening);
            MovieTicket movieTicket11 = new MovieTicket(5, 2, false, movieScreening);

            order2.AddSeatReservation(movieTicket4);
            order2.AddSeatReservation(movieTicket5);
            order2.AddSeatReservation(movieTicket6);
            order2.AddSeatReservation(movieTicket7);
            order2.AddSeatReservation(movieTicket8);
            order2.AddSeatReservation(movieTicket9);
            order2.AddSeatReservation(movieTicket10);
            order2.AddSeatReservation(movieTicket11);

            output += "Price order 2: " + order2.CalculatePrice();

            // Export

            order1.Export(TicketExportFormat.PLAINTEXT);
            order1.Export(TicketExportFormat.JSON);

            return output;
        }
    }
}
