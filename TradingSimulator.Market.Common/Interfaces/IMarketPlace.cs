using TradingSimulator.Market.Common.Messages;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Common.Interfaces;

public interface IMarketPlace
{
    #region Public

    public MarketSnapshot Snapshot { get; }

    public Company RegisterCompany(RegisterCompanyMessage message);

    public Client RegisterClient(RegisterClientMessage message);

    public (SecurityIsin isin, int volume) RegisterSecurity(RegisterSecurityMessage message);

    #endregion Public
}