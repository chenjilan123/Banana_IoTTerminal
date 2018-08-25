namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderSender
    {
        string SimNum { get; }
        string Ip { get; }
        int Port { get; }
        ushort Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor);
        ushort Authentication(string authenticationCode);
        ushort Logout();
        ushort Heartbeat();
        ushort Position(uint alarmFlag, uint status, uint lontitude, uint latitude, ushort height, ushort speed, ushort direction, string time);
    }
}