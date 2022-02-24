using WatchFace.Parser.Models.Elements.GoalProgress;

namespace WatchFace.Parser.Models.Elements
{
    public class GoalProgressElement : ContainerElement
    {
        public GoalProgressElement(Parameter parameter, Element parent = null, string name = null) :
            base(parameter, parent, name) { }

        public GoalReachedElement GoalReached { get; set; }
        public LinearScaleProgressElement LineScale { get; set; }
        public CircularGoalProgressElement Circular { get; set; }

        protected override Element CreateChildForParameter(Parameter parameter)
        {
            switch (parameter.Id)
            {
                case 1:
                    GoalReached = new GoalReachedElement(parameter, this);
                    return GoalReached;
                case 2:
                    LineScale = new LinearScaleProgressElement(parameter, this);
                    return LineScale;
                case 3:
                    Circular = new CircularGoalProgressElement(parameter, this);
                    return Circular;
                default:
                    return base.CreateChildForParameter(parameter);
            }
        }
    }
}