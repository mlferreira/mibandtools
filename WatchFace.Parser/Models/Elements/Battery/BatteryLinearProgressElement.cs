using System.Drawing;
using WatchFace.Parser.Models.Elements.GoalProgress;

namespace WatchFace.Parser.Models.Elements.Battery
{
    public class BatteryLinearProgressElement : LinearProgressElement
    {
        public BatteryLinearProgressElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public override void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            Draw(drawer, resources, state.BatteryLevel, 100);
        }
    }
}