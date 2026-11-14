using TradingSimulator.Market.Common.Enums;
using TradingSimulator.Market.Common.Messages;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Engine;

public class RandomizedMarketPlace : MarketPlace
{
    #region Public

    public void UpdateMarketQuote()
    {
        Random random = new Random();
        foreach (KeyValuePair<SecurityId, Security> entry in SecurityIndex.SecurityIdToSecurityMapping)
        {
            Security security = entry.Value;

            int signBid = random.Next(-1, 2);
            int signAsk = random.Next(-1, 2);
            decimal factorBid = (decimal)random.NextDouble();
            decimal factorAsk = (decimal)random.NextDouble();

            const decimal noiseOffset = 0.1m;
            decimal factorOffset = (decimal)random.NextDouble();
            decimal offset = factorOffset * noiseOffset;

            decimal offsetBid = signBid * factorBid * offset;
            decimal offsetAsk = signAsk * factorAsk * offset;

            decimal newBid = Math.Max(0, security.Quote.Bid + offsetBid);
            decimal newAsk = Math.Max(0, security.Quote.Ask + offsetAsk);
            decimal newLastPrice = (newBid + newAsk) / 2;

            SecurityQuote newQuote = new SecurityQuote(newBid, newAsk, newLastPrice);
            SecurityIndex.SecurityIdToSecurityMapping[entry.Key].Quote = newQuote;
        }
    }
    
    #endregion Public
}