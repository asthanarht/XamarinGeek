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
    public class CustomListAdaptor : BaseAdapter<ArticleModel>
    {
        //http://www.jayrambhia.com/blog/swipe-listview/
        private List<ArticleModel> artilceList; 
        private Context mContext;

        public CustomListAdaptor(Context context, List<ArticleModel> articleList)
        {
            this.artilceList = articleList;
            this.mContext = context;
        }


        public override ArticleModel this[int position]
        {
            get { return artilceList[position]; }
        }

        public override int Count
        {
            get { return artilceList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                LayoutInflater lv = (LayoutInflater) mContext.GetSystemService(Context.LayoutInflaterService);

                row = lv.Inflate(Resource.Layout.CustomList,null);
            }

            TextView tvArticleTitle = row.FindViewById<TextView>(Resource.Id.textLatestArticle);

            tvArticleTitle.Text = artilceList[position].ArticleTitle;

            TextView tvArticledesc = row.FindViewById<TextView>(Resource.Id.textArticleDesc);

            tvArticledesc.Text = artilceList[position].ArticleDesc;

            return row;
        }
    }
}