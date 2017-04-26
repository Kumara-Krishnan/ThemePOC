using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ThemePOC.Utils
{
    public class ThemeManager
    {
        ThemeManager() { }

        #region Singleton

        public static ThemeManager _Instance = null;
        public static object padlock = new object();
        public static ThemeManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_Instance == null)
                        _Instance = new ThemeManager();
                }
                return _Instance;
            }
        }

        #endregion

        public Color HighAccentColorBrush { get; set; }

        public void NotifyThemeChanged()
        {
            ThemeChanged?.Invoke(this);
        }

        public static event Action<ThemeManager> ThemeChanged;
    }
}
