namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderProvider
    {
        void Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor);
        void Authentication(string authenticationNumber);
        void Heartbeat();
        void Position();
    }
}