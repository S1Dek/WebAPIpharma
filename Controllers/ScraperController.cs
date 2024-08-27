using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;

namespace WebScraperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ScraperController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("scrape")]
        public async Task<IActionResult> Scrape([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
                return BadRequest("URL cannot be empty");

            var response = await _httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(response);

            // Przykład: Pobieranie elementu o ID "content" ze strony
            var contentNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@id='content']");
            var content = contentNode != null ? contentNode.InnerHtml : "Nie znaleziono danych";

            return Ok(new { Content = content });
        }
    }
}