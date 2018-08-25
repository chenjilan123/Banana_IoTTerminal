namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderSender
    {
        string SimNum { get; }
        string Ip { get; }
        int Port { get; }
        void Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor);
        void Authentication(string authenticationCode);
        void Heartbeat();
        void Position();
    }
}