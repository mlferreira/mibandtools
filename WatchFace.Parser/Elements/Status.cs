using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.StatusElements;

namespace WatchFace.Parser.Elements
{
    public class Status
    {
        [ParameterId(1)]
        public StatusObject DoNotDisturb { get; set; }

        [ParameterId(2)]
        public StatusObject Lock { get; set; }

        [ParameterId(3)]
        public StatusObject Bluetooth { get; set; }

        [ParameterId(4)]
        public StatusObject Alarm { get; set; }
    }
}