using CoasterpediaApi.Repositories;
using CoasterpediaApi.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOptions<ConnectionStrings>().Bind(builder.Configuration.GetSection(nameof(ConnectionStrings)));
builder.Services.AddOpenApi();
builder.Services.AddTransient<WaterSlidesRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
