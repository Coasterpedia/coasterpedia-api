using Amazon.SimpleNotificationService;
using CoasterpediaApi.Events.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<SnsSettings>().Bind(builder.Configuration.GetSection(nameof(SnsSettings)));
builder.Services.AddControllers();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSimpleNotificationService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
