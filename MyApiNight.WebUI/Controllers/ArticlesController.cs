using Microsoft.AspNetCore.Mvc;
using MyApiNight.WebUI.Dtos.Article;
using Newtonsoft.Json;
using System.Text;

namespace MyApiNight.WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticlesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ArticleList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7035/api/Article");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createArticleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var reponseMessage = await client.PostAsync("https://localhost:7035/api/Article", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");

            }
            return View();
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.DeleteAsync("https://localhost:7035/api/Article?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7035/api/Article/GetArticle?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateArticleDto>(jsonData);
                return View(values);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateArticleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var reponseMessage = await client.PutAsync("https://localhost:7035/api/Article", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");

            }
            return View();
        }

    }
}
