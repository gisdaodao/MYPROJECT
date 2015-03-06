using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using changgeshipinjiqiao.Resources;
using 股票新闻;
using System.Diagnostics;
using HtmlAgilityPack;
using Microsoft.Phone.Tasks;
using MSNADSDK.AD;
using System.IO.IsolatedStorage;
namespace changgeshipinjiqiao
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            changgehefashengclient.Encoding = System.Text.UTF8Encoding.UTF8;
            changgehefashengclient.DownloadStringAsync(new Uri(changgehefashengstr, UriKind.RelativeOrAbsolute));
            changgehefashengclient.DownloadStringCompleted += changgehefashengclient_DownloadStringCompleted;
            Random pr = new Random();
            int ji=pr.Next(1,3);
            if(ji>2)
            {
                AdView adView = new AdView();

                adView.Appid = "145444";

                adView.SecretKey = "165feb8707004e6da3b3cdb1584e6515";



                adView.SizeForAd = AdSize.Large;
                adView.IsInterstitial = true;
                adView.Adid = "191332";
                adView.GetInterstitialAd();
                this.LayoutRoot.Children.Add(adView);
         
            }
           

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }
        
        //string appname = "唱歌技巧之视频教程";
        //string changgehefashengstr = "http://www.youku.com/playlist_show/id_18972217.html?sf=10701";
        //string mvchanggehefashengstr = "http://www.youku.com/playlist_show/id_21174496.html?sf=11001";
        //string haominlaoshistr = "http://www.youku.com/playlist_show/id_21824652.html?sf=10101";
        //string jonhlaoshistr = "http://www.youku.com/playlist_show/id_18559647.html?sf=21001";
        //string xuegestr = "http://www.youku.com/playlist_show/id_19927545.html?sf=10901";
        string appname = "舞蹈教学";
        string changgehefashengstr = "http://www.youku.com/playlist_show/id_6101807.html?sf=10501";
        string mvchanggehefashengstr = "http://www.youku.com/playlist_show/id_3397301.html?sf=10101";
        string haominlaoshistr = "http://www.youku.com/playlist_show/id_2908678.html?sf=10401";
        string jonhlaoshistr = "http://www.youku.com/playlist_show/id_16908333.html?sf=10301";
        string xuegestr = "http://www.youku.com/playlist_show/id_3933228.html?sf=11001";
        WebClient pclient = new WebClient();
        WebClient changgehefashengclient = new WebClient();
        List<Info> youkuchanggejiqiao = new List<Info>();
        List<Info> mvchanggehefashengjiqiao = new List<Info>();
        List<Info> haominlaoshijiqiao = new List<Info>();
        List<Info> jonhjiqiao = new List<Info>();
        List<Info> xuegejiqiao = new List<Info>();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clicked"))
            {
                //settings.Add("clicked", DateTime.Now.Date.ToString());
                //settings.Save();
            }
            else
            {
             string clikecdate=   settings["clicked"].ToString() ;
                if(clikecdate==DateTime.Now.Date.ToString())
                {
                    st.Visibility = Visibility.Collapsed;
                }
            }
            base.OnNavigatedTo(e);
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
                    Debug.WriteLine( oneinfo.text );
                 //   Debug.WriteLine( oneinfo.picurl);
                    if (panorama.SelectedIndex == 0)
                    {
                       // youkuchanggejiqiao.Clear();
                        youkuchanggejiqiao.Add(oneinfo);
                      //  lstbox.ItemsSource = youkuchanggejiqiao;
                        // changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 1)
                    {
                      //  mvchanggehefashengjiqiao.Clear();
                        mvchanggehefashengjiqiao.Add(oneinfo);
                      //  lstbox1.ItemsSource = mvchanggehefashengjiqiao;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 2)
                    {
                      //  haominlaoshijiqiao.Clear();
                        haominlaoshijiqiao.Add(oneinfo);
                       // lstbox2.ItemsSource = haominlaoshijiqiao;
                        //changgehefashengclient.DownloadStringAsync(new Uri(haominlaoshistr, UriKind.RelativeOrAbsolute));

                    }
                    if (panorama.SelectedIndex == 3)
                    {
                       // jonhjiqiao.Clear();
                        jonhjiqiao.Add(oneinfo);
                       // lstbox3.ItemsSource = jonhjiqiao;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(jonhlaoshistr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 4)
                    {
                      ///  xuegejiqiao.Clear();
                        xuegejiqiao.Add(oneinfo);
                        //lstbox4.ItemsSource = xuegejiqiao;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(xuegestr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 5)
                    {
                        //youkuchanggejiqiao.Clear();
                        //youkuchanggejiqiao.Add(oneinfo);
                        //  changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    }
               
                   
                  
                }
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (panorama.SelectedIndex == 0)
                    {
                        //youkuchanggejiqiao.Clear();
                        //youkuchanggejiqiao.Add(oneinfo);
                        lstbox.ItemsSource = youkuchanggejiqiao;
                        // changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 1)
                    {
                        //mvchanggehefashengjiqiao.Clear();
                        //mvchanggehefashengjiqiao.Add(oneinfo);
                        lstbox1.ItemsSource = mvchanggehefashengjiqiao;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 2)
                    {
                        //haominlaoshijiqiao.Clear();
                        //haominlaoshijiqiao.Add(oneinfo);
                        lstbox2.ItemsSource = haominlaoshijiqiao;
                        //changgehefashengclient.DownloadStringAsync(new Uri(haominlaoshistr, UriKind.RelativeOrAbsolute));

                    }
                    if (panorama.SelectedIndex == 3)
                    {
                        //jonhjiqiao.Clear();
                        //jonhjiqiao.Add(oneinfo);
                        lstbox3.ItemsSource = jonhjiqiao;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(jonhlaoshistr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 4)
                    {
                        //xuegejiqiao.Clear();
                        //xuegejiqiao.Add(oneinfo);
                        lstbox4.ItemsSource = xuegejiqiao;
                        //  changgehefashengclient.DownloadStringAsync(new Uri(xuegestr, UriKind.RelativeOrAbsolute));
                    }
                    if (panorama.SelectedIndex == 5)
                    {
                        //youkuchanggejiqiao.Clear();
                        //youkuchanggejiqiao.Add(oneinfo);
                        //  changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
                    }
                });
            }
            catch (Exception)
            {
                
               
            }
            
        }

        private void Panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Panorama obj = sender as Panorama;
            if (obj.SelectedIndex == 1 && mvchanggehefashengjiqiao.Count <= 0)
            {
                changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
            }
            if (obj.SelectedIndex == 2 && haominlaoshijiqiao.Count <= 0)
            {
                changgehefashengclient.DownloadStringAsync(new Uri(haominlaoshistr, UriKind.RelativeOrAbsolute));

            }
            if (obj.SelectedIndex == 3 && jonhjiqiao.Count <= 0)
            {
                changgehefashengclient.DownloadStringAsync(new Uri(jonhlaoshistr, UriKind.RelativeOrAbsolute));
            }
            if (obj.SelectedIndex == 4 && xuegejiqiao.Count <= 0)
            {
                changgehefashengclient.DownloadStringAsync(new Uri(xuegestr, UriKind.RelativeOrAbsolute));
            }
            if (obj.SelectedIndex == 5)
            {
                changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask ptask = new WebBrowserTask();
            StackPanel st = sender as StackPanel;

            ptask.Uri = new Uri((st.DataContext as Info).dataurl, UriKind.RelativeOrAbsolute);
            ptask.Show();
        }

        private void AdView_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void AdView_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void AdView_AdActionEvent(object sender, AdActionEventArgs args)
        {

        }
    
        private void AdView_AdExpanded(object sender, EventArgs e)
        {
            st.Visibility = Visibility.Collapsed;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clicked"))
            {
                settings.Add("clicked", DateTime.Now.Date.ToString());
                settings.Save();
            }
            //else
            //{
            //    settings["clicked"] = App.User.UserId;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            st.Visibility = Visibility.Collapsed;
            MarketplaceReviewTask p = new MarketplaceReviewTask();
         
            p.Show();
        }
        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}