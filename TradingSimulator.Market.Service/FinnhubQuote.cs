using System.Text.Json.Serialization;

namespace TradingSimulator.Market.Service;

public class FinnhubQuote
{
    [JsonPropertyName("c")]
    public double Current { get; set; }

    [JsonPropertyName("h")]
    public double High { get; set; }

    [JsonPropertyName("l")]
    public double Low { get; set; }
}