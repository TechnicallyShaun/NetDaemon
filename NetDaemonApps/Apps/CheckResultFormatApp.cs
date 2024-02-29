using NetDaemon.Client;

namespace NetDaemonApps.Apps;

/// <summary>
/// This will log incoming messages from Home Assistant
/// </summary>
[NetDaemonApp]
public class CheckResultFormatApp
{
    public CheckResultFormatApp(ILogger<CheckResultFormatApp> logger, IHomeAssistantRunner runner)
    {
        // This interface in the client project will allow subscribe to all raw Home Assistant websocket messages.
        var haMessages = (IHomeAssistantHassMessages)runner.CurrentConnection!;
        haMessages.OnHassMessage.Subscribe(m => logger.LogDebug("{Message}", m));
    }
}