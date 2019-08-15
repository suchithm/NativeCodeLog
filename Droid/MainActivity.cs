using Android.App;
using Android.Widget;
using Android.OS;

namespace NativeCodeLog.Droid
{
    [Activity(Label = "NativeCodeLog", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    { 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             
            SetContentView(Resource.Layout.Main);
             
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Text = "ReOrder Widget";
            button.Click += delegate { StartActivity(typeof(ReOrderActivity)); };
        }
    }
}

