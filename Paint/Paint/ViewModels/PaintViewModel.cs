using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paint.ViewModels
{
    class PaintViewModel
    {
        public List<SKPath> paths = new List<SKPath>();
        public Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();

        public void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {

            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            var stroke = new SKPaint
            {
                Color = SKColors.DarkOrange,
                StrokeWidth = 5,
                Style = SKPaintStyle.Stroke
            };

            foreach (var touchPath in paths)
            {
                canvas.DrawPath(touchPath, stroke);
            }
        }

        public void OnTouch(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
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
    }
}
