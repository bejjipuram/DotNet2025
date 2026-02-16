using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CAP2025.Day_38_ScenarioBasedQ
{
    class ThreadingExample
    {
        // Reusable HttpClient (best practice)
        private static readonly HttpClient _http = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            await FetchJsonAsync();
        }

        private static async Task FetchJsonAsync()
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/todos";

                // Real async I/O call
                string json = await _http.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                {
                    Console.WriteLine("No Result");
                    return;
                }

                Console.WriteLine(json);
                Console.WriteLine("Status: Success");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HTTP Error: " + ex.Message);
                Console.WriteLine("Status: Failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Status: Failed");
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }
    }
}
