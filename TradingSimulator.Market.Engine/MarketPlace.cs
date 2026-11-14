using System.Collections.Immutable;
using TradingSimulator.Market.Common.Enums;
using TradingSimulator.Market.Common.Interfaces;
using TradingSimulator.Market.Common.Messages;
using TradingSimulator.Market.Common.Models;
using TradingSimulator.Market.Engine.Indexes;

namespace TradingSimulator.Market.Engine;

public class MarketPlace : IMarketPlace
{
    #region Public

    public MarketSnapshot Snapshot => CreateSnapshot();

    public Company RegisterCompany(RegisterCompanyMessage message)
    {
        ClientId clientId = message.ClientId;
        CompanyLei lei = message.Lei;
        string name = message.Name;
        return CompanyIndex.RegisterCompany(clientId, lei, name);
    }

    public Client RegisterClient(RegisterClientMessage message)
    {
        return ClientIndex.RegisterClient(message);
    }

    public (SecurityIsin isin, int volume) RegisterSecurity(RegisterSecurityMessage message)
    {
        return SecurityIndex.RegisterSecurity(message);
    }

    #endregion Public

    #region Protected

    internal protected readonly CompanyIndex CompanyIndex;
    internal protected readonly ClientIndex ClientIndex;
    internal protected readonly SecurityIndex SecurityIndex;
    
    public MarketPlace()
    {
        CompanyIndex = new CompanyIndex();
        ClientIndex = new ClientIndex();
        SecurityIndex = new SecurityIndex();
    }

    #endregion Protected
    
    #region Private
    
    private MarketSnapshot CreateSnapshot()
    {
        Security[] securities = SecurityIndex.SecurityIdToSecurityMapping.Values.ToArray();
        ImmutableDictionary<CompanyId, Company> companyMapping = CompanyIndex.CompanyIdToCompanyMapping.ToImmutableDictionary();

        MarketSnapshotEntry[] entries = new MarketSnapshotEntry[securities.Length];
        for (int i = 0; i < entries.Length; i += 1)
        {
            Security security = securities[i];
            Company? company;
            if (!companyMapping.TryGetValue(security.CompanyId, out company))
            {
                // TODO : Error, The company Id does not correspond to any known.
                continue;
            }

            CompanyLei lei = company.Lei;
            string companyName = company.Name;
            SecurityIsin isin = security.Isin;
            SecurityTicker ticker = security.Ticker;
            string name = security.Name;
            SecurityType type = security.Type;
            SecurityQuote quote = security.Quote;
            MarketSnapshotEntry entry = new MarketSnapshotEntry(lei, companyName, isin, ticker, name, type, quote);

            entries[i] = entry;
        }

        MarketSnapshot snapshot = new MarketSnapshot(entries);
        return snapshot;
    }
    
    #endregion Private
}