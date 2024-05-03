# DarkLightThemeWPF
This project focuses on presenting a theme switching concept in an application that uses WPF.

## Description
This project uses the C#/WPF language and the .NET Framework 4.8 and is designed to remove a theme switching concept that uses MergedDictionaries to change the colors of a defined style of the controls to suit the desired theme.

The base of all predefined styles is present in the DefaultStyles DLL. Within each Style file, there is a MergedDictionaries with the ControlsSourceLight.xaml file as standard, which can be changed to ControlsSourceDark.xaml, thus changing the value of the colors used in the style, reflecting the Dark or Light themes.

As the styles are used in another project (StylesViewer) and DefaultStyles behaves like a DLL, simply calling the StyleManager Manager from DefaultStyles would not be enough to reload the styles. You need to retrieve the ResourceDictionary already with the changed colors that is delivered by the Manager and add it again to the MergedDictionaries of your application. Then, you can request that the controls be reloaded with InvalidateVisual().


## Installation
To test and analyze this project, simply clone it to your machine:

```
git clone https://github.com/ErikFernandes/DarkLightThemeWPF.git
```


## License
This project is licensed under the [MIT License](https://spdx.org/licenses/MIT.html).
