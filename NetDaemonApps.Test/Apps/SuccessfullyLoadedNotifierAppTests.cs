using NetDaemonApps.Dtos;

namespace NetDaemonApps.Test.Apps;

public class SuccessfullyLoadedNotifierAppTests
{
    [Test]
    public void Init_CallsNotify()
    {
        var mock = new Mock<IHaContext>();
        var helloWorld = new SuccessfullyLoadedNotifierApp(mock.Object);
        var expected = new HaNotify(SuccessfullyLoadedNotifierApp.Title, SuccessfullyLoadedNotifierApp.Message);

        mock.Verify(x => x.CallService(HaNotify.Domain, HaNotify.Service, It.IsAny<ServiceTarget>(), It.Is<HaNotify>(y => y.Equals(expected))), Times.Once());
    }
    [Test]
    public void TestHashes()
    {
        var expected = new HaNotify(SuccessfullyLoadedNotifierApp.Title, SuccessfullyLoadedNotifierApp.Message);
        var actual = new HaNotify(SuccessfullyLoadedNotifierApp.Title, SuccessfullyLoadedNotifierApp.Message);

        var eHash = expected.GetHashCode();
        var aHash = actual.GetHashCode();

        eHash.Equals(aHash).Should().BeTrue();
    }

    [Test]
    public void TestAttribute()
    {
        Attribute.GetCustomAttribute(typeof(SuccessfullyLoadedNotifierApp), typeof(NetDaemonAppAttribute)).Should().NotBeNull();
    }
}