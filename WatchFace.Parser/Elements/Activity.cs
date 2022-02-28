﻿using WatchFace.Parser.Attributes;
using WatchFace.Parser.Elements.ActivityElements;
using WatchFace.Parser.Elements.BasicElements;

namespace WatchFace.Parser.Elements
{
    public class Activity
    {
        [ParameterId(1)]
        public StepsObject Steps { get; set; }

        [ParameterId(2)]
        public ImageBoxObject StepsGoal { get; set; }

        [ParameterId(3)]
        public Calories Calories { get; set; }

        [ParameterId(4)]
        public PulseObject Pulse { get; set; }

        [ParameterId(5)]
        public FormattedNumber Distance { get; set; }
        
        [ParameterId(7)]
        public long? Unknown7 { get; set; }
    }
}