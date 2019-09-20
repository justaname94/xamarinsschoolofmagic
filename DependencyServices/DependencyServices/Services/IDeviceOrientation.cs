using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace IntecWeek7.Services
{
    public interface IDeviceOrientation
    {
        DeviceOrientation GetOrientation();
    }
}