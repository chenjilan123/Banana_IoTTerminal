using System;
using System.Timers;

namespace IoTTerminal.Car.TerminalSystem
{
    public class GpsSystem
    {
        private readonly Timer positionTimer;
        private Action delPosition;
        public GpsSystem()
        {
            positionTimer = new Timer(30000);
            positionTimer.Elapsed += PositionTimer_Elapsed;
        }

        private void PositionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            positionTimer.Enabled = false;
            delPosition();
            positionTimer.Enabled = true;
        }

        public (double lon, double lat) NextPosition()
        {
            return (27.001012, 126.423945);
        }
        public void EnablePositionUpload(bool enabled, double interval)
        {
            positionTimer.Interval = interval;
            if (enabled != positionTimer.Enabled)
                positionTimer.Enabled = enabled;
        }

        public void SetPositionInterface(Action position)
        {
            delPosition = position;
        }
    }
}