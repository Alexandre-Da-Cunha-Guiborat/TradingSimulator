using System.Collections.Concurrent;
using TradingSimulator.Market.Common.Messages;
using TradingSimulator.Market.Common.Models;

namespace TradingSimulator.Market.Engine.Indexes;

public sealed class ClientIndex
{
    #region Public

    public ConcurrentDictionary<ClientId, Client> ClientIdToClientMapping { get; }
    
    public ClientIndex()
    {
        ClientIdToClientMapping = [];
    }

    public Client RegisterClient(RegisterClientMessage message)
    {
        Client client = new Client(new ClientId(Guid.NewGuid()), message.Name, []);
        ClientIdToClientMapping.TryAdd(client.Id, client);
        return client;
    }

    #endregion Public
}