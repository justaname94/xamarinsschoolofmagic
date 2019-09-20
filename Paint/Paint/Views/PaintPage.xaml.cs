using Paint.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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

        private LinkedList<SKPath> changesLL= new LinkedList<SKPath>();
        private LinkedList<SKPath> pathsLL= new LinkedList<SKPath>();
        private LinkedList<SKColor> colorsLL = new LinkedList<SKColor>();

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
        private SKColor currentColor = SKColors.Red;
        private SKImage canvasImg = null;
        SKBitmap libraryBitmap;

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;  
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            if (libraryBitmap != null)
            {
                float scale = Math.Min((float)info.Width / libraryBitmap.Width,
                               info.Height / 3f / libraryBitmap.Height);

                float left = (info.Width - scale * libraryBitmap.Width) / 2;
                float top = (info.Height / 3 - scale * libraryBitmap.Height) / 2;
                float right = left + scale * libraryBitmap.Width;
                float bottom = top + scale * libraryBitmap.Height;
                SKRect rect = new SKRect(left, top, right, bottom);
                // rect.Offset(0, 2 * info.Height / 3);

                canvas.DrawBitmap(libraryBitmap,
                  new SKRect(0, 0, info.Width, info.Height));

            }
            int i = 0;
            var curr = colorsLL.First;
            foreach (var touchPath in pathsLL)
            {
                var stroke = new SKPaint
                {
                    Color = curr.Value,
                    StrokeWidth = 5,
                    Style = SKPaintStyle.Stroke
                };
                canvas.DrawPath(touchPath, stroke);
                i++;
                curr = curr.Next;
            }
            canvasImg = surface.Snapshot();
        }

        private void OnTouch(object sender, SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Pressed:
                    colorsLL.AddLast(currentColor);
                    var p = new SKPath();
                    p.MoveTo(e.Location);
                    temporaryPaths[e.Id] = p;
                    break;
                case SKTouchAction.Moved:
                    if (e.InContact)
                        temporaryPaths[e.Id].LineTo(e.Location);
                    break;
                case SKTouchAction.Released:
                    pathsLL.AddLast(temporaryPaths[e.Id]);
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
            pathsLL.Clear();
            colorsLL.Clear();
            changesLL.Clear();
            libraryBitmap = null;
            PaintCanvas.InvalidateSurface();
        }

        private async void SaveAsImage(object sender, EventArgs e)
        {
            // First check for permissions (thanks Montemagno ;) )
            PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync<StoragePermission>();

            if (status != PermissionStatus.Granted) {
                
                status = await CrossPermissions.Current.RequestPermissionAsync<StoragePermission>();
            }

            if (status == PermissionStatus.Granted)
            {
                SKData data = canvasImg.Encode();
                DateTime dt = DateTime.Now;
                string filename = String.Format("FingerPaint-{0:D4}{1:D2}{2:D2}-{3:D2}{4:D2}{5:D2}{6:D3}.png",
                                                dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

                IPhotoLibrary photoLibrary = DependencyService.Get<IPhotoLibrary>();
                bool result = await photoLibrary.SavePhotoAsync(data.ToArray(), "FingerPaint", filename);

                if (!result)
                {
                    await DisplayAlert("FingerPaint", "Artwork could not be saved. Sorry!", "OK");
                }
            } else
            {
                await DisplayAlert("Cannot save drawing", "Storage permission needed", "ok");
            }
                    
        }

        private void Undo(object sender, EventArgs e)
        {
            try {
                var node = pathsLL.Last;
                pathsLL.Remove(pathsLL.Last);
                changesLL.AddLast(node);
                PaintCanvas.InvalidateSurface();
            } catch (System.ArgumentException ex)
            {
                // The user expects anything to happens as they have nothing to undo
            }
        }

        private void Redo(object sender, EventArgs e)
        {
            try
            {
                var node = changesLL.Last;
                changesLL.Remove(changesLL.Last);
                pathsLL.AddLast(node);
                PaintCanvas.InvalidateSurface();
            }
            catch (System.ArgumentNullException ex)
            {
                // The user expects anything to happens as they have nothing to redo
            }
        }

        private async void LoadImage(object sender, EventArgs e)
        {
            IPhotoLibrary photoLibrary = DependencyService.Get<IPhotoLibrary>();

            using (Stream stream = await photoLibrary.PickPhotoAsync())
            {
                if (stream != null)
                {
                    libraryBitmap = SKBitmap.Decode(stream);
                    PaintCanvas.InvalidateSurface();
                }
            }
        }
    }
}