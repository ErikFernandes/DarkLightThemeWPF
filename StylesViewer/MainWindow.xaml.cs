using DefaultStyles;
using System;
using System.Linq;
using System.Windows;

namespace StylesViewer
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (App.IsDarkTheme) { App.SwitchTheme(StyleManager.Themes.Light); }
            else { App.SwitchTheme(StyleManager.Themes.Dark); }

            InvalidateVisual();

        }
    }
}
