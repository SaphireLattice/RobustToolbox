using System;
using System.Collections.Generic;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations;

namespace Robust.Shared.Localization;

/// <summary>
///     Wrapper type for a localization string id.
/// </summary>
/// <param name="Id">The id of the localization string.</param>
/// <remarks>
///     This will be automatically validated by <see cref="LocIdSerializer"/> if used in data fields.</remarks>
/// <seealso cref="Loc.GetString(string)"/>
[Serializable, NetSerializable]
public readonly record struct LocNetMessage(string Id, IDictionary<string, ILocValue>? Args = null) : IEquatable<string>, IComparable<LocId>
{
    public static explicit operator string(LocNetMessage locId)
    {
        return locId.Id;
    }

    public static explicit operator LocNetMessage(string id)
    {
        return new LocNetMessage(id);
    }

    public static explicit operator LocNetMessage(LocId id)
    {
        return new LocNetMessage(id);
    }

    public static explicit operator LocNetMessage?(LocId? id)
    {
        return id == null ? default(LocNetMessage?) : new LocNetMessage(id);
    }

    public static explicit operator LocNetMessage?(string? id)
    {
        return id == null ? default(LocNetMessage?) : new LocNetMessage(id);
    }

    public bool Equals(string? other)
    {
        return Id == other;
    }

    public int CompareTo(LocId other)
    {
        return string.Compare(Id, other.Id, StringComparison.Ordinal);
    }

    public override string ToString() => Id ?? string.Empty;
}
