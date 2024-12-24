using Microsoft.AspNetCore.Mvc;
using MyApiNight.WebUI.Dtos;
using MyApiNight.WebUI.Dtos.Category;
using MyApiNight.WebUI.Dtos.Features;
using MyApiNight.WebUI.Dtos.Writers;
using Newtonsoft.Json;

namespace MyApiNight.WebUI.Controllers
{
    public class AdminBookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBookController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7035/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>
                    (jsonData);
                return View(values);

            }
            return View();
        }

        public async Task<IActionResult> AdminFeatures()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7035/api/Feature");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>
                    (jsonData);
                return View(values);

            }
            return View();
        }

        public async Task<IActionResult> AdminProducts()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7035/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>
                    (jsonData);
                return View(values);

            }
            return View();
        }

        public async Task<IActionResult> AdminWriters()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7035/api/Writer");
            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWriterDto>>
                    (jsonData);
                return View(values);

            }
            return View();
        }


    }
}
