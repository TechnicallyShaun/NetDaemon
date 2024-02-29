using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;

namespace NetDaemonApps.Apps;

[NetDaemonApp]
public class DayNightSpeakerVolumeApp
{
    public DayNightSpeakerVolumeApp(IHaContext ha, IScheduler scheduler, IAppConfig<DayNightSpeakerVolumeConfig> appConfig)
    {
        var config = appConfig.Value;

        scheduler.ScheduleCron(config.DayStart.ToCron(), () =>
        {
            ha.SetVolume(config.Devices!.ToArray(), new SetMediaPlayerVolume(config.DayVolume));
        });
        scheduler.ScheduleCron(config.NightStart.ToCron(), () =>
        {
            ha.SetVolume(config.Devices!.ToArray(), new SetMediaPlayerVolume(config.NightVolume));
        });
    }
}
public class DayNightSpeakerVolumeConfig
{
    public TimeSpan DayStart { get; set; }
    public decimal DayVolume { get; set; }
    public TimeSpan NightStart { get; set; }
    public decimal NightVolume { get; set; }
    public IEnumerable<string>? Devices { get; set; }
}
