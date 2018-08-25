namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderSender
    {
        string SimNum { get; }
        string Ip { get; }
        int Port { get; }
        ushort Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor);
        ushort Authentication(string authenticationCode);
        ushort Heartbeat();
        ushort Position(double lontitude, double latitude);
    }
}