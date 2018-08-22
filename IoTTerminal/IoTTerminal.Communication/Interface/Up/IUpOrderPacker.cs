namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderPacker
    {
        byte[] TerminalCommonResponse(ushort orderID, ushort messageID, byte result);
        byte[] Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor);
        byte[] Authentication(string authenticationNumber);
        byte[] Heartbeat();
        byte[] Position();
    }
}
