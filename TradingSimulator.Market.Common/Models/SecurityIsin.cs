using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

// International Securities Identification Number (12-character)

public readonly struct SecurityIsin :IEquatable<SecurityIsin>
{
    #region Public
    
    public string Value { get; }

    public SecurityIsin()
    {
        Value = string.Empty;
    }
    
    public SecurityIsin(string value)
    {
        Value = value;
    }
    
    public bool Equals(SecurityIsin other)
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
        return obj is SecurityIsin ising && Equals(ising);
    }
    
    #endregion Public
}