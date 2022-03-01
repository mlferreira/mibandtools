using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.WeatherElements
{
    public class UVIndexObject
    {
        [ParameterId(1)]
        public TextBoxObject UV { get; set; }

        [ParameterId(2)]
        public ImageSetObject UVCN1 { get; set; }
        
        [ParameterId(3)]
        public ImageSetObject UVCN2 { get; set; }
        
    }
}