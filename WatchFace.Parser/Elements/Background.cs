using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class Background
    {
        [ParameterId(1)]
        public Image Image { get; set; }
        
        [ParameterId(3)]
        public Image Preview1 { get; set; }
        
        [ParameterId(4)]
        public Image Preview2 { get; set; }
        
        [ParameterId(5)]
        public Image Preview3 { get; set; }
    }
}