using System.Collections.Concurrent;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Engine.Indexes;

public sealed class CompanyIndex
{
    #region Public

    public ConcurrentDictionary<CompanyLei, CompanyId> CompanyLeiToCompanyIdMapping { get; }
    
    public ConcurrentDictionary<CompanyId, Company> CompanyIdToCompanyMapping { get; }

    public CompanyIndex()
    {
        CompanyLeiToCompanyIdMapping = [];
        CompanyIdToCompanyMapping = [];
    }

    public Company RegisterCompany(ClientId clientId, CompanyLei lei, string name)
    {
        if (CompanyLeiToCompanyIdMapping.TryGetValue(lei, out CompanyId companyId))
        {
            return CompanyIdToCompanyMapping[companyId];
        }

        Company company = new Company(new CompanyId(Guid.NewGuid()), clientId, lei, name, []);
        CompanyLeiToCompanyIdMapping.TryAdd(lei, company.Id);
        CompanyIdToCompanyMapping.TryAdd(company.Id, company);
        
        return company;
    }

    #endregion Public
}