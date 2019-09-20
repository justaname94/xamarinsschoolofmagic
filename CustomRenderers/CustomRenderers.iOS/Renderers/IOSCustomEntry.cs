using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomRenderer.iOS;
using CustomRenderers.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(IOSCustomEntry))]
namespace CustomRenderer.iOS
{
    public class IOSCustomEntry : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the UITextField here!
                Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}