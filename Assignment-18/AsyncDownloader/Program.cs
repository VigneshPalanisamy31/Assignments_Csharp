namespace AsyncDownloader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.w3schools.com/cs/cs_enums.php";
            try
            {
                string content = await DownloadContentAsync(url);
                Console.WriteLine("Downloaded Content:\n");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.ReadKey();
        }
        static async Task<string> DownloadContentAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Downloading from: " + url);
                string result = await client.GetStringAsync(url);
                Console.WriteLine("Download complete.\n");
                return result;
            }
        }
    }

}

