using CoasterpediaApi.Repositories;
using GeoJSON.Text.Feature;
using GeoJSON.Text.Geometry;
using Microsoft.AspNetCore.Mvc;

namespace CoasterpediaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MapsController : ControllerBase
{
    private readonly WaterSlidesRepository _waterSlidesRepository;

    public MapsController(WaterSlidesRepository waterSlidesRepository)
    {
        _waterSlidesRepository = waterSlidesRepository;
    }

    [HttpGet("slides")]
    public async Task<IActionResult> GetSlides()
    {
        var waterSlides = await _waterSlidesRepository.GetWaterSlidesAsync();
        var featureCollection = new FeatureCollection();
        foreach (var waterSlide in waterSlides)
        {
            var position = new Position(waterSlide.CoordLat, waterSlide.CoordLon);
            var point = new Point(position);
            var properties = new Dictionary<string, object?>
            {
                ["title"] = "[[" + waterSlide.PageTitle + '|' + waterSlide.Name + "]]"
            };
            if (waterSlide.Image is not null)
            {
                properties["description"] = "[[File:" + waterSlide.Image + "]]";
            }

            var feature = new Feature(point, properties);
            featureCollection.Features.Add(feature);
        }

        return Ok(featureCollection);
    }
}