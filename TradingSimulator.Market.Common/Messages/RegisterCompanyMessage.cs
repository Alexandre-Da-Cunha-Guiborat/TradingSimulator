using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Common.Messages;

public readonly ref struct RegisterCompanyMessage
{
    #region Public

    public ClientId ClientId { get; }
    
    public CompanyLei Lei { get; }
    
    public string Name { get; }

    public RegisterCompanyMessage()
    {
        ClientId = new ClientId();
        Lei = new CompanyLei();
        Name = string.Empty;
    }
    
    public RegisterCompanyMessage(ClientId clientId, CompanyLei lei, string name)
    {
        ClientId = clientId;
        Lei = lei;
        Name = name;
    }

    #endregion Public
}