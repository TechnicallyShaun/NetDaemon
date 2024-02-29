using Microsoft.Reactive.Testing;
using NetDaemon.Extensions.Scheduler;
using NetDaemon.HassModel;
using NetDaemonApps.Dtos;
using NUnit.Framework;
using System.Reactive.Concurrency;

namespace NetDaemonApps.Test.Apps;

public class DayNightSpeakerVolumeTests : AppTestsBase<DayNightSpeakerVolumeApp>
{
    //--------------------------------------------------
    // IMPROVEMENT VOLUME PROFILE -> DEVICE SETTER
    //--------------------------------------------------
    // LIST OF SPEAKERS
    // LIST OF TIMES AND VOLUMES
    // POSSIBLE DAY OF WEEK / RANGE
    // ENFORCE MODE (where if volume is changed, it is corrected)

    [Test]
    public void Init_Schedules_AreSetCorrectly()
    {
        var hass = MockHass();
        var config = CreateConfig();

        var scheduler = new TestScheduler();

        var app = new DayNightSpeakerVolumeApp(hass.Object, scheduler, config);

        app.Should().NotBeNull();
    }

    [Test]
    public void SetVolume_Day_Fires_AtScheduledTime()
    {
        //Arrange
        var hass = MockHass();
        var config = CreateConfig();

        var oneMinBeforeProfile = DateTime.Today.Add(config.Value.DayStart).AddMinutes(-1);

        var testScheduler = new TestScheduler();
        testScheduler.AdvanceTo(oneMinBeforeProfile.ToUniversalTime().Ticks);

        var expected = new SetMediaPlayerVolume(config.Value.DayVolume);

        var app = new DayNightSpeakerVolumeApp(hass.Object, testScheduler, config);

        hass.Setup(h =>
            h.CallService(
                SetMediaPlayerVolume.Domain, SetMediaPlayerVolume.Service,
                It.Is<ServiceTarget>(x => x.EntityIds!.Count == config.Value.Devices!.Count()),
                It.Is<SetMediaPlayerVolume>(x => expected.Equals(x))))
        .Verifiable(Times.Once());

        hass.VerifyNoOtherCalls();

        //Act
        testScheduler.AdvanceBy(TimeSpan.FromMinutes(1).Ticks);

        //Assert
        hass.VerifyAll();
    }


    [Test]
    public void SetVolume_Night_Fires_AtScheduledTime()
    {
        //Arrange
        var hass = MockHass();
        var config = CreateConfig();

        var oneMinBeforeProfile = DateTime.Today.Add(config.Value.NightStart).AddMinutes(-1);

        var testScheduler = new TestScheduler();
        testScheduler.AdvanceTo(oneMinBeforeProfile.ToUniversalTime().Ticks);

        var expected = new SetMediaPlayerVolume(config.Value.NightVolume);

        var app = new DayNightSpeakerVolumeApp(hass.Object, testScheduler, config);

        hass.Setup(h =>
            h.CallService(
                SetMediaPlayerVolume.Domain, SetMediaPlayerVolume.Service,
                It.Is<ServiceTarget>(x => x.EntityIds!.Count == config.Value.Devices!.Count()),
                It.Is<SetMediaPlayerVolume>(x => expected.Equals(x))))
        .Verifiable(Times.Once());

        hass.VerifyNoOtherCalls();

        //Act
        testScheduler.AdvanceBy(TimeSpan.FromMinutes(1).Ticks);

        //Assert
        hass.VerifyAll();
    }

    private static IAppConfig<DayNightSpeakerVolumeConfig> CreateConfig()
    {
        var appConfig = new Mock<IAppConfig<DayNightSpeakerVolumeConfig>>();

        var config = new DayNightSpeakerVolumeConfig();

        config.DayStart = new TimeSpan(5, 0, 0);
        config.DayVolume = 9;

        config.NightStart = new TimeSpan(19, 0, 0);
        config.NightVolume = 3;

        config.Devices = ["media_player.device_name", "media_player.and_another"];

        appConfig.Setup(ac => ac.Value).Returns(config);

        return appConfig.Object;
    }
}
