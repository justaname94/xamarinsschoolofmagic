using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Paint.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaintPage : ContentPage
    {
        public PaintPage()
        {
            InitializeComponent();
        }

        private List<SKPath> paths = new List<SKPath>();
        private List<SKPath> changesPaths = new List<SKPath>();


        private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
        Dictionary<string, SKColor> colors = new Dictionary<string, SKColor>()
        {
            {"Red", SKColors.Red },
            {"Blue", SKColors.Blue},
            {"Green", SKColors.Green },
            {"Yellow",  SKColors.Yellow},
            {"Gray", SKColors.Gray },
            {"LightBlue", SKColors.LightBlue }

        };
        private List<SKColor> colorsList = new List<SKColor>();
        private SKColor currentColor = SKColors.Red;
        private SKImage canvasImg = null;

            private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            for (int i = 0; i < paths.Count; i++)
            {
                var touchPath = paths[i];
                var stroke = new SKPaint
                {
                    Color = colorsList[i],
                    StrokeWidth = 5,
                    Style = SKPaintStyle.Stroke
                };
                canvas.DrawPath(touchPath, stroke);
            }
            canvasImg = surface.Snapshot();
        }

        private void OnTouch(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    colorsList.Add(currentColor);
                    var p = new SKPath();
                    p.MoveTo(e.Location);
                    temporaryPaths[e.Id] = p;
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    paths.Add(temporaryPaths[e.Id]);
                    temporaryPaths.Remove(e.Id);
                    break;
            }

            e.Handled = true;

            // update the UI on the screen
            ((SKCanvasView)sender).InvalidateSurface();
        }

        private void ChangeColor(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string color = button.Text;
            currentColor = colors[color];
        }

        private void Clear(object sender, EventArgs e)
        {
            paths.Clear();
            colorsList.Clear();
            PaintCanvas.InvalidateSurface();
        }


    }
}