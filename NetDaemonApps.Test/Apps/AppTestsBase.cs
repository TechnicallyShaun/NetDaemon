namespace NetDaemonApps.Test.Apps;

public abstract class AppTestsBase<T>
    where T : class
{
    /// <summary>
    /// Ensure the App Class has the `NetDaemonAppAttribute` attribute.
    /// (This is required for NetDaemon to correctly load the app)
    /// </summary>
    [Test]
    public void Class_Has_NetDaemonAppAttribute()
    {
        Attribute.GetCustomAttribute(typeof(T), typeof(NetDaemonAppAttribute))
            .Should().NotBeNull();
    }

    /// <summary>
    /// Create a Fake HaContext Instance
    /// </summary>
    /// <returns></returns>
    protected Mock<IHaContext> MockHass() => new();
}
