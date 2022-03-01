using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements.WeatherElements
{
    public class WindObject
    {
        [ParameterId(1)]
        public ImageBoxObject Text { get; set; }

        [ParameterId(2)]
        [ParameterImageIndex]
        public long ImageSuffixEN { get; set; }
        
        [ParameterId(3)]
        [ParameterImageIndex]
        public long ImageSuffixCN1 { get; set; }
        
        [ParameterId(4)]
        [ParameterImageIndex]
        public long ImageSuffixCN2 { get; set; }
    }
}