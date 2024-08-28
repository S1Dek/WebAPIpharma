using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string apiUrl = "http://localhost:5000/api/scraper/scrape"; // URL do API

            string urlToScrape = "https://www.pharmaquinone.com/"; // Adres strony do pobrania danych

            using HttpClient client = new HttpClient();

            // Tworzymy żądanie GET z URL jako parametrem
            var response = await client.GetAsync($"{apiUrl}?url={Uri.EscapeDataString(urlToScrape)}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Pobrane dane:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Błąd: {response.StatusCode}");
            }
        }
    }
}
