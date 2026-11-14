namespace TradingSimulator.Market.Common.Messages;

public readonly ref struct RegisterClientMessage
{
    #region Public
    
    public string Name { get; }

    public RegisterClientMessage(string name)
    {
        Name = name;
    }

    #endregion Public
}