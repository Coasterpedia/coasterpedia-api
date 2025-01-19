using CoasterpediaApi.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace CoasterpediaApi.Repositories;

public class WaterSlidesRepository
{
    public async Task<List<WaterSlides>> GetWaterSlidesAsync()
    {
        var connectionString = "Server=localhost;database=coasterpedia;Uid=user;Pwd=password;Charset=utf8;Port=3306;SslMode=none";
        await using var connection = new MySqlConnection(connectionString);
        var sql = "SELECT _pageTitle AS PageTitle, Name, Image, Coord__lat AS CoordLat, Coord__lon AS CoordLon FROM mw_cargo__Water_Slides WHERE Coord__full IS NOT NULL";
        return connection.Query<WaterSlides>(sql).ToList();
    }
}