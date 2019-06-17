using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntryC = ButceApp.Controls.EntryC;
using Xamarin.Forms.Platform.UWP;
using ButceApp.UWP.Utils;
using Xamarin.Forms;
[assembly: ExportRenderer(typeof(EntryC), typeof(ButceApp.UWP.CustomRenderers.EntryCR))]

namespace ButceApp.UWP.CustomRenderers
{
    public class EntryCR : Xamarin.Forms.Platform.UWP.EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            Control.IsTextPredictionEnabled = true;
            Control.BorderBrush = CustomUwpBrush.Brush(Color.Red);
            Control.Background.Opacity = 100;
            Control.Background= CustomUwpBrush.Brush(Color.Red);
          
            Control.FontSize = 15;
        }
    }
}
