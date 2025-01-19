namespace CoasterpediaApi.Models;

public record WaterSlides
{
    public int Id { get; init; }
    public string PageName { get; init; }
    public string PageTitle { get; init; }
    public int PageNamespace { get; init; }
    public int PageId { get; init; }
    public string Name {get; init; }
    public string? Image { get; init; }
    public string Park { get; init; }
    public string Location { get; init; }
    public double CoordLat { get; init; }
    public double CoordLon { get; init; }
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
    public string Manufacturer { get; init; }
    public string Category1 { get; init; }
    public string Category2 { get; init; }
    public string Category3 { get; init; }
    public string Category4 { get; init; }
    public string Category5 { get; init; }
    public string Category6 { get; init; }
    public string Product { get; init; }
    public decimal Height { get; init; }
    public decimal Length { get; init; }
}