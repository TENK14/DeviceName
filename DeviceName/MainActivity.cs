using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace DeviceName
{
    [Activity(Label = "DeviceName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var deviceName = FindViewById<TextView>(Resource.Id.deviceNameTextView);

            try
            {
                //deviceName.Text = DeviceName;
                //deviceName.Text = Hostname;
                deviceName.Text = DeviceInfo.GetProperty(DeviceInfoPropertyEnums.net_hostname);
            }
            catch (Exception ex)
            {
                deviceName.Text = "Neznámé zařízení";// Resources.GetString(Resource.String.Unknown);
            }

        }

        [get: Android.Runtime.Register("getDeviceName", "()Ljava/lang/String;", "GetGetDeviceNameHandler")]
        public string DeviceName { get; }

        public string Hostname {
            get
            {
                string hostname = "...";

                try
                {
                    Java.Lang.Class buildClass = Java.Lang.Class.ForName("android.os.Build");
                    Java.Lang.Reflect.Method getString = buildClass.GetDeclaredMethod("getString", Java.Lang.Class.FromType(typeof(Java.Lang.String)));
                    getString.Accessible = true;
                    hostname = getString.Invoke(null, "net.hostname").ToString();
                }
                catch (Exception ex)
                {
                    hostname = "neznámé zařízení";
                }
                return hostname;
            }

        }
    }
}

