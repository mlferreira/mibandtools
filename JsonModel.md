# Mi Band Tools

```json
{
  "Background": { // 2
    "Image": { // 2.1
      "X": 0, // 2.1.1
      "Y": 0, // 2.1.2
      "ImageIndex": 0 // 2.1.3
    },
    "BackgroundColor": "0x000000",
    "Preview1": {
      "X": 21,
      "Y": 30,
      "ImageIndex": 2
    },
    "Preview2": {
      "X": 21,
      "Y": 30,
      "ImageIndex": 3
    },
    "Preview3": {
      "X": 21,
      "Y": 30,
      "ImageIndex": 1
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
    "Minutes": {
      "Tens": {
        "X": 38,
        "Y": 175,
        "ImageIndex": 14,
        "ImagesCount": 10
      },
      "Ones": {
        "X": 76,
        "Y": 175,
        "ImageIndex": 14,
        "ImagesCount": 10
      }
    },
    "UnknownV11": 0
  },
  "Activity": {
    "Steps": {
      "Number": {
        "TopLeftX": 46,
        "TopLeftY": 258,
        "BottomRightX": 125,
        "BottomRightY": 280,
        "Alignment": "TopRight",
        "SpacingX": -4,
        "SpacingY": 0,
        "ImageIndex": 60,
        "ImagesCount": 10
      }
    },
    "UnknownV7": 0
  },
  "Date": { // 5
    "MonthAndDayAndYear": { // 5.1
      "Separate": { // 5.1.1
        "Month": { // 5.1.1.1
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
        "Day": { // 5.1.1.2
          "TopLeftX": 9,
          "TopLeftY": 128,
          "BottomRightX": 10,
          "BottomRightY": 129,
          "Alignment": "TopLeft",
          "SpacingX": -26,
          "SpacingY": 21,
          "ImageIndex": 55,
          "ImagesCount": 10
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
    "DayAmPm": {
      "X": 104,
      "Y": 288,
      "ImageIndexAMCN": 56,
      "ImageIndexPMCN": 57,
      "ImageIndexAMEN": 58,
      "ImageIndexPMEN": 59
    },
    "ENWeekDays": {
      "X": 14,
      "Y": 288,
      "ImageIndex": 35,
      "ImagesCount": 7
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
  "Status": {
    "DoNotDisturb": {
      "Coordinates": {
        "X": 49,
        "Y": 84
      },
      "ImageIndexOn": 71,
      "ImageIndexOff": 40
    },
    "Lock": {
      "Coordinates": {
        "X": 69,
        "Y": 84
      },
      "ImageIndexOff": 72
    },
    "Bluetooth": {
      "Coordinates": {
        "X": 89,
        "Y": 84
      },
      "ImageIndexOn": 43,
      "ImageIndexOff": 70
    }
  },
  "Battery": {
    "BatteryText": {
      "Coordinates": {
        "TopLeftX": 63,
        "TopLeftY": 55,
        "BottomRightX": 112,
        "BottomRightY": 77,
        "Alignment": "TopLeft",
        "SpacingX": -4,
        "SpacingY": 0,
        "ImageIndex": 73,
        "ImagesCount": 10
      }
    },
    "BatteryIcon": {
      "X": 11,
      "Y": 10,
      "ImageIndex": 83,
      "ImagesCount": 10
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
  }
}
```

```json
{
  "Background": {
    "BackgroundColor": "0x000000",
    "Preview1": {
      "X": 21,
      "Y": 30,
      "ImageIndex": 76
    },
    "Preview2": {
      "X": 21,
      "Y": 30,
      "ImageIndex": 76
    },
    "Preview3": {
      "X": 21,
      "Y": 30,
      "ImageIndex": 76
    }
  },
  "Time": {
    "Hours": {
      "Tens": {
        "X": 45,
        "Y": 8,
        "ImageIndex": 19,
        "ImagesCount": 3
      },
      "Ones": {
        "X": 45,
        "Y": 61,
        "ImageIndex": 19,
        "ImagesCount": 10
      }
    },
    "Minutes": {
      "Tens": {
        "X": 45,
        "Y": 117,
        "ImageIndex": 29,
        "ImagesCount": 6
      },
      "Ones": {
        "X": 45,
        "Y": 170,
        "ImageIndex": 29,
        "ImagesCount": 10
      }
    },
    "UnknownV11": 0
  },
  "Date": {
    "MonthAndDayAndYear": {
      "Separate": {
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
        "Day": {
          "TopLeftX": 9,
          "TopLeftY": 128,
          "BottomRightX": 10,
          "BottomRightY": 129,
          "Alignment": "TopLeft",
          "SpacingX": -26,
          "SpacingY": 21,
          "ImageIndex": 55,
          "ImagesCount": 10
        }
      },
      "TwoDigitsMonth": true,
      "TwoDigitsDay": true
    }
  },
  "Status": {
    "DoNotDisturb": {
      "Coordinates": {
        "X": 122,
        "Y": 72
      },
      "ImageIndexOn": 43,
      "ImageIndexOff": 40
    },
    "Bluetooth": {
      "Coordinates": {
        "X": 122,
        "Y": 45
      },
      "ImageIndexOn": 44,
      "ImageIndexOff": 41
    }
  },
  "Battery": {
    "BatteryIcon": {
      "X": 122,
      "Y": 127,
      "ImageIndex": 45,
      "ImagesCount": 10
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
  }
}

```