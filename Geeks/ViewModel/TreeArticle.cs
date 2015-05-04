using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Android.App;
using HtmlAgilityPack;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Geeks
{
    public class TreeArticle
    {
        public async Task<List<ArticleModel>> DownloadAsyncPage()
        {
            var articleList = new ArticleModel();
            var httpClient = new HttpClient();
            var doc = httpClient.GetStringAsync("http://www.geeksforgeeks.org/category/tree/");

            HtmlDocument htmlD = new HtmlDocument {OptionFixNestedTags = true};
            htmlD.LoadHtml(await doc);
            var item = htmlD.DocumentNode.Descendants("div").Where(o => o.GetAttributeValue("class", "") == "post-main");
            return (from localitem in item let articleTile = localitem.ChildNodes.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("href")) let articleDesc = localitem.ChildNodes.Descendants("p").FirstOrDefault() select new ArticleModel() { ArticleDesc = WebUtility.HtmlDecode(articleDesc.InnerText), ArticleTitle = WebUtility.HtmlDecode(articleTile.InnerText), Url = articleTile.Attributes["href"].Value }).ToList();
        }
    }
}