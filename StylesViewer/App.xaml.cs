using System;
using System.Linq;
using System.Windows;
using static DefaultStyles.StyleManager;

namespace StylesViewer
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets a value indicating whether the current theme is dark.
        /// </summary>
        public static bool IsDarkTheme { get; set; }

        /// <summary>
        /// Switches the theme of the application to the specified theme.
        /// </summary>
        /// <param name="theme">The theme to switch to.</param>
        public static void SwitchTheme(Themes theme)
        {
            // Get the updated resource dictionary for the specified theme
            ResourceDictionary valueNewDict = GetUpdatedResource(theme);

            // Clear the merged dictionaries and add the new resource dictionary
            Current.Resources.MergedDictionaries.Clear();
            Current.Resources.MergedDictionaries.Add(valueNewDict);

            // Set the IsDarkTheme property based on the specified theme
            IsDarkTheme = theme == Themes.Dark;
        }
    }
}
