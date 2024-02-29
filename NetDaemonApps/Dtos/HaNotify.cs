using System.Linq.Expressions;

namespace NetDaemonApps.Dtos;

public class HaNotify(string _title, string _message)
{
    public static string Domain => "notify";
    public static string Service => "persistent_notification";
    public string title => _title;
    public string message => _message;

    public static bool operator ==(HaNotify obj1, HaNotify obj2)
    {
        if (ReferenceEquals(obj1, obj2))
            return true;
        if (ReferenceEquals(obj1, null))
            return false;
        if (ReferenceEquals(obj2, null))
            return false;
        return obj1.Equals(obj2);
    }
    public static bool operator !=(HaNotify obj1, HaNotify obj2) => !(obj1 == obj2);
    public bool Equals(HaNotify? other)
    {
        if (ReferenceEquals(other, null))
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return this.title == other.title && this.message == other.message;
    }
    public override bool Equals(object? obj) => Equals(obj as HaNotify);
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = title.GetHashCode();
            hashCode = (hashCode * 397) ^ message.GetHashCode();
            return hashCode;
        }
    }
}