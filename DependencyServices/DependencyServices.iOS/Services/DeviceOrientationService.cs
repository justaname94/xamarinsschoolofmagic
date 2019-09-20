using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DependencyServices.iOS.Services;
using Foundation;
using IntecWeek7.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Dependency(typeof(DeviceOrientationService))]
namespace DependencyServices.iOS.Services
{
    public class DeviceOrientationService : IDeviceOrientation
    {
        public DeviceOrientation GetOrientation()
        {
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            bool isPortrait = orientation == UIInterfaceOrientation.Portrait ||
                orientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
        }
    }
}