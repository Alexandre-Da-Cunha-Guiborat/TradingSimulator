using System.Collections.Concurrent;
using TradingSimulator.Market.Common.Enums;
using TradingSimulator.Market.Common.Messages;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Engine.Indexes;

public sealed class SecurityIndex
{
    #region Public

    public ConcurrentDictionary<SecurityTicker, ConcurrentBag<SecurityId>> TickerToSecuritiesMapping { get; }

    public ConcurrentDictionary<SecurityId, Security> SecurityIdToSecurityMapping { get; }
    
    public SecurityIndex()
    {
        TickerToSecuritiesMapping = [];
        SecurityIdToSecurityMapping = [];
    }

    public (SecurityIsin isin, int volume) RegisterSecurity(RegisterSecurityMessage message)
    {
        CompanyId companyId = message.CompanyId;
        ClientId ownerId = message.OwnerId;
        SecurityIsin isin = message.Isin;
        SecurityTicker ticker = message.Ticker;
        string name = message.Name;
        SecurityType type = message.Type;
        decimal price = message.Price;
        int volume = message.Volume;
        
        TickerToSecuritiesMapping.TryAdd(ticker, []);

        for (int i = 0; i < volume; i += 1)
        {
            SecurityQuote quote = new SecurityQuote(price, price, price);
            Security security = new Security(new SecurityId(Guid.NewGuid()), companyId, ownerId, isin, ticker, name, type, quote);
            TickerToSecuritiesMapping[ticker].Add(security.Id);
            SecurityIdToSecurityMapping.TryAdd(security.Id, security);
        }

        return (isin, volume);
    }

    #endregion Public
}