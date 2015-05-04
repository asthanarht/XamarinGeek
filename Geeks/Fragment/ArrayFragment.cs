using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;

using Android.Widget;

namespace Geeks
{
    public class ArrayFragment : Android.Support.V4.App.ListFragment,AbsListView.IOnScrollListener
    {
        private List<ArticleModel> mItem;
        private ListView mListView;

        public ArrayFragment()
        {

        }

        public async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var obj = new ArrayArticle("http://www.geeksforgeeks.org/category/c-arrays/");
            Task<List<ArticleModel>> lItem = obj.DownloadAsyncPage();

            mItem = await lItem;
            var adaptor = new CustomListAdaptor(Activity, mItem);

            ListAdapter = adaptor;
            ListView.SetOnScrollListener(this);
            // Set our view from the "main" layout resource
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Array_fragment, container, false);
            //mListView = view.FindViewById<ListView>(Resource.Id.list);
           
            
          
            return view;
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var webViewActivity = new Intent(Activity, typeof(WebViewActivity));
            webViewActivity.PutExtra("url", mItem[position].Url);
            StartActivity(webViewActivity);
        }


        public void OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount, int totalItemCount)
        {
            
        }

        public async void OnScrollStateChanged(AbsListView view, ScrollState scrollState)
        {
            int count = mItem.Count;
            if (scrollState == ScrollState.Idle)
            {
                if (ListView != null && ListView.LastVisiblePosition >= count - 1)
                {
                    int position = ListView.LastVisiblePosition;
                    var obj = new ArrayArticle("http://www.geeksforgeeks.org/category/c-arrays/page/2/");
                    Task<List<ArticleModel>> lItem = obj.DownloadAsyncPage();

                    mItem.AddRange(await lItem);

                    var adaptor = new CustomListAdaptor(Activity, mItem);

                    ListAdapter = adaptor;
                    ListView.SetSelectionFromTop(position,0);
                }
            }
        }
    }
}