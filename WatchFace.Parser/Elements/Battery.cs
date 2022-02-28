using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class Battery
    {
        [ParameterId(1)]
        public BatteryText BatteryText { get; set; }

        [ParameterId(2)]
        public ImageSetObject BatteryIcon { get; set; }

        [ParameterId(3)]
        public Scale Scale { get; set; }

        [ParameterId(5)]
        public long? Unknown5 { get; set; }

        [ParameterId(6)]
        public long? Unknown6 { get; set; }
    }
}