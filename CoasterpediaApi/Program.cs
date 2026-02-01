using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.CombineLogs = true;
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpLogging();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
