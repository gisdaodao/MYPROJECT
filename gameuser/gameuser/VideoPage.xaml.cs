using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SurfaceAd.SDK.WP;

namespace gameuser
{
    public partial class VideoPage : PhoneApplicationPage
    {
        string url = string.Empty;
        public VideoPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          if(e.NavigationMode==NavigationMode.New)
          {
              url = this.NavigationContext.QueryString["url"];
              urlname.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
             // CreateScreenAd();
          }
          title.Text = App.tranferinfo.text; 
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
    }
}