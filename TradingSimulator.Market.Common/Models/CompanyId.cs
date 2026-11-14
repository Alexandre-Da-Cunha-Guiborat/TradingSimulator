using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

public readonly struct CompanyId : IEquatable<CompanyId>
{
    #region Public

    public Guid Value { get; }

    public CompanyId()
    {
        Value = Guid.Empty;
    }
    
    public CompanyId(Guid value)
    {
        Value = value;
    }

    public bool Equals(CompanyId other)
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
        return obj is CompanyId id && Equals(id);
    }

    #endregion Public
}