using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNight.BusinessLayer.Abstract;
using MyApiNight.EntityLayer.Concrete;

namespace MyApiNight.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _WriterService;

        public WriterController(IWriterService writerService)
        {
            _WriterService = writerService;
        }

        [HttpGet]
        public IActionResult WriterList()
        {
            var values = _WriterService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWriter(Writer Writer)
        {
            _WriterService.TInsert(Writer);
            return Ok("Ekleme Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteWriter(int id)
        {
            _WriterService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateWriter(Writer Writer)
        {
            _WriterService.TUpdate(Writer);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("GetWriter")]
        public IActionResult GetWriter(int id)
        {
            var values = _WriterService.TGetById(id);
            return Ok(values);
        }
    }
}

