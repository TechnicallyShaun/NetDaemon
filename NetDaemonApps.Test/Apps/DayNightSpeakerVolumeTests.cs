using Microsoft.Reactive.Testing;

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

    private IAppConfig<DayNightSpeakerVolumeConfig> CreateConfig()
    {
        var config = Mock.Of<IAppConfig<DayNightSpeakerVolumeConfig>>();

        config.Value.DayStart = new TimeSpan(7, 0, 0);
        config.Value.DayVolume = 9;

        config.Value.NightStart = new TimeSpan(19, 0, 0);
        config.Value.NightVolume = 3;

        return config;
    }

    // Tests
    //  - Day Event is set
    //  - Night event is set
    //  - Volume Set is called (with correct volume level, for day and night)

    [Test]
    public void Init_Schedules_AreSetCorrectly()
    {
        var ha = MockHass();
        var stubConfig = CreateConfig();

        var testScheduler = new TestScheduler();
        testScheduler.AdvanceTo(new DateTime(2020, 2, 1, 23, 44, 0).ToUniversalTime().Ticks);

        var app = new DayNightSpeakerVolumeApp(ha.Object, testScheduler, stubConfig);
    }


    [Test]
    public void TestCron()
    {
        var ha = new Mock<IHaContext>();
        var stubConfig = CreateConfig();

        var testScheduler = new TestScheduler();
        testScheduler.AdvanceTo(new DateTime(2020, 2, 1, 23, 44, 0).ToUniversalTime().Ticks);

        var app = new DayNightSpeakerVolumeApp(ha.Object, testScheduler, stubConfig);

        ha.VerifyNoOtherCalls();
        testScheduler.AdvanceBy(TimeSpan.FromMinutes(1).Ticks);
    }
}
