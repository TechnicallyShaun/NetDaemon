using NetDaemonApps.Dtos;
using System.Linq.Expressions;

namespace NetDaemonApps.Test.Apps;

public class SuccessfullyLoadedNotifierAppTests : AppTestsBase<SuccessfullyLoadedNotifierApp>
{
    [Test]
    public void Init_CallsNotify()
    {
        //Arrange
        var mock = FakeHass();
        var expected = StubNotify();
        mock.Setup(h =>
                h.CallService(
                    HaNotify.Domain, HaNotify.Service,
                    It.IsAny<ServiceTarget>(),
                    It.Is(TheSameAs(expected))))
            .Verifiable(Times.Once());

        //Act
        var helloWorld = new SuccessfullyLoadedNotifierApp(mock.Object);

        //Assert
        mock.VerifyAll();
    }

    private Expression<Func<HaNotify, bool>> TheSameAs(HaNotify expected) =>
        x => IsMatch(x, expected);
    private static bool IsMatch(HaNotify a, HaNotify b)
        => a.title == b.title && a.message == b.message;

    /// <summary>
    /// Ensure the matching method works correctly
    /// </summary>
    [Test]
    public void Matching_Notify_HappyPath() =>
        IsMatch(StubNotify(), StubNotify());

    private static HaNotify StubNotify() => new(SuccessfullyLoadedNotifierApp.Title, SuccessfullyLoadedNotifierApp.Message);
    protected override SuccessfullyLoadedNotifierApp CreateSUT(IHaContext hass) => new(hass);
}