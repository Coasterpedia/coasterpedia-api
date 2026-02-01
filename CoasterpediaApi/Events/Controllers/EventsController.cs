using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using CoasterpediaApi.Events.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoasterpediaApi.Events.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IAmazonSimpleNotificationService _snsClient;
    private readonly IOptions<SnsSettings> _snsSettings;
    private readonly ILogger<EventsController> _logger;

    public EventsController(IAmazonSimpleNotificationService snsClient, IOptions<SnsSettings> snsSettings, ILogger<EventsController> logger)
    {
        _snsClient = snsClient;
        _snsSettings = snsSettings;
        _logger = logger;
    }

    [HttpPost("/{*path}")]
    public async Task<IActionResult> Action()
    {
        try
        {
            var response = await _snsClient.PublishAsync(new PublishRequest
            {
                TopicArn = _snsSettings.Value.TopicArn,
                Message = await new StreamReader(Request.Body).ReadToEndAsync(),
            });


            _logger.LogInformation("Published message topic {TopicArn}, {MessageId}", _snsSettings.Value.TopicArn,
                response.MessageId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "A problem occurred");
        }

        return Ok();
    }
}