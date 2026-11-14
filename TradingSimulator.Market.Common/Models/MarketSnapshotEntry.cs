using TradingSimulator.Market.Common.Enums;

namespace TradingSimulator.Market.Common.Models;

public readonly struct MarketSnapshotEntry
{
    #region Public
    
    public CompanyLei Lei { get; }
    public string CompanyName { get; }
    public SecurityIsin Isin { get; }
    public SecurityTicker Ticker { get; }
    public string Name { get; }
    public SecurityType Type { get; }
    public SecurityQuote Quote { get; }

    public MarketSnapshotEntry(CompanyLei lei, string companyName, SecurityIsin isin, SecurityTicker ticker, string name, SecurityType type, SecurityQuote quote)
    {
        Lei = lei;
        CompanyName = companyName;
        Isin = isin;
        Ticker = ticker;
        Name = name;
        Type = type;
        Quote = quote;
    }
    
    public MarketSnapshotEntry(Company company, Security security)
    {
        Lei = company.Lei;
        CompanyName = company.Name;
        Isin = security.Isin;
        Ticker = security.Ticker;
        Name = security.Name;
        Type = security.Type;
        Quote = security.Quote;
    }
    
    #endregion Public
}