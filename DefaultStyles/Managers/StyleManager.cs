using System;
using System.Linq;
using System.Windows;

namespace DefaultStyles
{
    /// <summary>
    /// This class manages the styles of the application.
    /// </summary>
    public static class StyleManager
    {
        /// <summary>
        /// Enum representing the available themes for the application.
        /// </summary>
        public enum Themes
        {
            Dark,
            Light
        }

        /// <summary>
        /// Returns a ResourceDictionary based on the specified theme.
        /// </summary>
        /// <param name="th">The theme to get the ResourceDictionary for.</param>
        /// <returns>The ResourceDictionary for the specified theme.</returns>
        public static ResourceDictionary GetUpdatedResource(Themes th)
        {
            // Determine the name of the file to load based on the theme.
            string fileName = th == Themes.Dark ? "ControlsSourceDark.xaml" : "ControlsSourceLight.xaml";

            // Create a new ResourceDictionary for the colors based on the file name.
            ResourceDictionary newColors = new ResourceDictionary
            {
                Source = new Uri($"/DefaultStyles;component/Styles/ControlsColor/{fileName}", UriKind.RelativeOrAbsolute)
            };

            // Create a new ResourceDictionary for dynamic colors.
            ResourceDictionary dynamicColors = new ResourceDictionary
            {
                Source = new Uri("/DefaultStyles;component/Styles/DynamicColors.xaml", UriKind.RelativeOrAbsolute)
            };

            // Clear the MergedDictionaries of the dynamicColors ResourceDictionary and add the newColors ResourceDictionary.
            dynamicColors.MergedDictionaries.Clear();
            dynamicColors.MergedDictionaries.Add(newColors);

            // Create a new ResourceDictionary for the styles repository.
            ResourceDictionary stylesRepository = new ResourceDictionary
            {
                Source = new Uri("/DefaultStyles;component/Styles/StylesRepository.xaml", UriKind.RelativeOrAbsolute)
            };

            // Get an array of the sources of the MergedDictionaries of the stylesRepository ResourceDictionary.
            string[] paths = stylesRepository.MergedDictionaries.Select(x => x.Source.ToString()).ToArray();

            // Clear the MergedDictionaries of the stylesRepository ResourceDictionary and add the dynamicColors ResourceDictionary.
            stylesRepository.Clear();
            stylesRepository.MergedDictionaries.Add(dynamicColors);

            // For each source in the paths array, create a new ResourceDictionary and add it to the stylesRepository ResourceDictionary.
            foreach (string item in paths)
            {
                if (item == dynamicColors.Source.ToString()) continue;

                ResourceDictionary current = new ResourceDictionary
                {
                    Source = new Uri(item, UriKind.RelativeOrAbsolute)
                };
                current.MergedDictionaries.Clear();
                current.MergedDictionaries.Add(newColors);

                stylesRepository.MergedDictionaries.Add(current);
            }

            // Return the stylesRepository ResourceDictionary.
            return stylesRepository;
        }
    }
}
