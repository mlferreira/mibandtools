# JSON FORMAT

## Json
```json
{
  "Background": { // 2
    "Image": <Image>,
    "BackgroundColor": "0x000000",
    "Preview1": <Image>,
    "Preview2": <Image>,
    "Preview3": <Image>
  },
  "Time": { // 3
    "Hours": { // 3.1
      "Tens": <Image Set>,
      "Ones": <Image Set>
    },
    "Minutes": { // 3.2
      "Tens": <Image Set>,
      "Ones": <Image Set>
    },
    "UnknownV11": 0 // 3.11
  },
  "Activity": { // 4
    "Steps": { // 4.1
      "Number": <Image Box>
    },
    "Calories": { // 4.3
      "Text": <Image Box>,
      "SuffixImageIndex": 53, // 4.3.2
      "PrefixImageIndex": 52 // 4.3.3
    },
    "Pulse": { // 4.4
      "Number": <Image Box>,
      "NoDataImageIndex": 41 // 4.4.3
    },
    "UnknownV7": 0 // 4.7
  },
  "Date": { // 5
    "MonthAndDayAndYear": { // 5.1
      "Separate": { // 5.1.1
        "Month": <Image Box>,
        "Day": <Image Box>
      },
      "OneLine": {
        "Number": <Image Box>,
        "DelimiterImageIndex": 34
      },
      "TwoDigitsMonth": true, // 5.1.4
      "TwoDigitsDay": true // 5.1.5
    },
    "DayAmPm": { // 5.2
      "X": 104, // 5.2.1
      "Y": 288, // 5.2.2
      "ImageIndexAMCN": 56, // 5.2.3
      "ImageIndexPMCN": 57, // 5.2.4
      "ImageIndexAMEN": 58, // 5.2.5
      "ImageIndexPMEN": 59 // 5.2.6
    },
    "ENWeekDays": <Image Set>,
    "CNWeekDays": <Image Set>,
    "CN2WeekDays": <Image Set>
  },
  "StepsProgress": { // 7
    "LineScale": <Image Set>
  },
  "Status": { // 8
    "DoNotDisturb": { // 8.1
      "Coordinates": <Coordinates>,
      "ImageIndexOn": 71, // 8.1.2
      "ImageIndexOff": 40 // 8.1.3
    },
    "Lock": { // 8.2
      "Coordinates": <Coordinates>,
      "ImageIndexOff": 72 // 8.2.3
    },
    "Bluetooth": { // 8.3
      "Coordinates": <Coordinates>,
      "ImageIndexOn": 43, // 8.3.2
      "ImageIndexOff": 70  // 8.3.3
    }
  },
  "Battery": { // 9
    "BatteryText": { // 9.1
      "Coordinates": <Image Box>,
      "SuffixImageIndex": 84 // 9.1.4
    },
    "BatteryIcon": <Image Set>
  },
  "Other": {
    "Animation": [
      {
        "AnimationImages": <Image Set>,
        "Speed": 90,
        "RepeatCount": 50,
        "UnknownTF4": 1
      }
    ]
  },
  "Alarm": {
    "Text": <Composed Element>,
    "DelimiterImageIndex": 75,
    "ImageOn": <Image>,
    "ImageOff": <Image>,
    "ImageNoAlarm": <Image>,
    "UnknownTF6": 1,
    "UnknownTF7": 1
  },
  "HeartProgress": { // 12 
    "LineScale": <Image Set>
  },
  "CaloriesProgress": { // 15
    "LineScale": <Image Set>
  }
}
```

### Coordinates
```json
{ 
  "X": <number 0~152>,  // 1
  "Y": <number 0~486>   // 2
}
```

### Image
```json
{
  "X": <number 0~152>,    // 1
  "Y": <number 0~486>,    // 2
  "ImageIndex": <number>  // 3
}
```

### Image Set
```json
{
  "X": <number 0~152>,     // 1
  "Y": <number 0~486>,     // 2
  "ImageIndex": <number>,  // 3
  "ImagesCount": <number>  // 4
}
```

#### Image Box
```json
{ 
    "TopLeftX": <number 0~152>,      // 1
    "TopLeftY": <number 0~486>,      // 2
    "BottomRightX": <number 0~152>,  // 3
    "BottomRightY": <number 0~486>,  // 4
    "Alignment": <Alignment>,        // 5
    "SpacingX": <number>,            // 6
    "SpacingY": <number>,            // 7
    "ImageIndex": <number>,          // 8
    "ImagesCount": <number>          // 9
    }
```

##### Alignment
"TopLeft" = 18
"TopCenter" = 24
"TopRight"


## Full Json Example
```json
{
  "Background": { // 2
    "Image": { // 2.1
      "X": 0, // 2.1.1
      "Y": 0, // 2.1.2
      "ImageIndex": 0 // 2.1.3
    },
    "BackgroundColor": "0x000000",
    "Preview1": { // 2.3
      "X": 21, // 2.3.1
      "Y": 30, // 2.3.2
      "ImageIndex": 2 // 2.3.3
    },
    "Preview2": { // 2.4
      "X": 21, // 2.4.1
      "Y": 30, // 2.4.2
      "ImageIndex": 3 // 2.4.3
    },
    "Preview3": { // 2.5
      "X": 21, // 2.5.1
      "Y": 30, // 2.5.2
      "ImageIndex": 1 // 2.5.3
    }
  },
  "Time": { // 3
    "Hours": { // 3.1
      "Tens": { // 3.1.1
        "X": 38, // 3.1.1.1
        "Y": 106, // 3.1.1.2
        "ImageIndex": 4, // 3.1.1.3
        "ImagesCount": 10 // 3.1.1.4
      },
      "Ones": { // 3.1.2
        "X": 76, // 3.1.2.1
        "Y": 106, // 3.1.2.2
        "ImageIndex": 4, // 3.1.2.3
        "ImagesCount": 10 // 3.1.2.4
      }
    },
    "Minutes": { // 3.2
      "Tens": { // 3.2.1
        "X": 38, // 3.2.1.1
        "Y": 175, // 3.2.1.2
        "ImageIndex": 14, // 3.2.1.3
        "ImagesCount": 10 // 3.2.1.4
      },
      "Ones": { // 3.2.2
        "X": 76, // 3.2.2.1
        "Y": 175, // 3.2.2.2
        "ImageIndex": 14, // 3.2.2.3
        "ImagesCount": 10 // 3.2.2.4
      }
    },
    "TimeDelimiterImage": { // 3.6
      "X": 70, // 3.6.1
      "Y": 210, // 3.6.2
      "ImageIndex": 19 // 3.6.3
    },
    "TimeZone1": { // 3.7
      "TopLeftX": 32,
      "TopLeftY": 185,
      "BottomRightX": 148,
      "BottomRightY": 301,
      "Alignment": "TopRight",
      "SpacingX": 0,
      "SpacingY": 0,
      "ImageIndex": 120,
      "ImagesCount": 10
    },
    "TimeZone1DelimiterImage": 130, // 3.8
    "TimeZone2": { // 3.9
      "TopLeftX": 0,
      "TopLeftY": 155,
      "BottomRightX": 148,
      "BottomRightY": 301,
      "Alignment": "TopRight",
      "SpacingX": 0,
      "SpacingY": 0,
      "ImageIndex": 120,
      "ImagesCount": 10
    },
    "TimeZone2DelimiterImage": 130, // 3.10
    "UnknownV11": 0, // 3.11
    "TimeZone1NoTime": { // 3.12
      "X": 113,
      "Y": 281,
      "ImageIndex": 133
    },
    "TimeZone2NoTime": { // 3.13
      "X": 0, // 3.13.1
      "Y": 150, // 3.13.2
      "ImageIndex": 133 // 3.13.3
    }
  },
  "Activity": { // 4
    "Steps": { // 4.1
      "Number": { // 4.1.1
        "TopLeftX": 46, // 4.1.1.1
        "TopLeftY": 258, // 4.1.1.2
        "BottomRightX": 125, // 4.1.1.3
        "BottomRightY": 280, // 4.1.1.4
        "Alignment": "TopRight", // 4.1.1.5
        "SpacingX": -4, // 4.1.1.6
        "SpacingY": 0, // 4.1.1.7
        "ImageIndex": 60, // 4.1.1.8
        "ImagesCount": 10 // 4.1.1.9
      },
      "SuffixImageIndex": 53 // 4.1.3
    },
    "Calories": { // 4.3
      "Text": { // 4.3.1
        "TopLeftX": 48, // 4.3.1.1
        "TopLeftY": 368, // 4.3.1.2
        "BottomRightX": 104, // 4.3.1.3
        "BottomRightY": 389, // 4.3.1.4
        "Alignment": "TopCenter", // 4.3.1.5
        "SpacingX": 0, // 4.3.1.6
        "SpacingY": 0, // 4.3.1.7
        "ImageIndex": 42, // 4.3.1.8
        "ImagesCount": 10 // 4.3.1.9
      },
      "SuffixImageIndex": 53, // 4.3.2
      "PrefixImageIndex": 52 // 4.3.3
    },
    "Pulse": { // 4.4
      "Number": { // 4.4.1
        "TopLeftX": 49, // 4.4.1.1
        "TopLeftY": 337, // 4.4.1.2
        "BottomRightX": 103, // 4.4.1.3
        "BottomRightY": 357, // 4.4.1.4
        "Alignment": "TopCenter", // 4.4.1.5 (TopCenter = 24)
        "SpacingX": 2, // 4.4.1.6
        "SpacingY": 0, // 4.4.1.7
        "ImageIndex": 12, // 4.4.1.8
        "ImagesCount": 10 // 4.4.1.9
      },
      "NoDataImageIndex": 41, // 4.4.3
      "SuffixImageIndex": 53 // 4.4.4
    },
    "Distance": { // 4.5
      "Number": { // 4.5.1
        "TopLeftX": 0, // 4.5.1.1
        "TopLeftY": 392, // 4.5.1.2
        "BottomRightX": 152, // 4.5.1.3
        "BottomRightY": 405, // 4.5.1.4
        "Alignment": "TopCenter", // 4.5.1.5
        "SpacingX": 0, // 4.5.1.6
        "SpacingY": 0, // 4.5.1.7
        "ImageIndex": 94, // 4.5.1.8
        "ImagesCount": 10 // 4.5.1.9
      },
      "KmSuffixImageIndex": 21, // 4.5.2
      "DecimalPointImageIndex": 20, // 4.5.3
      "MilesSuffixImageIndex": 40 // 4.5.4
    },
    "PAI": { // 4.6
      "Number": { // 4.6.1
        "TopLeftX": 75, // 4.6.1.1
        "TopLeftY": 448, // 4.6.1.2
        "BottomRightX": 105, // 4.6.1.3
        "BottomRightY": 217, // 4.6.1.4
        "Alignment": "TopCenter", // 4.6.1.5
        "SpacingX": 0, // 4.6.1.6
        "SpacingY": 0, // 4.6.1.7
        "ImageIndex": 94, // 4.6.1.8
        "ImagesCount": 10 // 4.6.1.9
      }
    },
    "UnknownV7": 0 // 4.7
  },
  "Date": { // 5
    "MonthAndDayAndYear": { // 5.1
      "Separate": { // 5.1.1
        "Month": { 
          "TopLeftX": 9,
          "TopLeftY": 174,
          "BottomRightX": 10,
          "BottomRightY": 175,
          "Alignment": "TopLeft",
          "SpacingX": -26,
          "SpacingY": 21,
          "ImageIndex": 65,
          "ImagesCount": 10
        },
        "MonthsEN": {
          "X": 44,
          "Y": 190,
          "ImageIndex": 110,
          "ImagesCount": 12
        },
        "MonthsCN": {
          "X": 44,
          "Y": 190,
          "ImageIndex": 110,
          "ImagesCount": 12
        },
        "Day": { // 5.1.1.4
          "TopLeftX": 9,  // 5.1.1.4.1
          "TopLeftY": 128,  // 5.1.1.4.2
          "BottomRightX": 10,  // 5.1.1.4.3
          "BottomRightY": 129,  // 5.1.1.4.4
          "Alignment": "TopLeft", // 5.1.1.4.5 (TopLeft = 18)
          "SpacingX": -26, // 5.1.1.4.6
          "SpacingY": 21, // 5.1.1.4.7
          "ImageIndex": 55, // 5.1.1.4.8
          "ImagesCount": 10 // 5.1.1.4.9
        }
      },
      "OneLine": { // 5.1.2
        "Number": { // 5.1.2.1
          "TopLeftX": 49,
          "TopLeftY": 288,
          "BottomRightX": 103,
          "BottomRightY": 308,
          "Alignment": "TopLeft",
          "SpacingX": -4,
          "SpacingY": 0,
          "ImageIndex": 24,
          "ImagesCount": 10
        },
        "DelimiterImageIndex": 34 // 5.1.2.2
      },
      "TwoDigitsMonth": true, // 5.1.4
      "TwoDigitsDay": true // 5.1.5
    },
    "DayAmPm": { // 5.2
      "X": 104, // 5.2.1
      "Y": 288, // 5.2.2
      "ImageIndexAMCN": 56, // 5.2.3
      "ImageIndexPMCN": 57, // 5.2.4
      "ImageIndexAMEN": 58, // 5.2.5
      "ImageIndexPMEN": 59 // 5.2.6
    },
    "ENWeekDays": { // 5.4
      "X": 14, // 5.4.1
      "Y": 288, // 5.4.2
      "ImageIndex": 35, // 5.4.3
      "ImagesCount": 7 // 5.4.4
    },
    "CNWeekDays": { // 5.5
      "X": 14, // 5.5.1
      "Y": 288, // 5.5.2
      "ImageIndex": 49, // 5.5.3
      "ImagesCount": 7 // 5.5.4
    },
    "CN2WeekDays": { // 5.6
      "X": 14, // 5.6.1
      "Y": 288, // 5.6.2
      "ImageIndex": 42, // 5.6.3
      "ImagesCount": 7 // 5.6.4
    },
    "Unknown7": { // 5.7
      "X": 104, // 5.7.1
      "Y": 271 // 5.7.2
    }
  },
  "Weather": { // 6
    "Icon": { // 6.1
      "CustomIcon": { // 6.1.2
        "X": 22, // 6.1.2.1
        "Y": 85, // 6.1.2.2
        "ImageIndex": 22, // 6.1.2.3
        "ImagesCount": 26 // 6.1.2.4
      },
      "Unknown3": { // 6.1.3
        "X": 22, // 6.1.3.1
        "Y": 100 // 6.1.3.2
      },
      "Unknown4": { // 6.1.4
        "X": 22, // 6.1.4.1
        "Y": 100 // 6.1.4.2
      }
    },
    "Temperature": { // 6.2
      "Current": { // 6.2.1
        "Number": { // 6.2.1.1
          "TopLeftX": 4, // 6.2.1.1.1
          "TopLeftY": 130, // 6.2.1.1.2
          "BottomRightX": 76, // 6.2.1.1.3
          "BottomRightY": 163, // 6.2.1.1.4
          "Alignment": "TopCenter", // 6.2.1.1.5
          "SpacingX": 0, // 6.2.1.1.6
          "SpacingY": 0, // 6.2.1.1.7
          "ImageIndex": 104, // 6.2.1.1.8
          "ImagesCount": 10 // 6.2.1.1.9
        },
        "MinusImageIndex": 91, // 6.2.1.2
        "DegreesImageIndex": 92 // 6.2.1.3
      },
      "Today": { // 6.2.2
        "OneLine": { // 6.2.2.2
          "Number": { // 6.2.2.2.1
            "TopLeftX": 4,
            "TopLeftY": 157,
            "BottomRightX": 79,
            "BottomRightY": 143,
            "Alignment": "TopCenter",
            "SpacingX": 0,
            "SpacingY": 0,
            "ImageIndex": 94,
            "ImagesCount": 10
          },
          "MinusSignImageIndex": 91, // 6.2.2.2.2
          "DelimiterImageIndex": 90, // 6.2.2.2.3
          "AppendDegreesForBoth": true, // 6.2.2.2.4
          "DegreesImageIndex": 92 // 6.2.2.2.5
        }
      }
    },
    "AirPollution": { // 6.3
      "Icon": { // 6.3.2
        "X": 10,
        "Y": 180,
        "ImageIndex": 66,
        "ImagesCount": 6
      }
    },
    "Humidity": { // 6.4
      "Text": { // 6.4.1
        "TopLeftX": 108,
        "TopLeftY": 76,
        "BottomRightX": 148,
        "BottomRightY": 91,
        "Alignment": "TopLeft",
        "SpacingX": 0,
        "SpacingY": 0,
        "ImageIndex": 94,
        "ImagesCount": 10
      },
      "SuffixImageIndex": 118 // 6.4.2
    },
    "Wind": { // 6.5
      "Text": { // 6.5.1
        "TopLeftX": 108,
        "TopLeftY": 101,
        "BottomRightX": 146,
        "BottomRightY": 114,
        "Alignment": "TopLeft",
        "SpacingX": 0,
        "SpacingY": 0,
        "ImageIndex": 94,
        "ImagesCount": 10
      },
      "ImageSuffixEN": 119, // 6.5.2
      "ImageSuffixCN1": 119, // 6.5.3
      "ImageSuffixCN2": 119 // 6.5.4
    },
    "UVIndex": { // 6.6
      "UV": { // 6.6.1
        "Text": { // 6.6.1.1
          "TopLeftX": 108,
          "TopLeftY": 126,
          "BottomRightX": 142,
          "BottomRightY": 137,
          "Alignment": "TopLeft",
          "SpacingX": 0,
          "SpacingY": 0,
          "ImageIndex": 94,
          "ImagesCount": 10
        },
        "SuffixImageIndex": 77 // 6.6.1.2
      },
      "UVCN": { // 6.6.2
        "X": 108,
        "Y": 126,
        "ImageIndex": 72,
        "ImagesCount": 5
      },
      "UVCN2": { // 6.6.3
        "X": 108,
        "Y": 126,
        "ImageIndex": 72,
        "ImagesCount": 5
      }
    }
  },
  "StepsProgress": { // 7
    "LineScale": { // 7.2
      "X": 21, // 7.2.1
      "Y": 432, // 7.2.2
      "ImageIndex": 74, // 7.2.3
      "ImagesCount": 10 // 7.2.4
    },
    "CircleScale": { // 7.4
      "CenterX": 76, // 7.4.1
      "CenterY": 387, // 7.4.2
      "RadiusX": 50, // 7.4.3
      "RadiusY": 50, // 7.4.4
      "StartAngle": 335, // 7.4.5
      "EndAngle": 25, // 7.4.6
      "Width": 5, // 7.4.7
      "Color": "0x2D92D2" // 7.4.8
    }
  },
  "Status": { // 8
    "DoNotDisturb": { // 8.1
      "Coordinates": { // 8.1.1
        "X": 49, // 8.1.1.1
        "Y": 84 // 8.1.1.2
      },
      "ImageIndexOn": 71, // 8.1.2
      "ImageIndexOff": 40 // 8.1.3
    },
    "Lock": { // 8.2
      "Coordinates": { // 8.2.1
        "X": 69, // 8.2.1.1
        "Y": 84 // 8.2.1.2
      },
      "ImageIndexOn": 71, // 8.2.2
      "ImageIndexOff": 72 // 8.2.3
    },
    "Bluetooth": { // 8.3
      "Coordinates": { // 8.3.1
        "X": 89, // 8.3.1.1
        "Y": 84  // 8.3.1.2
      },
      "ImageIndexOn": 43, // 8.3.2
      "ImageIndexOff": 70  // 8.3.3
    }
  },
  "Battery": { // 9
    "BatteryText": { // 9.1
      "Coordinates": { // 9.1.1
        "TopLeftX": 63, // 9.1.1.1
        "TopLeftY": 55, // 9.1.1.2
        "BottomRightX": 112, // 9.1.1.3
        "BottomRightY": 77, // 9.1.1.4
        "Alignment": "TopLeft", // 9.1.1.5
        "SpacingX": -4, // 9.1.1.6
        "SpacingY": 0, // 9.1.1.7
        "ImageIndex": 73, // 9.1.1.8
        "ImagesCount": 10 // 9.1.1.9
      },
      "PrefixImageIndex": 83, // 9.1.?
      "SuffixImageIndex": 84 // 9.1.4
    },
    "BatteryIcon": { // 9.2
      "X": 11, // 9.2.1
      "Y": 10, // 9.2.2
      "ImageIndex": 83, // 9.2.3
      "ImagesCount": 10 // 9.2.4
    },
    "Linear": { // 9.3
      "StartImageIndex": 48, // 9.3.1
      "Segments": [ // 9.3.2
        {
          "X": 42, // 9.3.2.1
          "Y": 25 // 9.3.2.2
        },
        // ...
        {
          "X": 105, // 9.3.2.1
          "Y": 25 // 9.3.2.2
        }
      ]
    }
  },
  "Other": { // 11
    "Animation": [ // 11.1
      {
        "AnimationImages": { // 11.1.1
          "X": 0, // 11.1.1.1
          "Y": 222, // 11.1.1.2
          "ImageIndex": 0, // 11.1.1.3
          "ImagesCount": 19 // 11.1.1.4
        },
        "Speed": 90, // 11.1.2
        "RepeatCount": 50, // 11.1.3
        "UnknownTF4": 1 // 11.1.4
      }
    ]
  },
  "HeartProgress": { // 12 
    "LineScale": { // 12.2
      "X": 21, // 12.2.1
      "Y": 307, // 12.2.2
      "ImageIndex": 54, // 12.2.3
      "ImagesCount": 10 // 12.2.4
    },
    "Linear": { // 12.3
      "StartImageIndex": 134, // 12.3.1
      "Segments": [ // 12.3.2
        {
          "X": 8, // 12.3.2.1
          "Y": 414 // 12.3.2.2
        },
        // ...
        {
          "X": 8, // 12.3.2.1
          "Y": 360 // 12.3.2.2
        }
      ]
    }
  },
  "CaloriesProgress": { // 15
    "LineScale": { // 15.2
      "X": 21, // 15.2.1
      "Y": 364, // 15.2.2
      "ImageIndex": 64, // 15.2.3
      "ImagesCount": 10 // 15.2.4
    },
    "Linear": { // 15.3
      "StartImageIndex": 80, // 15.3.1
      "Segments": [ // 15.3.2
        {
          "X": 132, // 15.3.2.1
          "Y": 414 // 15.3.2.2
        },
        // ...
        {
          "X": 132, // 15.3.2.1
          "Y": 360 // 15.3.2.2
        }
      ]
    }
  },
  "Alarm": { // 18
    "Text": { // 18.1
      "TopLeftX": 145,
      "TopLeftY": 67,
      "BottomRightX": 945,
      "BottomRightY": 68,
      "Alignment": "TopRight",
      "SpacingX": 0,
      "SpacingY": 0,
      "ImageIndex": 65,
      "ImagesCount": 10
    },
    "DelimiterImageIndex": 75, // 18.2
    "ImageOn": { // 18.3
      "X": 122,
      "Y": 98,
      "ImageIndex": 42
    },
    "ImageOff": { // 18.4
      "X": 122,
      "Y": 98,
      "ImageIndex": 39
    },
    "ImageNoAlarm": { // 18.5
      "X": 345,
      "Y": 0,
      "ImageIndex": 75
    },
    "UnknownTF6": 1, // 18.6
    "UnknownTF7": 1 // 18.7
  },
  "LunarDateCN1": { // 21
    "LunarMonth": { // 21.1
      "X": 38, // 21.1.1
      "Y": 300, // 21.1.2
      "ImageIndex": 144, // 21.1.3
      "ImagesCount": 12 // 21.1.4
    },
    "LunarDay1": { // 21.2
      "TopLeftX": 76, // 21.2.1
      "TopLeftY": 300, // 21.2.2
      "BottomRightX": 114, // 21.2.3
      "BottomRightY": 285, // 21.2.4
      "Alignment": "TopLeft", // 21.2.5
      "SpacingX": 1, // 21.2.6
      "SpacingY": 0, // 21.2.7
      "ImageIndex": 156, // 21.2.8
      "ImagesCount": 9 // 21.2.9
    },
    "LunarDayOf0X": 165, // 21.3
    "LunarDayOf2X": 166, // 21.4
    "LunarDayOf10": 169, // 21.5
    "LunarDayOf20": 167, // 21.6
    "LunarDayOf30": 168 // 21.7
  }
}
```