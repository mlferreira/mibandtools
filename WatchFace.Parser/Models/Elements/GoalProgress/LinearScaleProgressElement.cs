using System.Drawing;

namespace WatchFace.Parser.Models.Elements.GoalProgress
{
    public class LinearScaleProgressElement : ImageSetElement
    {
        public LinearScaleProgressElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public override void Draw(Graphics drawer, Bitmap[] resources, WatchState state)
        {
            // TODO: FIX
            var index = (int) (state.Steps * ImagesCount / state.Goal);
            Draw(drawer, resources, index);
        }
    }
}