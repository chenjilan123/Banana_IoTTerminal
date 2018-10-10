namespace IoTTerminal.Communication.Interface
{
    public interface IDownOrderParser : IMessageReceiver
    {
        void PlatCommonResponse(ushort orderID, byte[] body);
        void RegisterResponse(ushort orderID, byte[] body);
        //void SetTerminalParameter(ushort orderID, byte[] body);
        //void SearchTerminalParameter(ushort orderID, byte[] body);
        //void SearchSpecificTerminalParameter(ushort orderID, byte[] body);
        void DownCommand(ushort orderID, byte[] body);
    }
}
