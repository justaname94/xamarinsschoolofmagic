using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Paint.iOS.Services;
using Paint.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoLibraryService))]
namespace Paint.iOS.Services
{
    public class PhotoLibraryService : IPhotoLibrary
    {
        public Task<bool> SavePhotoAsync(byte[] data, string folder, string filename)
        {
            NSData nsData = NSData.FromArray(data);
            UIImage image = new UIImage(nsData);
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();

            image.SaveToPhotosAlbum((UIImage img, NSError error) =>
            {
                taskCompletionSource.SetResult(error == null);
            });

            return taskCompletionSource.Task;
        }
    }
}