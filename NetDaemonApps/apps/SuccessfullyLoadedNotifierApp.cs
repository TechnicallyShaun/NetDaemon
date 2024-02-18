namespace NetDaemonApps.apps;

[NetDaemonApp]
public class SuccessfullyLoadedNotifierApp
{
    public static string Title => "Net Daemon Connected";
    public static string Message => "Net Daemon has successfully connected to this Home Assistant instance.";

    public SuccessfullyLoadedNotifierApp(IHaContext ha) => ha.Notify(new HaNotify(Title, Message));
}
public class HaNotify(string _title, string _message)
{
    public static string Domain => "notify";
    public static string Service => "persistent_notification";
    public string title => _title;
    public string message => _message;

    public override int GetHashCode() => title.GetHashCode() + message.GetHashCode();
    public override bool Equals(object? obj) => this.GetHashCode() == obj?.GetHashCode();
}
public static class HaExtensions
{
    public static void Notify(this IHaContext ha, HaNotify notification)
        => ha.CallService(HaNotify.Domain, HaNotify.Service, null, notification);
}
