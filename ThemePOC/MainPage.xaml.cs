using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using ThemePOC.Utils;
using ThemePOC.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThemePOC
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Random random;
        public MainPage()
        {
            this.InitializeComponent();
            random = new Random();
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void ThemeManager_ThemeChanged(ThemeManager theme)
        {
            this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ((SolidColorBrush)Application.Current.Resources["BackgroundBrush"]).Color = theme.HighAccentColorBrush;
            });
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void ThemeChanger_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.ContainsKey("BackgroundBrush"))
            {
                ThemeManager.Instance.HighAccentColorBrush = Windows.UI.Color.FromArgb(Convert.ToByte(random.Next(255)), Convert.ToByte(random.Next(255)), Convert.ToByte(random.Next(255)), Convert.ToByte(random.Next(255)));
            }
            ThemeManager.Instance.NotifyThemeChanged();
        }

        private async Task CreateNewViewAsync()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(SecondaryPage), null);
                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private void Sample_Click(object sender, RoutedEventArgs e)
        {
            CreateNewViewAsync();
        }
    }
}
