using NetDaemon.AppModel;

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

    private IAppConfig<DayNightSpeakerVolume> CreateConfig()
    {
        var config = Mock.Of<IAppConfig<DayNightSpeakerVolume>>();

        config.Value.DayStart = "7.30";
        config.Value.DayVolume = 9;

        config.Value.NightStart = "19.30";
        config.Value.NightVolume = 3;

        return config;
    }

    // Tests
    //  - Day Event is set
    //  - Night event is set
    //  - Volume Set is called (with correct volume level, for day and night)


    [Test]
    public void TestCron()
    {
        var haContextMoq = new Mock<IHaContext>();
        var fakeConfig = CreateConfig();

        var testScheduler = new Microsoft.Reactive.Testing.TestScheduler();
        testScheduler.AdvanceTo(new DateTime(2020, 2, 1, 23, 44, 0).ToUniversalTime().Ticks);

        var app = new DayNightSpeakerVolumeApp(haContextMoq.Object, testScheduler, fakeConfig);

        haContextMoq.VerifyNoOtherCalls();
        testScheduler.AdvanceBy(TimeSpan.FromMinutes(1).Ticks);


    }
}
