namespace IoTTerminal.Communication.Interface
{
    public interface IDownOrderReceiver
    {
        void PlatCommonResponse(ushort responseOrderID, byte result);
        void RegisterResponse(ushort responseOrderID, byte result, string authentication);
        //void SetTerminalParameter(byte[] body);
        //void SearchTerminalParameter(byte[] body);
        //void SearchSpecificTerminalParameter(byte[] body);
    }
}