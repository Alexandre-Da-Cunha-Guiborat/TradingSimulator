using TradingSimulator.Market.Common.Enums;

namespace TradingSimulator.Market.Common.Models;

public sealed class Security
{
    #region Public

    public SecurityId Id { get; }

    public CompanyId CompanyId { get; }
    
    public ClientId OwnerId { get; }

    public SecurityIsin Isin { get; }
    
    public SecurityTicker Ticker { get; }

    public string Name { get; }

    public SecurityType Type { get; }
    
    public SecurityQuote Quote { get; set; }

    public Security(SecurityId id, CompanyId companyId, ClientId ownerId, SecurityIsin isin, SecurityTicker ticker, string name, SecurityType type, SecurityQuote quote)
    {
        Id = id;
        CompanyId = companyId;
        OwnerId = ownerId;
        Isin = isin;
        Ticker = ticker;
        Name = name;
        Type = type;
        Quote = quote;
    }

    #endregion Public
}