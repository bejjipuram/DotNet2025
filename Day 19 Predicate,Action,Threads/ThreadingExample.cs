using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CAP2025.Day_19
{
    public class ThreadingExample
    {
        public static async Task Main(string[] args)
        {
            await CallMethod();

            Console.WriteLine("Main method completed");
            Console.ReadLine(); // keeps console open
        }

        public static void Task1()
        {
            Console.WriteLine("For Loop for Odd started");
            for (int i = 1; i < 100; i += 2)
            {
                Console.Write(i + " ");
                Thread.Sleep(100);
            }
            Console.WriteLine("\n");
        }

        public static void Task2()
        {
            Console.WriteLine("For Loop for Even started");
            for (int i = 0; i < 100; i += 2)
            {
                Console.Write(i + " ");
                Thread.Sleep(100);
            }
        }

        public static async Task AsyncMethod()
        {
            Console.WriteLine("Task started");
            await Task.Delay(3000);
            Console.WriteLine("Task is completed after 3 seconds");
        }

        public static async Task CallMethod()
        {
            string result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");

            Console.WriteLine(result);

            await AsyncMethod();
        }

        public static async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
