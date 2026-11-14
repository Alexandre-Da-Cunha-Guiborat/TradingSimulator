using Microsoft.AspNetCore.Components;
using TradingSimulator.Market.Common.Enums;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.WebApp.Components.Widgets;

public partial class MarketSnapshotWidget
{
    #region Public

    [Parameter] public required MarketSnapshot Snapshot { get; set; }

    [Parameter] public bool Summarized { get; set; }

    #endregion Public

    #region Private

    private MarketSnapshot _formattedSnapshot => Summarized ? SummurizeMarketSnapshot(Snapshot) : Snapshot;

    private static string FormatCurrency(decimal value) => value.Equals(decimal.MinValue) ? "—" : value.ToString("c");

    private MarketSnapshot SummurizeMarketSnapshot(MarketSnapshot snapshot)
    {
        Dictionary<SecurityIsin, MarketSnapshotEntry> summarizedMarketSnapshots = [];
        foreach (MarketSnapshotEntry entry in snapshot.Entries)
        {
            MarketSnapshotEntry summarizedEntry;
            if (!summarizedMarketSnapshots.TryGetValue(entry.Isin, out summarizedEntry))
            {
                summarizedMarketSnapshots.Add(entry.Isin, entry);
                continue;
            }

            decimal bid = summarizedEntry.Quote.Bid < entry.Quote.Bid ? entry.Quote.Bid : summarizedEntry.Quote.Bid;
            decimal ask = summarizedEntry.Quote.Ask < entry.Quote.Ask ? summarizedEntry.Quote.Ask : entry.Quote.Ask;
            decimal lastPrice = summarizedEntry.Quote.LastPrice < entry.Quote.LastPrice
                ? entry.Quote.LastPrice
                : summarizedEntry.Quote.LastPrice;

            CompanyLei lei = entry.Lei;
            string companyName = entry.Name;
            SecurityIsin isin = entry.Isin;
            SecurityTicker ticker = entry.Ticker;
            string name = entry.Name;
            SecurityType type = entry.Type;
            SecurityQuote quote = new SecurityQuote(bid, ask, lastPrice);
            summarizedMarketSnapshots[isin] =
                new MarketSnapshotEntry(lei, companyName, isin, ticker, name, type, quote);
        }

        MarketSnapshot summarizedSnapshot = new MarketSnapshot(summarizedMarketSnapshots.Values);
        return summarizedSnapshot;
    }

    #endregion Private
}