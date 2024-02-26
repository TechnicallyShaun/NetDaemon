using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel;
using NetDaemon.HassModel.Entities;
using NetDaemonApps.Dtos;
using System.Linq;
using System.Reactive.Concurrency;

namespace NetDaemonApps.Apps;

[NetDaemonApp]
public class DayNightSpeakerVolumeApp
{
    private DayNightSpeakerVolume config;

    public DayNightSpeakerVolumeApp(IHaContext ha, IScheduler scheduler, IAppConfig<DayNightSpeakerVolume> config)
    {
        this.config = config.Value;

        scheduler.ScheduleCron("0 7 * * *", () => {
            ha.Entity("media_player.living_room_speaker").CallService("media_player.volume_set", new { volume_level = 0.9 });
        });

        scheduler.ScheduleCron("0 21 * * *", () => {
            ha.Entity("media_player.living_room_speaker").CallService("media_player.volume_set", new { volume_level = 0.3 });
        });

    }
}
public class DayNightSpeakerVolume
{
    public string? DayStart { get; set; }
    public decimal? DayVolume { get; set; }
    public string? NightStart { get; set; }
    public decimal? NightVolume { get; set; }
}
