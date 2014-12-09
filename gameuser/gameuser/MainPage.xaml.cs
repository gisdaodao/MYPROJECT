using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using Microsoft.Phone.Tasks;
using System.Xml.Linq;
using System.IO;
using 股票新闻;
using SurfaceAd.SDK.WP;

namespace gameuser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            Pclient.OpenReadCompleted += Pclient_OpenReadCompleted;
            Pclient.OpenReadAsync(new Uri("https://raw.githubusercontent.com/commonusechina/data/master/data/Asphalt8.xml", UriKind.Absolute));
            indicator.Text = "请求中...";
            indicator.IsVisible = true;
            indicator.IsIndeterminate = true;
            // 将 listbox 控件的数据上下文设置为示例数据
          //  this.CreateScreenAd();
            surfaceAdImageXaml.InitAdControl(AdModeType.Normal);
        }
        string title = string.Empty;
        // 为 ViewModel 项加载数据
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }
        /// <summary>
        /// 开屏图片广告
        /// </summary>
        void LoadScreenAd()
        {
            //new Utils().BindSurfaceAdInterstitialControlEvent(this.surfaceAdScreenImage);

           // this.surfaceAdScreenImage.InitAdControl(AdModeType.Debug);
        }
        void SetRateMenuItem_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask(); marketplaceReviewTask.Show();
        }
        void CreateScreenAd()
        {
            SurfaceAdInterstitialControl surfaceAdControl = new SurfaceAdInterstitialControl()
            {
                // 开发者Token
                AdToken = "MF04XWUBNl8wUThaZRc2XzBD",
                //开发者嵌入广告形式的广告位ID
                AdPosition = "6e3e3ba78cb584b177fa47cc1c88087e",
                //广告类型为开屏广告
                InterstitialAdType = AdInterstitialType.FirstLanuche,
                //开屏广告展示时长，单位为秒
                InterstitialAdShowTime = 4
            };
            this.LayoutRoot.Children.Add(surfaceAdControl);
            //new Utils().BindSurfaceAdInterstitialControlEvent(surfaceAdControl);
            surfaceAdControl.InitAdControl(AdModeType.Normal);
        }
     
        WebClient Pclient = new WebClient();
        List<string> urls = new List<string>();
        List<Info> items = new List<Info>();


        void Pclient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    Stream stream = e.Result;
                    XElement p = XElement.Load(stream);
                  //  XName xitems = XName.Get("Items");
                    //string tile = p.Descendants(xitems).First().FirstAttribute.Value;
            //   XElement itemelents = p.Descendants(xitems).First();
                   // title = p.Value;
                   // panorama.Title = tile;
                    //XName xname = XName.Get("url");
                    //IEnumerable<XElement> nodes = p.Descendants(xname).ToList<XElement>();
                    //foreach (var a in nodes)
                    //{
                    //    urls.Add(a.Value);
                    //}
                    // Deployment.Current.Dispatcher.BeginInvoke(() => { lstbox.ItemsSource = urls; });
                    XName xitemname = XName.Get("item");
                    IEnumerable<XElement> itemnodes = p.Descendants(xitemname).ToList<XElement>();
                    items.Clear();
                    foreach (var b in itemnodes)
                    {
                        XName xname = XName.Get("url");
                          XName xpicname = XName.Get("picurl");
                          items.Add(new Info() { text = b.FirstAttribute.Value, info = b.LastAttribute.Value, dataurl = b.Descendants(xname).First().Value, picurl = b.Descendants(xpicname).First().Value });
                    }
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        if (panorama.SelectedIndex==0)
                        {
                            lstbox.ItemsSource = items; indicator.IsVisible = false;
                            indicator.IsIndeterminate = false;
                        }
                        if (panorama.SelectedIndex == 2)
                        {
                            otherlstbox.ItemsSource = items; indicator.IsVisible = false;
                            indicator.IsIndeterminate = false;
                        }
                       
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           
            Border border = sender as Border;
            Info info = border.DataContext as Info;
            //this.NavigationService.Navigate(new Uri("/VideoPage.xaml?url="+info.dataurl, UriKind.RelativeOrAbsolute));
            //Debug.WriteLine(info.dataurl);
            //App.tranferinfo = info;
           // return;
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(info.dataurl, UriKind.RelativeOrAbsolute);
            task.Show();

        }

        private void panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(panorama.SelectedIndex==2&&otherlstbox.ItemsSource ==null)
            {
                if (Pclient.IsBusy) return;
                Pclient.OpenReadAsync(new Uri("https://raw.githubusercontent.com/commonusechina/data/master/data/othergames.xml", UriKind.Absolute));
                indicator.Text = "请求中...";
                indicator.IsVisible = true;
                indicator.IsIndeterminate = true;
            }            
        }
    }
}