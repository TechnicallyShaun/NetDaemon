namespace NetDaemonApps.Dtos;

public class HaNotify(string _title, string _message)
{
    public static string Domain => "notify";
    public static string Service => "persistent_notification";
    public string title => _title;
    public string message => _message;

    public override int GetHashCode() => title.GetHashCode() + message.GetHashCode();
    public override bool Equals(object? obj) => GetHashCode() == obj?.GetHashCode();
}
