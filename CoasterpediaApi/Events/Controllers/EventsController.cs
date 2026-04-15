using System.Text.Json;
using System.Text.Json.Nodes;
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
            var body = await JsonSerializer.DeserializeAsync<JsonArray>(Request.Body);
            foreach (var eventBody in body)
            {
                var attributes = new Dictionary<string, MessageAttributeValue>();
                if (eventBody?["performer"]?["user_text"] != null)
                {
                    attributes.Add("schema", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = eventBody["$schema"]?.ToString()
                    });
                }

                if (eventBody?["performer"]?["user_text"] != null)
                {
                    attributes.Add("user", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = eventBody["performer"]?["user_text"]?.ToString()
                    });
                }

                if (eventBody?["page_namespace"] != null)
                {
                    attributes.Add("namespace", new MessageAttributeValue
                    {
                        DataType = "String",
                        StringValue = eventBody?["page_namespace"]?.ToString()
                    });
                }
                
                var response = await _snsClient.PublishAsync(new PublishRequest
                {
                    TopicArn = _snsSettings.Value.TopicArn,
                    Message = JsonSerializer.Serialize(eventBody),
                    MessageAttributes = attributes
                });
                
                _logger.LogInformation("Published message topic {TopicArn}, {MessageId}", _snsSettings.Value.TopicArn,
                    response.MessageId);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "A problem occurred");
        }

        return Ok();
    }
}