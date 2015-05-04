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
using Android.Webkit;

namespace Geeks
{
    [Activity(Label = "WebViewActivity")]
    public class WebViewActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Webview);

            var urlIntent = Intent.GetStringExtra("url") ?? "http://google.com";

            WebView webView = FindViewById<WebView>(Resource.Id.webView);
            webView.LoadUrl(urlIntent);
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.LoadWithOverviewMode = true;
            webView.Settings.UseWideViewPort = true;

        }
    }
}