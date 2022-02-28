using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class Background
    {
        [ParameterId(1)]
        public ImageObject Image { get; set; }
        
        // TODO
        // [ParameterId(2)]
        // public String BackgroundColor { get; set; }
        
        [ParameterId(3)]
        public ImageObject Preview1 { get; set; }
        
        [ParameterId(4)]
        public ImageObject Preview2 { get; set; }
        
        [ParameterId(5)]
        public ImageObject Preview3 { get; set; }
    }
}