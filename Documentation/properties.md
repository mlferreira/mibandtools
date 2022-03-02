# JSON FORMAT

## First Level
| Name             | Type                                     | Index | Description                                       |
|------------------|------------------------------------------|-------|---------------------------------------------------|
| Background       | [background](#background-object)         | 2     | background image or color, and watchface previews |
| Time             | [time](#time-object)                     | 3     | digital clock formatting                          |
| Activity         | [activity](#activity-object)             | 4     |                                                   |
| Date             | [date](#date-object)                     | 5     | date formatting                                   |
| Weather          | [weather](#weather-object)               | 6     |                                                   |
| StepsProgress    | [progress](#progress-object)             | 7     | progress towards your steps goal                  |
| Status           | [status](#status-object)                 | 8     |                                                   |
| Battery          | [battery](#battery-object)               | 9     | battery level display                             |
| ?                | ?                                        | 10    |                                                   |
| Other            | [other](#other-object)                   | 11    | animation settings                                |
| HeartProgress    | [progress](#progress-object)             | 12    |                                                   |
| ?                | ?                                        | 13    |                                                   |
| ?                | ?                                        | 14    |                                                   |
| CaloriesProgress | [progress](#progress-object)             | 15    |                                                   |
| ?                | ?                                        | 16    |                                                   |
| ?                | ?                                        | 17    |                                                   |
| Alarm            | [alarm](#alarm-object)                   | 18    |                                                   |
| ?                | ?                                        | 19    |                                                   |
| ?                | ?                                        | 20    |                                                   |
| LunarDateCN1     | [lunar calendar](#lunar-calendar-object) | 21    |                                                   |

## Background Object
| Name            | Type                   | Index | Description                                                                                                                       |
|-----------------|------------------------|-------|-----------------------------------------------------------------------------------------------------------------------------------|
| Image           | [image](#image-object) | 1     | index of the background image                                                                                                     |
| BackgroundColor | hexadecimal            | 2     | [hex color code](https://htmlcolorcodes.com/)                                                                                     |
| Preview1        | [image](#image-object) | 3     | image to be displayed on the "band display" setting. recommended to use a 110x352 image, and set the X property to 21 and Y to 30 |
| Preview2        | [image](#image-object) | 4     |                                                                                                                                   |
| Preview3        | [image](#image-object) | 5     |                                                                                                                                   |
Obs: `Image` and `BackgroundColor` should not be used at the same time

<!---
<table>
    <thead>
        <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Index</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Image</td>
            <td>[image](#image-object)</td>
            <td>1</td>
            <td>index of the background image</td>
        </tr>
        <tr>
            <td>BackgroundColor</td>
            <td>string</td>
            <td>2</td>
            <td>[hex color code](https://htmlcolorcodes.com/)    </td>
        </tr>
        <tr>
            <td>Preview1</td>
            <td>[image](#image-object)</td>
            <td>3</td>
            <td rowspan=3>image to be displayed on the "band display" setting. recommended to use a 110x352 image, and set the X property to 21 and Y to 30</td>
        </tr>
        <tr>
            <td>Preview2</td>
            <td>[image](#image-object)</td>
            <td>4</td>
        </tr>
        <tr>
            <td>Preview3</td>
            <td>[image](#image-object)</td>
            <td>5</td>
        </tr>
    </tbody>
</table>
---->

## Time Object
| Name                    | Type                                 | Index | Description                                           |
|-------------------------|--------------------------------------|-------|-------------------------------------------------------|
| Hours                   | [double digit](#double-digit-object) | 1     |                                                       |
| Minutes                 | [double digit](#double-digit-object) | 2     |                                                       |
| ?                       | [???](#???-object)                   | 3     |                                                       |
| ?                       | [???](#???-object)                   | 4     |                                                       |
| ?                       | [???](#???-object)                   | 5     |                                                       |
| TimeDelimiterImage      | [image](#image-object)               | 6     | image to display between hours and minutes (e.g. `:`) |
| TimeZone1               | [image box](#image-box-object)       | 7     |                                                       |
| TimeZone1DelimiterImage | number                               | 8     |                                                       |
| TimeZone2               | [image box](#image-box-object)       | 9     |                                                       |
| TimeZone2DelimiterImage | number                               | 10    |                                                       |
| _**Unknown11**_         | number                               | 11    |                                                       |
| TimeZone1NoTime         | [image](#image-object)               | 12    |                                                       |
| TimeZone2NoTime         | [image](#image-object)               | 13    |                                                       |

## Activity Object
| Name      | Type               | Index | Description |
|-----------|--------------------|-------|-------------|
| Steps     | [???](#???-object) | 1     |             |
| ???       | [???](#???-object) | 2     |             |
| Calories  | [???](#???-object) | 3     |             |
| Pulse     | [???](#???-object) | 4     |             |
| Distance  | [???](#???-object) | 5     |             |
| PAI       | [???](#???-object) | 6     |             |
| UnknownV7 | number             | 7     |             |

## Date Object
| Name               | Type                               | Index | Description |
|--------------------|------------------------------------|-------|-------------|
| MonthAndDayAndYear | [???](#???-object)                 | 1     |             |
| DayAmPm            | [???](#???-object)                 | 2     |             |
| ???                | [???](#???-object)                 | 3     |             |
| ENWeekDays         | [image set](#image-set-object)     | 4     |             |
| CNWeekDays         | [image set](#image-set-object)     | 5     |             |
| CN2WeekDays        | [image set](#image-set-object)     | 6     |             |
| Unknown7           | [coordinates](#coordinates-object) | 7     |             |

## Weather Object
| Name         | Type               | Index | Description |
|--------------|--------------------|-------|-------------|
| Icon         | [???](#???-object) | 1     |             |
| Temperature  | [???](#???-object) | 2     |             |
| AirPollution | [???](#???-object) | 3     |             |
| Humidity     | [???](#???-object) | 4     |             |
| Wind         | [???](#???-object) | 5     |             |
| UVIndex      | [???](#???-object) | 6     |             |

## Status Object
| Name         | Type                                 | Index | Description |
|--------------|--------------------------------------|-------|-------------|
| DoNotDisturb | [status image](#status-image-object) | 1     |             |
| Lock         | [status image](#status-image-object) | 2     |             |
| Bluetooth    | [status image](#status-image-object) | 3     |             |

## Battery Object
| Name          | Type                                 | Index | Description             |
|---------------|--------------------------------------|-------|-------------------------|
| BatteryText   | [???](#???-object)                   | 1     | battery percentage text |
| BatteryIcon   | [image set](#image-set-object)       | 2     |                         |
| LinearScale   | [linear scale](#linear-scale-object) | 3     |                         |

## Other Object
| Name      | Type                                               | Index | Description |
|-----------|----------------------------------------------------|-------|-------------|
| Animation | list of [animation image](#animation-image-object) | 1     |             |


## Progress Object
| Name          | Type                                 | Index | Description |
|---------------|--------------------------------------|-------|-------------|
| ?             | [???](#???-object)                   | 1     |             |
| LineScale     | [image set](#image-set-object)       | 2     |             |
| LinearScale   | [linear scale](#linear-scale-object) | 3     |             |
| CircleScale   | [circle scale](#circle-scale-object) | 4     |             |

## Alarm Object
| Name                | Type                           | Index | Description |
|---------------------|--------------------------------|-------|-------------|
| Text                | [image box](#image-box-object) | 1     |             |
| DelimiterImageIndex | number                         | 2     |             |
| ImageOn             | [image](#image-object)         | 3     |             |
| ImageOff            | [image](#image-object)         | 4     |             |
| ImageNoAlarm        | [image](#image-object)         | 5     |             |
| UnknownTF6          | number                         | 6     |             |
| UnknownTF7          | number                         | 7     |             |

## Lunar Calendar Object
| Name          | Type                           | Index | Description |
|---------------|--------------------------------|-------|-------------|
| LunarMonth    | [image set](#image-set-object) | 1     |             |
| LunarDay1     | [image box](#image-box-object) | 2     |             |
| LunarDayOf0X  | number                         | 3     |             |
| LunarDayOf2X  | number                         | 4     |             |
| LunarDayOf10X | number                         | 5     |             |
| LunarDayOf20X | number                         | 6     |             |
| LunarDayOf30X | number                         | 7     |             |

--------------------
--------------------

## Double Digit Object
| Name  | Type                           | Index | Description |
|-------|--------------------------------|-------|-------------|
| Tens  | [image set](#image-set-object) | 1     |             |
| Ones  | [image set](#image-set-object) | 2     |             |
Obs: both `ImagesCount` should be **10**, and the images should be ordered from _0_ to _9_


## Status Image Object
| Name          | Type                               | Index | Description                                          |
|---------------|------------------------------------|-------|------------------------------------------------------|
| Coordinates   | [coordinates](#coordinates-object) | 1     | coordinates for where the icon should be displayed   |
| ImageIndexOn  | number                             | 2     | index of the image to display if setting is active   |
| ImageIndexOff | number                             | 3     | index of the image to display if setting is inactive |


## Battery Text Object
| Name             | Type                           | Index | Description                                                                                          |
|------------------|--------------------------------|-------|------------------------------------------------------------------------------------------------------|
| Coordinates      | [image box](#image-box-object) | 1     | coordinates for the text box for the digits. `ImagesCount` should be **10**, and ordered from 0 to 9 |
| ?                | ?                              | 2     | ?                                                                                                    |
| PrefixImageIndex | number                         | 3     | index of the icon to display before the text                                                         |
| SuffixImageIndex | number                         | 4     | index of the icon to display after the text                                                          |

## Animation Image Object
| Name            | Type                           | Index | Description |
|-----------------|--------------------------------|-------|-------------|
| AnimationImages | [image set](#image-set-object) | 1     |             |
| Speed           | number                         | 2     |             |
| RepeatCount     | number                         | 3     |             |
| UnknownTF4      | number                         | 4     |             |


-----

## Generic Objects

### Coordinates Object
```json
{ 
  "X": <number 0~152>,  // 1
  "Y": <number 0~486>   // 2
}
```

### Image Object
```json
{
  "X": <number 0~152>,    // 1
  "Y": <number 0~486>,    // 2
  "ImageIndex": <number>  // 3
}
```

### Image Set Object
```json
{
  "X": <number 0~152>,     // 1
  "Y": <number 0~486>,     // 2
  "ImageIndex": <number>,  // 3
  "ImagesCount": <number>  // 4
}
```

### Image Box Object
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

### Linear Scale Object
| Name            | Type                                       | Index | Description                                                                      |
|-----------------|--------------------------------------------|-------|----------------------------------------------------------------------------------|
| StartImageIndex | number                                     | 1     | number of start image                                                            |
| Segments        | list of [coordinates](#coordinates-object) | 2     | each segment needs its own image, starting with the image from _StartImageIndex_ |


### Circle Scale Object
```json
{ 
    "CenterX": <number 0~152>,     // 1
    "CenterY": <number 0~486>,     // 2
    "RadiusX": <number>,           // 3
    "BottomRightY": <number>,      // 4
    "RadiusY": <Alignment>,        // 5
    "StartAngle": <number 0~360>,  // 6
    "EndAngle": <number 0~360>,    // 7
    "Width": <number>,             // 8
    "Color": <hex color>           // 9
}
```