namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderPacker
    {
        byte[] Register(long provinceID, long cityID, string producerID, string terminalType, string platenum, byte platecolor);
        byte[] Authentication(string authenticationNumber);
        byte[] Heartbeat();
        byte[] Position();
    }
}
