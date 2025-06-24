using System.Text;
using System.Text.Json;
namespace MultilayeredAsyncOperations
{
    internal class Program
    {
        static Task<int>MethodA()
        {
            return Task.Run(() =>
                {
                    Console.WriteLine("Simulating CPU bound activities");
                    int total = 0;
                    for (int i = 0; i < 100000; i++)
                        total += i;
                    return total % 10 + 1;
                });
        }
        static async Task<string> MethodB()
        {
            int userID = await MethodA();
            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:5000/data.json";
                Console.WriteLine($"Fetching user details from {url}");
                string response= await client.GetStringAsync(url);
                return response;
            }
        }
        static async Task<string> MethodC()
        {
            string json = await MethodB(); 

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            StringBuilder resultBuilder = new StringBuilder();
            if (root.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement user in root.EnumerateArray())
                {
                    string name = user.GetProperty("name").GetString();
                    string email = user.GetProperty("email").GetString();
                    resultBuilder.AppendLine($"Name: {name}, Email: {email}");
                }
            }
            else
            {
                resultBuilder.AppendLine("Expected an array but got an object.");
            }
            return resultBuilder.ToString();
        }
        static async Task Main(string[]args)
        {
            Console.WriteLine("Starting multi-layered async workflow...\n");
            string finalResult = await MethodC();
            Console.WriteLine($"\nFinal extracted result:\n{finalResult}");
            Console.ReadKey();
        }
    }
}
