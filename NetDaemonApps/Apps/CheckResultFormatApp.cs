using NetDaemon.Client;

namespace NetDaemonApps.Apps;

[NetDaemonApp]
public class CheckResultFormatApp
{

    public CheckResultFormatApp(ILogger<CheckResultFormatApp> logger, ITriggerManager triggerManager, IHomeAssistantRunner runner)
    {
        // This interface in the client project will allow subscribe to all raw Home Assistant websocket messages.
        var haMessages = (IHomeAssistantHassMessages)runner.CurrentConnection!;

        haMessages.OnHassMessage.Subscribe(m => logger.LogInformation("{Message}", m));

        // Do your trigger magic... and the previous subscription will log every message from this trigger.
        var triggerObservable = triggerManager.RegisterTrigger(
        new
        {
            platform = "state",
            entity_id = new string[] { "media_player.vardagsrum" },
            from = new string[] { "idle", "playing" },
            to = "off"
        });
    }
}