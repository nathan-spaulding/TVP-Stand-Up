using Android.App;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Content.Res;
using Android.Support.Design.Widget;

namespace StandUpMeeting
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private DrawerLayout mDrawerLayout;
        private NavigationView mNavigationView;

        //private ListView mDrawerList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            SetSupportActionBar(mToolbar);

            //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_ic_menu_selectall_mtrl_alpha);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            mNavigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                // react to click here and swap fragments / navigate
                mToolbar.Title = e.MenuItem.TitleFormatted.ToString();
                mDrawerLayout.CloseDrawers();
            };

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    if (mDrawerLayout.IsDrawerOpen(Android.Support.V4.View.GravityCompat.Start))
                        mDrawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
                    else
                        mDrawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    mDrawerToggle.OnOptionsItemSelected(item);
        //    return base.OnOptionsItemSelected(item);
        //}

        //protected override void OnPostCreate(Bundle savedInstanceState)
        //{
        //    base.OnPostCreate(savedInstanceState);
        //    mDrawerToggle.SyncState();
        //}

        //protected override void OnSaveInstanceState(Bundle outState)
        //{
        //    if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
        //        outState.PutString("DrawerState", "Opened");
        //    else
        //        outState.PutString("DrawerState", "Closed");

        //    base.OnSaveInstanceState(outState);
        //}
    }
}

