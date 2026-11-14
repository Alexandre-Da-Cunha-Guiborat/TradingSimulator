using TradingSimulator.Market.Common.Enums;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Common.Messages;

public readonly ref struct RegisterSecurityMessage
{
    #region Public

    public CompanyId CompanyId { get; }
    
    public ClientId OwnerId { get; }
        
    public SecurityIsin Isin { get; }
    
    public SecurityTicker Ticker { get; }
    
    public string Name { get; }
    
    public SecurityType Type { get; }
    
    public decimal Price { get; }
    
    public int Volume { get; }

    public RegisterSecurityMessage()
    {
        CompanyId = new CompanyId();
        OwnerId = new ClientId();
        Isin  = new  SecurityIsin();
        Ticker = new SecurityTicker();
        Name = string.Empty;
        Type = SecurityType.SecurityType_NONE;
        Price = 0;
        Volume = 0;
    }
    
    public RegisterSecurityMessage(CompanyId companyId, ClientId ownerId, SecurityIsin isin, SecurityTicker ticker, string name, SecurityType type, decimal price, int volume)
    {
        CompanyId = companyId;
        OwnerId = ownerId;
        Isin  = isin;
        Ticker = ticker;
        Name = name;
        Type = type;
        Price = price;
        Volume = volume;
    }

    #endregion Public
}