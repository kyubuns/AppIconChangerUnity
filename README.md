# AppIconChangerUnity
Change the app icon dynamically in Unity

![output](https://user-images.githubusercontent.com/961165/80934851-02bad200-8e05-11ea-9f91-821b5a42def9.gif)

- iOS only
- Target minimum iOS Version >= 10.3

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

## License

MIT License (see [LICENSE](LICENSE))

