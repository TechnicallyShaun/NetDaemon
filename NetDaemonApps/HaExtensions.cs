using NetDaemonApps.Dtos;

namespace NetDaemonApps;

public static class HaExtensions
{
    public static void Notify(this IHaContext ha, HaNotify notification)
        => ha.CallService(HaNotify.Domain, HaNotify.Service, null, notification);
}
