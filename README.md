# AppIconChangerUnity

<a href="https://www.buymeacoffee.com/kyubuns" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>

Change the app icon dynamically in Unity

<img src="https://user-images.githubusercontent.com/961165/80934851-02bad200-8e05-11ea-9f91-821b5a42def9.gif" width="320">

- iOS only, require iOS 10.3 or later

## Instructions

- Import by PackageManager `https://github.com/kyubuns/AppIconChangerUnity.git?path=Assets/AppIconChanger`
  - (Optional) You can import a demo scene on PackageManager.
<img width="813" alt="Screen Shot 2022-02-25 at 15 01 24" src="https://user-images.githubusercontent.com/961165/155662881-60ea3785-d3e7-4bda-9da8-3f8208d27390.png">

## Quickstart

- Create `AppIconChanger > AlternateIcon` from the context menu

- Set the name and icon

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

- Unity 2020.3 or higher.
- Xcode 13 or higher.

## License

MIT License (see [LICENSE](LICENSE))

