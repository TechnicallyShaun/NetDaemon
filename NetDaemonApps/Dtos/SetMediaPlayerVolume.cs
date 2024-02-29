using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetDaemonApps.Dtos;

public class SetMediaPlayerVolume(decimal volume)
{

    public static string Domain => "media_player";
    public static string Service => "volume_set";
    public decimal volume_level => volume;

    public static bool operator ==(SetMediaPlayerVolume obj1, SetMediaPlayerVolume obj2)
    {
        if (ReferenceEquals(obj1, obj2))
            return true;
        if (ReferenceEquals(obj1, null))
            return false;
        if (ReferenceEquals(obj2, null))
            return false;
        return obj1.Equals(obj2);
    }
    public static bool operator !=(SetMediaPlayerVolume obj1, SetMediaPlayerVolume obj2) => !(obj1 == obj2);
    public bool Equals(SetMediaPlayerVolume? other)
    {
        if (ReferenceEquals(other, null))
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return this.volume_level == other.volume_level;
    }
    public override bool Equals(object? obj) => Equals(obj as SetMediaPlayerVolume);
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = volume_level.GetHashCode();
            return hashCode;
        }
    }
}
