using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

// LEI (Legal Entity Identifier) A legal entity involved in financial transactions 20-character alphanumeric code

public readonly struct CompanyLei :IEquatable<CompanyLei>
{
    #region Public
    
    public string Value { get; }

    public CompanyLei()
    {
        Value = string.Empty;
    }
    
    public CompanyLei(string value)
    {
        Value = value;
    }
    
    public bool Equals(CompanyLei other)
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
        return obj is CompanyLei ising && Equals(ising);
    }
    
    #endregion Public
}