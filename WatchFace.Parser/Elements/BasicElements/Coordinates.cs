using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements.BasicElements
{
    public class Coordinates
    {
        [ParameterId(1)]
        public long X { get; set; }

        [ParameterId(2)]
        public long Y { get; set; }
        
        [ParameterId(3)]
        public long ImageIndex { get; set; }
        
        [ParameterId(4)]
        public long ImagesCount { get; set; }
    }
}