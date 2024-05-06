> [!WARNING]
> I don't know if the implementation of this branch is Apple-approved.  
> Use at your own risk.  
> https://stackoverflow.com/questions/43356570/alternate-icon-in-ios-10-3-avoid-notification-dialog-for-icon-change
>
> Usually use the main branch.  
> https://github.com/kyubuns/AppIconChangerUnity

# AppIconChangerUnity

Change the app icon dynamically in Unity  
Support for new icon formats in Xcode13  
-> This means that A/B Test on AppStore is also supported.

<img src="https://user-images.githubusercontent.com/961165/80934851-02bad200-8e05-11ea-9f91-821b5a42def9.gif" width="320">

- iOS only, require iOS 10.3 or later

## Instructions

- Import by PackageManager `https://github.com/kyubuns/AppIconChangerUnity.git#disable_popup?path=Assets/AppIconChanger`
  - (Optional) You can import a demo scene on PackageManager.
<img width="813" alt="Screen Shot 2022-02-25 at 15 01 24" src="https://user-images.githubusercontent.com/961165/155662881-60ea3785-d3e7-4bda-9da8-3f8208d27390.png">

## Quickstart

- Create `AppIconChanger > AlternateIcon` from the context menu

<img width="600" alt="Screen Shot 2022-02-26 at 13 15 02" src="https://user-images.githubusercontent.com/961165/155829253-d5da01b8-5491-444e-adea-385a4a3389c6.png">

- Set the name and icon

<img width="400" alt="Screen Shot 2022-02-26 at 13 15 47" src="https://user-images.githubusercontent.com/961165/155829249-b36feac2-17ee-4f4b-bdc2-ab00b50450c4.png">

- The following methods are available
    - AppIconChanger.iOS.SupportsAlternateIcons
        - Check to see if the icon can be changed
        - https://developer.apple.com/documentation/uikit/uiapplication/2806815-supportsalternateicons
    - AppIconChanger.iOS.AlternateIconName
        - Check the current icon name (null is the default)
        - https://developer.apple.com/documentation/uikit/uiapplication/2806808-alternateiconname
    - AppIconChanger.iOS.SetAlternateIconName(iconName)
        - Set the icon (null to restore the default)
        - https://developer.apple.com/documentation/uikit/uiapplication/2806818-setalternateiconname

## Tips

### What is the best size for the app icon?

When the Type of `AlternateIcon` is set to Auto Generate, the icon will be automatically resized at build time, so there is nothing to worry about. （The maximum size is 1024px.)  
If you want to control it in detail, you can change the Type to Manual.  
<img width="250" alt="Screen Shot 2022-02-26 at 13 16 15" src="https://user-images.githubusercontent.com/961165/155829238-db5b160f-ed8a-4b60-a0e3-58df7921b42e.png">

## Requirements

- Unity 2020.3 or higher.
- Xcode 13 or higher.

## License

MIT License (see [LICENSE](LICENSE))

