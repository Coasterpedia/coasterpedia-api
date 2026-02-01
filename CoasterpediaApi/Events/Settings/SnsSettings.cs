namespace CoasterpediaApi.Events.Settings;

public record SnsSettings
{
    public string TopicArn { get; init; }
}