using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace ButceApp.UWP.Utils
{
    public class CustomUwpBrush
    {
        public static void Init()
        {
           
        }
        public static SolidColorBrush Brush(Xamarin.Forms.Color color)
        {
            if (color.A < 0)
                return new SolidColorBrush(Windows.UI.Colors.Transparent);
            var winColor = Windows.UI.Color.FromArgb(
                (byte)(color.A*255),
                (byte)(color.R*255),
                (byte)(color.G*255),
                (byte)(color.B*255));
            return new SolidColorBrush(winColor);
        }
    }
}
