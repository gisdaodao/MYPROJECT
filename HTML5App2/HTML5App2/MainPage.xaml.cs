using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using JiuYouAd;
using JiuYouAd.Models;

namespace HTML5App2
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 主页的 Url
        private string MainUri = "/Html/index.html";
        AdControl adControl;
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            Random p = new Random();
            int i = p.Next(1, 10);
            if(i<=3)
            {
                adControl = new AdControl();
                adControl.ApplicationKey = "e840ec3f940ef5f387a335dffccf331f";
                adControl.AdType = AdType.FullScreen;
                adControl.Visibility = Visibility.Visible;
                adControl.AdClick += adControl_AdClick;
                this.LayoutRoot.Children.Add(adControl);
            }
           
        }

        private void adControl_AdClick(object sender, JiuYouAd.Models.AdClickEventArgs e)
        {
          
        }

        private void Browser_Loaded(object sender, RoutedEventArgs e)
        {
            Browser.IsScriptEnabled = true;

            // 在此处添加 URL
            Browser.Navigate(new Uri(MainUri, UriKind.Relative));
        }

        // 在 Web 浏览器的导航堆栈而不是应用程序中向后导航。
        private void BackApplicationBar_Click(object sender, EventArgs e)
        {
            Browser.GoBack();
        }

        // 在 Web 浏览器的导航堆栈而不是应用程序中向前导航。
        private void ForwardApplicationBar_Click(object sender, EventArgs e)
        {
            Browser.GoForward();
        }

        // 导航到初始“主页”。
        private void HomeMenuItem_Click(object sender, EventArgs e)
        {
            Browser.Navigate(new Uri(MainUri, UriKind.Relative));
        }

        // 处理导航故障。
        private void Browser_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            MessageBox.Show("无法导航到此页面，请检查 Internet 连接");
        }
    }
}
