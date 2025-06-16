using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


//--Source: https://www.hanselman.com/blog/parallelforeachasync-in-net-6
//--Source: https://www.meziantou.net/getting-all-exceptions-thrown-from-parallel-foreachasync.htm
//--Source: https://www.hanselman.com/blog/category/dotnetcore | side effect

namespace ThreadTask.ParallelAsync
{
    public class ParallelAsyncExperiment
    {

        public record GitHubUser(string Name, string Bio);
        public static async Task DoExperiment()
        {
            
            var userHandler = new []
            { 
                "users/okyrylchuk",
                "users/shanselman",
                "users/jaredpar",
                "users/davidfowl"
            };

            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.github.com"),    
            };

            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNet", "6"));

            ParallelOptions poptions = new()
            {
                MaxDegreeOfParallelism = 3 // Limit to 3 concurrent requests    
            };

            await Parallel.ForEachAsync(userHandler, poptions, async (uri, token) =>
            {


                var user = await client.GetFromJsonAsync<GitHubUser>(uri, token);
                
                Console.WriteLine($"Name: {user.Name}\nBio: {user.Bio}\n");
                /*
                try
                {
                    var response = await client.GetAsync($"/{user}", token);
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync(token);
                    Console.WriteLine($"User: {user}, Response Length: {content.Length}");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error fetching user {user}: {e.Message}");
                }*/

            }); 

            /*
            // This is a placeholder for the parallel async experiment code.
            // You can implement your parallel processing logic here.
            Console.WriteLine("Running Parallel Async Experiment...");
            
            // Example of a simple parallel task
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"Processing item {i} on thread {Environment.CurrentManagedThreadId}");
                Task.Delay(100).Wait(); // Simulate some work
            });
            
            */

            // Example of using async/await in parallel processing
            Console.WriteLine("Parallel Async Experiment completed.");
        }

    }
}
