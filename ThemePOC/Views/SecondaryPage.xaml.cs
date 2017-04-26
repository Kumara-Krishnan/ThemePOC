using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThemePOC.Utils;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ThemePOC.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SecondaryPage : Page
    {
        Random random;
        public SecondaryPage()
        {
            this.InitializeComponent();
            random = new Random();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
            ThemeManager_ThemeChanged(ThemeManager.Instance);
        }

        private void ThemeManager_ThemeChanged(Utils.ThemeManager theme)
        {
            this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ((SolidColorBrush)Application.Current.Resources["BackgroundBrush"]).Color = theme.HighAccentColorBrush;
            });
        }
    }
}
