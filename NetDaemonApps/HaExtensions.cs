using NetDaemon.HassModel.Entities;
using NetDaemonApps.Dtos;
using System.Collections.Generic;
using System.Reactive;

namespace NetDaemonApps;

public static class HaExtensions
{
    public static void Notify(this IHaContext ha, HaNotify notification)
        => ha.CallService(HaNotify.Domain, HaNotify.Service, null, notification);

    public static void SetVolume(this IHaContext ha, string[] devices, SetMediaPlayerVolume setVolume)
        => ha.CallService(SetMediaPlayerVolume.Domain, SetMediaPlayerVolume.Service, new ServiceTarget() { EntityIds = devices }, setVolume);

    public static string ToCron(this TimeSpan ts) => $"{ts.Minutes} {ts.Hours} * * *";  


}
