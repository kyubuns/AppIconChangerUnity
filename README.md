# AppIconChangerUnity

<a href="https://www.buymeacoffee.com/kyubuns" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>

Change the app icon dynamically in Unity

<img src="https://user-images.githubusercontent.com/961165/80934851-02bad200-8e05-11ea-9f91-821b5a42def9.gif" width="320">

- iOS only, require iOS 10.3 or later

## Instructions

- Import [UnityPackage](https://github.com/kyubuns/AppIconChangerUnity/releases)

## Quickstart

Please check Demo directory for more information.

- Create an `Alternate Icons` from the context menu.
- Set the icon. It can be set by resolution. Different sizes are automatically resized.
- The following methods are available
    - AppIconChanger.iOS.SupportsAlternateIcons
        - Check to see if the icon can be changed
        - https://developer.apple.com/documentation/uikit/uiapplication/2806815-supportsalternateicons
    - AppIconChanger.iOS.AlternateIconName
        - Check the current icon name (null is the default)
        - https://developer.apple.com/documentation/uikit/uiapplication/2806808-alternateiconname.
    - AppIconChanger.iOS.SetAlternateIconName(iconName)
        - Set the icon (null to restore the default)
        - https://developer.apple.com/documentation/uikit/uiapplication/2806818-setalternateiconname

## Requirements

- Unity 2018.4 or higher.
- Xcode 13 or higher.

## License

MIT License (see [LICENSE](LICENSE))

