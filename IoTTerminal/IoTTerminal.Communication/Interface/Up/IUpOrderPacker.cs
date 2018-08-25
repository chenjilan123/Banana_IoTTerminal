namespace IoTTerminal.Communication.Interface
{
    public interface IUpOrderPacker
    {
        byte[] TerminalCommonResponse(ushort orderID, ushort messageID, byte result, out ushort headerOrderID);
        byte[] Register(ushort provinceID, ushort cityID, string producerID, string terminalType, string terminalID, string platenum, byte platecolor, out ushort headerOrderID);
        byte[] Authentication(string authenticationNumber, out ushort headerOrderID);
        byte[] Logout(out ushort headerOrderID);
        byte[] Heartbeat(out ushort headerOrderID);
        byte[] Position(uint alarmFlag, uint status, uint lontitude, uint latitude, ushort height, ushort speed, ushort direction, string time, out ushort headerOrderID);
    }
}
