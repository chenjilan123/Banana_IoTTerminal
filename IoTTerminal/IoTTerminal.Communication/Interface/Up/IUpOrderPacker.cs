namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderPacker
    {
        byte[] TerminalCommonResponse(ushort orderID, ushort messageID, byte result, out ushort headerOrderID);
        byte[] Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor, out ushort headerOrderID);
        byte[] Authentication(string authenticationNumber, out ushort headerOrderID);
        byte[] Heartbeat(out ushort headerOrderID);
        byte[] Position(double lontitude, double latitude, out ushort headerOrderID);
    }
}
