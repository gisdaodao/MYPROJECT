using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace 股票新闻
{
    public partial class SearchPanoramaPage : PhoneApplicationPage
    {
        public SearchPanoramaPage()
        {
            InitializeComponent();
        }

        private void SearchsosoBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://www.sogou.com/web?query=" + keywordbox.Text;
            searwb.Navigate(new Uri(url, UriKind.Absolute));
        }

        private void SearchbaiduBtn_Click(object sender, RoutedEventArgs e)
        {
            string  url="http://www.baidu.com/s?wd="+keywordbox.Text;
            searwb.Navigate(new Uri(url, UriKind.Absolute));
        }

        private void SearchbinguBtn_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://cn.bing.com/search?q=" + keywordbox.Text;
            searwb.Navigate(new Uri(url, UriKind.Absolute));
        }

        private void keywordbox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
        private void AdView_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {

        }

        private void AdView_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }
    }
}