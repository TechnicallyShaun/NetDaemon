using System.Reactive.Concurrency;

namespace NetDaemonApps.Apps;

[NetDaemonApp]
public class DayNightSpeakerVolume(IScheduler scheduler)
{
    public IScheduler Scheduler { get; } = scheduler;

}
