using IntecWeek7.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DependencyServices.ViewModels
{
    class DeviceOrientationViewModel
    {
        public string CurrentOrientation { get; set; }

        DeviceOrientation Orientation { get; set; }
        public DeviceOrientationViewModel()
        {
            IDeviceOrientation service = DependencyService.Get<IDeviceOrientation>();
            DeviceOrientation orientation = service.GetOrientation();
            CurrentOrientation = orientation.ToString();
        }
    }
}
