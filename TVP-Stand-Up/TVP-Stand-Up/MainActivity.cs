using Android.App;
using Android.Widget;
using Android.OS;

namespace TVP_Stand_Up
{
    [Activity(Label = "TVP_Stand_Up", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            // This is a test to see if I can commit from BYOD
            SetContentView(Resource.Layout.Main);
        }
    }
}

