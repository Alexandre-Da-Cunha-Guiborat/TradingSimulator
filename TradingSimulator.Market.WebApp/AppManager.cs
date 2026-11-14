using Microsoft.AspNetCore.Components;
using TradingSimulator.Market.Common.Interfaces;
using TradingSimulator.Market.Service;
using Timer = System.Timers.Timer;

namespace TradingSimulator.Market.WebApp;

public sealed class AppManager
{
    #region Singleton

    private static Lazy<AppManager> _instance = new(() => new AppManager());

    private AppManager() { }

    public static AppManager Instance => _instance.Value;

    #endregion Singleton

    #region Public

    public readonly Sp500Market MarketPlace = new Sp500Market();

    public async Task InitializeAsync(HttpClient httpClient)
    {
        if (_isInitialized)
        {
            return;
        }

        _isInitialized = true;
        await MarketPlace.InitializeAsync(httpClient);
    }

    #endregion Public

    #region Private

    private bool _isInitialized;
    private readonly Timer _timer = new Timer(10000);
    private readonly int[] _simulationTickInMsIntervals = [0, 100, 1000, 5000, 10000];

    #endregion Private
}
