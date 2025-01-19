namespace CoasterpediaApi.Models;

public class AmusementParks
{
    public int Id { get; init; }
    public string PageName { get; init; }
    public int PageNamespace { get; init; }
    public int PageId { get; init; }
    public string Name {get; init; }
    public string NameFormer { get; init; }
    public string Image { get; init; }
    public string Location { get; init; }
    public string Country { get; init; }
    public string State { get; init; }
    public string Status { get; init; }
    public DateTime Opened { get; init; }
    public int OpenedPrecision { get; init; }
    public DateTime Closed { get; init; }
    public int ClosedPrecision { get; init; }
    public DateTime Opening { get; init; }
    public int OpeningPrecision { get; init; }
    public DateTime Closing { get; init; }
    public int ClosingPrecision { get; init; }
    public string Owner { get; init; }
    public string Operator { get; init; }
    public decimal CoordinatesLat { get; init; }
    public decimal CoordinatesLon { get; init; }
}