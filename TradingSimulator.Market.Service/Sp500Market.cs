using System.Text.Json;
using TradingSimulator.Market.Common.Enums;
using TradingSimulator.Market.Common.Messages;
using TradingSimulator.Market.Common.Models;
using TradingSimulator.Market.Engine;

namespace TradingSimulator.Market.Service;

public class Sp500Market : RandomizedMarketPlace
{
    #region Public

    public Sp500Market()
    {
    }

    public async Task InitializeAsync(HttpClient httpClient)
    {
        const string apiKey = "dbj0bt1r01qkampulmugdbj0bt1r01qkampulmv0";

        const int marketSize = 20;
        for (int i = 0; i < marketSize; i += 1)
        {
            KeyValuePair<string, string> leiToTicker = Sp500Descriptor.LeiToTickerMapping.ElementAt(i);
            string lei = leiToTicker.Key;
            string ticker = leiToTicker.Value;

            FinnhubQuote? quote = await GetAsync<FinnhubQuote>(httpClient, $"quote?symbol={ticker}", apiKey);
            if (quote is null)
            {
                continue;
            }

            RegisterClientMessage clientMessage = new RegisterClientMessage(lei);
            Client client = RegisterClient(clientMessage);

            RegisterCompanyMessage companyMessage = new RegisterCompanyMessage(client.Id, new CompanyLei(lei), lei);
            Company company = RegisterCompany(companyMessage);

            Random seed = new Random();
            int volume = seed.Next(10, 1001);
            RegisterSecurityMessage securityMessage = new RegisterSecurityMessage(company.Id, company.ClientId,
                new SecurityIsin(ticker), new SecurityTicker(ticker), ticker, SecurityType.CommonStock,
                (decimal)quote.Current, volume);
            RegisterSecurity(securityMessage);
        }
    }

    #endregion Public

    #region Private

    private static async Task<T?> GetAsync<T>(HttpClient httpClient, string endpoint, string apiKey)
    {
        string url = $"https://finnhub.io/api/v1/{endpoint}&token={apiKey}";

        HttpResponseMessage response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
                
        string json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json);
    }

    #endregion Private
}