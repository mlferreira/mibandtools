using WatchFace.Parser.Attributes;

namespace WatchFace.Parser.Elements.DateElements
{
    public class DayAmPm
    {
        [ParameterId(1)]
        public long X { get; set; }

        [ParameterId(2)]
        public long Y { get; set; }

        [ParameterId(3)]
        [ParameterImageIndex]
        public long ImageIndexAMCN { get; set; }

        [ParameterId(4)]
        [ParameterImagesCount]
        public long ImageIndexPMCN { get; set; }
        
        [ParameterId(5)]
        [ParameterImagesCount]
        public long ImageIndexAMEN { get; set; }
        
        [ParameterId(6)]
        [ParameterImagesCount]
        public long ImageIndexPMEN { get; set; }
    }
}