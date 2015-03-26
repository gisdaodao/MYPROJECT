using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
//using MSNADSDK.AD;
using 股票新闻;
using System.Diagnostics;
using HtmlAgilityPack;
using Microsoft.Phone.Tasks;

namespace OKr.MXReader.Client.View
{
    public partial class OneVideoinfoPage : PhoneApplicationPage
    {
        WebClient changgehefashengclient = new WebClient();
        List<Info> youkuchanggejiqiao = new List<Info>();
        public OneVideoinfoPage()
        {
            InitializeComponent();
           
            Random pr = new Random();
            int ji = pr.Next(1, 10);
            if (ji > 5)
            {
                //AdView adView = new AdView();

                //adView.Appid = "145444";

                //adView.SecretKey = "165feb8707004e6da3b3cdb1584e6515";



                //adView.SizeForAd = AdSize.Large;
                //adView.IsInterstitial = true;
                //adView.Adid = "191332";
                //adView.GetInterstitialAd();
                //this.LayoutRoot.Children.Add(adView);

            }
           

        }
        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask ptask = new WebBrowserTask();
            StackPanel st = sender as StackPanel;

            ptask.Uri = new Uri((st.DataContext as Info).dataurl, UriKind.RelativeOrAbsolute);
            ptask.Show();
        }

        void changgehefashengclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                bool rebool;
                string reustlstr = e.Result;
                HtmlAgilityPack.HtmlDocument result = new HtmlDocument();
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
                        youkuchanggejiqiao.Add(oneinfo);
                        //  lstbox.ItemsSource = youkuchanggejiqiao;
                  



                }
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    
                        //youkuchanggejiqiao.Clear();
                        //youkuchanggejiqiao.Add(oneinfo);
                        lstbox.ItemsSource = youkuchanggejiqiao;
                        // changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    
                });
            }
            catch (Exception)
            {


            }

        }

        WebClient pclient = new WebClient();
        string url = string.Empty;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            url = this.NavigationContext.QueryString["url"];
            base.OnNavigatedTo(e);
            changgehefashengclient.Encoding = System.Text.UTF8Encoding.UTF8;
            changgehefashengclient.DownloadStringAsync(new Uri(url, UriKind.RelativeOrAbsolute));
            changgehefashengclient.DownloadStringCompleted += changgehefashengclient_DownloadStringCompleted;
        }
    }
}