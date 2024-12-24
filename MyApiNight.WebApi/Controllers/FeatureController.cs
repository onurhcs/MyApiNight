using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiNight.BusinessLayer.Abstract;
using MyApiNight.EntityLayer.Concrete;

namespace MyApiNight.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {

     private readonly IFeatureService _featureService;

    public FeatureController(IFeatureService FeatureService)
    {
            _featureService = FeatureService;
    }

    [HttpGet]
    public IActionResult FeatureList()
    {
        var values = _featureService.TGetAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateFeature([FromBody] Feature feature)
    {
        if (feature == null || string.IsNullOrEmpty(feature.Name))
        {
            return BadRequest("Feature alanı boş olamaz ve geçerli bir değer içermelidir.");
        }

        _featureService.TInsert(feature);
        return Ok("Ekleme Başarılı");
    }


        [HttpDelete]
    public IActionResult DeleteFeature(int id)
    {
            _featureService.TDelete(id);
        return Ok("Silme Başarılı");
    }
    [HttpPut]
    public IActionResult UpdateFeature(Feature Feature)
    {
            _featureService.TUpdate(Feature);
        return Ok("Güncelleme Yapıldı");
    }
    [HttpGet("GetFeature")]
    public IActionResult GetFeature(int id)
    {
        var values = _featureService.TGetById(id);
        return Ok(values);
    }
}
}
