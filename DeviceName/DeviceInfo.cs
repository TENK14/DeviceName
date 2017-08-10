using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeviceName
{
    public static class DeviceInfo
    {

        public static string GetProperty(string propertyName)
        {
            string result = string.Empty;

            try
            {
                Java.Lang.Class buildClass = Java.Lang.Class.ForName("android.os.Build");
                Java.Lang.Reflect.Method getString = buildClass.GetDeclaredMethod("getString", Java.Lang.Class.FromType(typeof(Java.Lang.String)));
                getString.Accessible = true;
                //result = getString.Invoke(null, "net.hostname").ToString();
                result = getString.Invoke(null, propertyName).ToString();
            }
            catch (Exception ex)
            {
                throw ex;

                //result = string.Empty;
            }

            return result;
        }
    }

    
}