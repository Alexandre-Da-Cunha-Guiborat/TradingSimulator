using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

public readonly struct ClientId : IEquatable<ClientId>
{
    #region Public

    public Guid Value { get; }

    public ClientId()
    {
        Value = Guid.Empty;
    }

    public ClientId(Guid value)
    {
        Value = value;
    }

    public bool Equals(ClientId other)
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
        return obj is ClientId id && Equals(id);
    }

    #endregion Public
}