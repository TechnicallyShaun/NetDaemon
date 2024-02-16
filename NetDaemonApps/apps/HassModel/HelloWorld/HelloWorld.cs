// Use unique namespaces for your apps if you going to share with others to avoid
// conflicting names

namespace HassModel;

/// <summary>
///     Hello world showcase using the new HassModel API
/// </summary>
[NetDaemonApp]
public class HelloWorldApp
{
    public HelloWorldApp(IHaContext ha, ITestThis tt)
    {
        ha.CallService("notify", "persistent_notification", null, new { message = "Notify me", title = "Hello world!" });

        tt.Heya("Hi!");
        tt.Heya2(new { test = "Hi!", other = "test" });
    }
}

public interface ITestThis
{
    public void Heya(string message);
    public void Heya2(object message);
}