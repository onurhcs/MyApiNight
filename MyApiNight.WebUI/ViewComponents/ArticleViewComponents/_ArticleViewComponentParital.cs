using Microsoft.AspNetCore.Mvc;
using MyApiNight.WebUI.Dtos;
using MyApiNight.WebUI.Dtos.Article;
using Newtonsoft.Json;

namespace MyApiNight.WebUI.ViewComponents.ArticleViewComponents
{
    public class _ArticleViewComponentParital : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ArticleViewComponentParital(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
