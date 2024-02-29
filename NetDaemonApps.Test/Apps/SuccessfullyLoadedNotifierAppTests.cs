using NetDaemonApps.Dtos;

namespace NetDaemonApps.Test.Apps;

public class SuccessfullyLoadedNotifierAppTests : AppTestsBase<SuccessfullyLoadedNotifierApp>
{
    [Test]
    public void Init_CallsNotify()
    {
        //Arrange
        var hass = MockHass();
        var expected = StubNotify();
        hass.Setup(h =>
                h.CallService(
                    HaNotify.Domain, HaNotify.Service,
                    It.IsAny<ServiceTarget>(),
                    It.Is<HaNotify>(x => expected.Equals(x))))
            .Verifiable(Times.Once());

        //Act
        var helloWorld = new SuccessfullyLoadedNotifierApp(hass.Object);

        //Assert
        hass.VerifyAll();
    }

    public static HaNotify StubNotify() =>
     new(SuccessfullyLoadedNotifierApp.Title, SuccessfullyLoadedNotifierApp.Message);

}