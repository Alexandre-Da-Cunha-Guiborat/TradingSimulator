namespace TradingSimulator.Market.Common.Models;

public sealed class Company
{
    #region Public

    public CompanyId Id { get; }
    
    public ClientId ClientId { get; }

    public CompanyLei Lei { get; }
    
    public string Name { get; }

    public Dictionary<SecurityIsin, int> SecurityIsinToNbIssuedMapping { get; }
    
    public Company(CompanyId id, ClientId clientId,CompanyLei lei, string name,  Dictionary<SecurityIsin, int> securityIdToNbIssuedMapping)
    {
        Id = id;
        ClientId = clientId;
        Name = name;
        Lei = lei;
        SecurityIsinToNbIssuedMapping = securityIdToNbIssuedMapping;
    }

    #endregion Public
}