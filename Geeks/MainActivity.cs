using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.App;
using com.refractored;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace Geeks
{
    [Activity(Label = "GeeksForGeeks", MainLauncher = true, Theme="@style/Theme.AppCompat", Icon = "@drawable/icon")]
    public class MainActivity : BaseActivity
    {
        int count = 1;
        protected override int LayoutResource
        {
            get { return Resource.Layout.Main; }
        }

        private CustomTabAdapter tabAdapter;
        private ViewPager pager;
        private PagerSlidingTabStrip tabs;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            tabAdapter = new CustomTabAdapter(SupportFragmentManager);
            pager = FindViewById<ViewPager>(Resource.Id.pager);
            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);

            pager.Adapter = tabAdapter;

            tabs.SetViewPager(pager);
            tabs.SetBackgroundColor(Color.DarkGreen);
            tabs.SetTabTextColor(Color.White);
            
            Drawable colorDrawable = new ColorDrawable(Color.DarkGreen);
            SupportActionBar.SetBackgroundDrawable(colorDrawable);
        }
    }
}

