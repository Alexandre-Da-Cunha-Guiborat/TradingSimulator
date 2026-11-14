namespace TradingSimulator.Market.Common.Models;

public sealed class MarketSnapshot
{
    #region Public
    
    public MarketSnapshotEntry[] Entries { get; }

    public MarketSnapshot(MarketSnapshotEntry[] entries)
    {
        Entries = entries;
    }
    
    public MarketSnapshot(IEnumerable<MarketSnapshotEntry> entries)
    {
        Entries = entries.ToArray();
    }
    
    #endregion Public
}