namespace TradingSimulator.Market.Common.Models;

public sealed class Client
{
    #region Public

    public ClientId Id { get; }

    public string Name { get; }

    public List<SecurityId> Positions { get; }

    public Client(ClientId id, string name, List<SecurityId> positions)
    {
        Id = id;
        Name = name;
        Positions = positions;
    }

    #endregion Public
}