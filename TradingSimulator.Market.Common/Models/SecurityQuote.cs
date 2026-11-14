using System.Diagnostics.CodeAnalysis;

namespace TradingSimulator.Market.Common.Models;

public readonly struct SecurityQuote : IEquatable<SecurityQuote>
{
    #region Public

    public decimal Bid { get; }
    public decimal Ask { get; }
    public decimal LastPrice { get; }

    public SecurityQuote()
    {
        Bid = decimal.MinValue;
        Ask = decimal.MinValue;
        LastPrice = decimal.MinValue;
    }

    public SecurityQuote(decimal bid, decimal ask, decimal lastPrice)
    {
        Bid = bid;
        Ask = ask;
        LastPrice = lastPrice;
    }

    public bool Equals(SecurityQuote other)
    {
        return Bid.Equals(other.Bid) && Ask.Equals(other.Ask) && LastPrice.Equals(other.LastPrice);
    }

    public override string ToString()
    {
        return $"Bid={Bid.ToString("C")}, Ask={Ask.ToString("C")}, LastPrice={LastPrice.ToString("C")}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Bid, Ask, LastPrice);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is SecurityQuote entry && Equals(entry);
    }

    #endregion Public
}