using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

public readonly struct SecurityTicker :IEquatable<SecurityTicker>
{
    #region Public
    
    public string Value { get; }

    public SecurityTicker()
    {
        Value = string.Empty;
    }
    
    public SecurityTicker(string value)
    {
        Value = value;
    }
    
    public bool Equals(SecurityTicker other)
    {
        return Value.Equals(other.Value);
    }
    
    public override string ToString()
    {
        return Value;
    }
    
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is SecurityTicker ticker && Equals(ticker);
    }
    
    #endregion Public
}