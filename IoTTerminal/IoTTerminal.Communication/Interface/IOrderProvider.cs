using IoTTerminal.Communication.Interface;

namespace IoTTerminal.Communication.Interface
{
    public interface IOrderProvider : IDownOrderProvider, IUpOrderProvider
    {
        string SimNum { get; }
        string Ip { get; }
        int Port { get; }
    }
}
