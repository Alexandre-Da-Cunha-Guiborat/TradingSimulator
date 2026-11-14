using System.Timers;
using Microsoft.AspNetCore.Components;
using TradingSimulator.Market.Service;
using Timer = System.Timers.Timer;

namespace TradingSimulator.Market.WebApp.Components.Pages;

public partial class Home : IDisposable
{
    #region Public

    [Inject] public IHttpClientFactory HttpClientFactory { get; set; }

    public void Dispose()
    {
        _timer.Stop();
        _timer.Elapsed -= TimerElapsedHandler;
        _timer.Dispose();
    }

    #endregion Public

    #region Protected

    protected override async Task OnInitializedAsync()
    {
        using (HttpClient httpClient = HttpClientFactory.CreateClient())
        {
            await _appManager.InitializeAsync(httpClient);
        }

        _timer.Elapsed += TimerElapsedHandler;
        await base.OnInitializedAsync();
    }

    #endregion Protected

    #region Private

    private readonly AppManager _appManager = AppManager.Instance;
    private readonly Timer _timer = new Timer(10000);
    private readonly int[] _simulationTickInMsIntervals = [0, 100, 1000, 5000, 10000];

    private void TimerElapsedHandler(object? sender, ElapsedEventArgs e)
    {
        _appManager.MarketPlace.UpdateMarketQuote();

        InvokeAsync(StateHasChanged);
    }

    private void SimulationTickValueChangedHandler(int tickInterval)
    {
        _timer.Stop();
        if (tickInterval.Equals(0))
        {
            return;
        }

        _timer.Interval = tickInterval;
        _timer.Start();
    }

    private static string FormatTickInterval(int interval) => interval == 0 ? "Paused" : $"{interval} ms";

    #endregion Private
}
