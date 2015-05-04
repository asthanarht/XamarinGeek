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

namespace Geeks
{
    public class ArticleModel
    {
        public string ArticleTitle { get; set; }

        public string ArticleDesc { get; set; }

        public string Url { get; set; }

    }
}