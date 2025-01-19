using CoasterpediaApi.Models;
using CoasterpediaApi.Settings;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace CoasterpediaApi.Repositories;

public class WaterSlidesRepository
{
    private readonly IOptions<ConnectionStrings> _settings;

    public WaterSlidesRepository(IOptions<ConnectionStrings> settings)
    {
        _settings = settings;
    }
    
    public async Task<List<WaterSlides>> GetWaterSlidesAsync()
    {
        await using var connection = new MySqlConnection(_settings.Value.DefaultConnection);
        var sql = "SELECT _pageTitle AS PageTitle, Name, Image, Coord__lat AS CoordLat, Coord__lon AS CoordLon FROM mw_cargo__Water_Slides WHERE Coord__full IS NOT NULL";
        return connection.Query<WaterSlides>(sql).ToList();
    }
}