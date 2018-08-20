namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderProvider
    {
        void Register(long provinceID, long cityID, string producerID, string terminalType, string platenum, byte platecolor);
        void Authentication(string authenticationNumber);
        void Heartbeat();
        void Position();
    }
}