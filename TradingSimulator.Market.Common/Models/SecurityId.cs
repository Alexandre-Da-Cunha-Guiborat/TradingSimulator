using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

public readonly struct SecurityId : IEquatable<SecurityId>
{
    #region Public

    public Guid Value { get; }

    public SecurityId()
    {
        Value = Guid.Empty;
    }
    
    public SecurityId(Guid value)
    {
        Value = value;
    }

    public bool Equals(SecurityId other)
    {
        return Value.Equals(other.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is SecurityId id && Equals(id);
    }

    #endregion Public
}