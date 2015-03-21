using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 股票新闻;
using HtmlAgilityPack;
using System.Diagnostics;

namespace cctv
{
    public partial class SearchPage1xaml : PhoneApplicationPage
    {
        public SearchPage1xaml()
        {
            InitializeComponent();
            p.DownloadStringAsync(new Uri(str, UriKind.RelativeOrAbsolute));
            p.DownloadStringCompleted += p_DownloadStringCompleted;
        }

        void p_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                bool rebool;
                string reustlstr = e.Result;
                HtmlAgilityPack.HtmlDocument result = new HtmlDocument();
              //HtmlAgilityPack.
                result.LoadHtml(reustlstr);
                IEnumerable<HtmlNode> div = result.DocumentNode.Descendants("div").Where((aa, retask) =>
                {
                    if (aa.HasAttributes && aa.Attributes["class"] != null && aa.Attributes["class"].Value == "items")
                    { return true; }
                    else
                    {
                        return false;
                    }
                });
                HtmlNode divnode = div.First();
                IEnumerable<HtmlNode> ulnodes = divnode.Descendants("ul");
                foreach (var a in ulnodes)
                {
                    var anode = a.Descendants("a").First();

                    Info oneinfo = new Info();
                    oneinfo.dataurl = anode.Attributes["href"].Value;
                    oneinfo.text = anode.Attributes["title"].Value;
                    oneinfo.picurl = a.Descendants("img").First().Attributes["src"].Value;
                    // Debug.WriteLine(oneinfo.dataurl );
                    Debug.WriteLine(oneinfo.text);
                    //   Debug.WriteLine( oneinfo.picurl);
                   
                        // youkuchanggejiqiao.Clear();
                    result.Add(oneinfo);
                        //  lstbox.ItemsSource = youkuchanggejiqiao;
                        // changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                  



                }
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    
                        //xuegejiqiao.Clear();
                        //xuegejiqiao.Add(oneinfo);
                   // lstbox4.ItemsSource = result;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(xuegestr, UriKind.RelativeOrAbsolute));
                   
                });
            }
            catch (Exception)
            {


            }
        }
        List<Info> result = new List<Info>();
        string str = "http://search.cctv.com/search.php?qtext=%E7%94%9F%E8%B4%A2%E6%9C%89%E9%81%93&redirect=1";
        WebClient p = new WebClient();
    }
}