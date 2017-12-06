using Android.App;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace StandUpMeeting
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private SupportToolbar mToolbar;
        private DrawerLayout mDrawerLayout;
        private NavigationView mNavigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.app_bar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mNavigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //Init Toolbar
            SetSupportActionBar(mToolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            //Attach Item slected handler to nav view
            mNavigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            //Create ActionBarDrawerToggle Button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, mDrawerLayout, mToolbar, Resource.String.openDrawer, Resource.String.closeDrawer);
            mDrawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            //This is where a default home screen would be loaded / check authentication ; whatever is decided
            //var ft = FragmentManager.BeginTransaction();
            //ft.Add(Resource.Id.HomeFrameLayout, new HomeFragment());
            //ft.Commit();

        }

        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.app_name);
            base.OnResume();
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    Toast.MakeText(this, "Home Selected", ToastLength.Short).Show();
                    SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();
                    break;
                case(Resource.Id.nav_calendar):
                    Toast.MakeText(this, "Calendar Selected", ToastLength.Short).Show();
                    SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();
                    break;
                case (Resource.Id.nav_chat):
                    Toast.MakeText(this, "Chat Selected", ToastLength.Short).Show();
                    SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();
                    break;
                case (Resource.Id.nav_schedule):
                    Toast.MakeText(this, "Schedule Selected", ToastLength.Short).Show();
                    SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();
                    break;

                case (Resource.Id.nav_settings):
                    Toast.MakeText(this, "Settings Selected", ToastLength.Short).Show();
                    SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();
                    break;
                case (Resource.Id.nav_login):
                    Toast.MakeText(this, "Logon Selected", ToastLength.Short).Show();
                    SupportActionBar.Title = e.MenuItem.TitleFormatted.ToString();
                    break;
            }
            mDrawerLayout.CloseDrawers();
        }
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    //Put the action_menu.axml in the Menu folder if you do this
        //    //MenuInflater.Inflate(Resource.Menu.nav_menu, menu);
        //    if(menu != null)
        //    {
        //        // Add menu Items here
        //    }
        //    return base.OnCreateOptionsMenu(menu);
        //}
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Android.Resource.Id.Home:
        //            if (mDrawerLayout.IsDrawerOpen(Android.Support.V4.View.GravityCompat.Start))
        //                mDrawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
        //            else
        //                mDrawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
        //            return true;
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}
        // Avoiding direct app exit
        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount != 0)
                FragmentManager.PopBackStack();
            else
                base.OnBackPressed();

        }
    }
}

