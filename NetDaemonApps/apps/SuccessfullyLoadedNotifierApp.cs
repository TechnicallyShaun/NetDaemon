using NetDaemonApps.Dtos;

namespace NetDaemonApps.Apps;

[NetDaemonApp]
public class SuccessfullyLoadedNotifierApp
{
    public static string Title => "Net Daemon Connected";
    public static string Message => "Net Daemon has successfully connected to this Home Assistant instance.";

    public SuccessfullyLoadedNotifierApp(IHaContext ha) => ha.Notify(new HaNotify(Title, Message));
}
