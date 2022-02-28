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
    "UnknownV11": 0 // 3.11
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
      }
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
      "NoDataImageIndex": 41 // 4.4.3
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
      "OneLine": {
        "Number": {
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
    "ENWeekDays": { // 5.4
      "X": 14, // 5.4.1
      "Y": 288, // 5.4.2
      "ImageIndex": 35, // 5.4.3
      "ImagesCount": 7 // 5.4.4
    },
    "CNWeekDays": {
      "X": 14,
      "Y": 288,
      "ImageIndex": 49,
      "ImagesCount": 7
    },
    "CN2WeekDays": {
      "X": 14,
      "Y": 288,
      "ImageIndex": 42,
      "ImagesCount": 7
    }
  },
  "StepsProgress": { // 7
    "LineScale": { // 7.2
      "X": 21, // 7.2.1
      "Y": 432, // 7.2.2
      "ImageIndex": 74, // 7.2.3
      "ImagesCount": 10 // 7.2.4
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
      "SuffixImageIndex": 84 // 9.1.4
    },
    "BatteryIcon": { // 9.2
      "X": 11, // 9.2.1
      "Y": 10, // 9.2.2
      "ImageIndex": 83, // 9.2.3
      "ImagesCount": 10 // 9.2.4
    }
  },
  "Other": {
    "Animation": [
      {
        "AnimationImages": {
          "X": 0,
          "Y": 222,
          "ImageIndex": 0,
          "ImagesCount": 19
        },
        "Speed": 90,
        "RepeatCount": 50,
        "UnknownTF4": 1
      }
    ]
  },
  "Alarm": {
    "Text": {
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
    "DelimiterImageIndex": 75,
    "ImageOn": {
      "X": 122,
      "Y": 98,
      "ImageIndex": 42
    },
    "ImageOff": {
      "X": 122,
      "Y": 98,
      "ImageIndex": 39
    },
    "ImageNoAlarm": {
      "X": 345,
      "Y": 0,
      "ImageIndex": 75
    },
    "UnknownTF6": 1,
    "UnknownTF7": 1
  },
  "HeartProgress": { // 12 
    "LineScale": { // 12.2
      "X": 21, // 12.2.1
      "Y": 307, // 12.2.2
      "ImageIndex": 54, // 12.2.3
      "ImagesCount": 10 // 12.2.4
    }
  },
  "CaloriesProgress": { // 15
    "LineScale": { // 15.2
      "X": 21, // 15.2.1
      "Y": 364, // 15.2.2
      "ImageIndex": 64, // 15.2.3
      "ImagesCount": 10 // 15.2.4
    }
  }
}
```