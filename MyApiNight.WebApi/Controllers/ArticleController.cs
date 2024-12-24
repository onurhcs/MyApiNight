using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNight.BusinessLayer.Abstract;
using MyApiNight.EntityLayer.Concrete;

namespace MyApiNight.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult ArticleList()
        {
            var values = _articleService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateArticle(Article Article)
        {
            _articleService.TInsert(Article);
            return Ok("Ekleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateArticle(Article Article)
        {
            _articleService.TUpdate(Article);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("GetArticle")]
        public IActionResult GetArticle(int id)
        {
            var values = _articleService.TGetById(id);
            return Ok(values);
        }
    }
}
