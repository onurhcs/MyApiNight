using Microsoft.AspNetCore.Mvc;
using MyApiNight.WebUI.Dtos.Writers;
using Newtonsoft.Json;
using System.Text;

namespace MyApiNight.WebUI.Controllers
{
    public class WritersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WritersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WritersList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7035/api/Writer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWriterDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateWriters()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWriters(CreateWriterDto createWritersDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWritersDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var reponseMessage = await client.PostAsync("https://localhost:7035/api/Writers", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WritersList");

            }
            return View();
        }

        public async Task<IActionResult> DeleteWriters(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync("https://localhost:7035/api/Writers?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WritersList");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWriters(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7035/api/Writers/GetWriters?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateWriterDto>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateWriters(UpdateWriterDto updateWritersDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWritersDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var reponseMessage = await client.PutAsync("https://localhost:7035/api/Writers", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WritersList");

            }
            return View();
        }
    }
}
