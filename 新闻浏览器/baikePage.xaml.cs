﻿using System;
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
    public partial class baikePage : PhoneApplicationPage
    {
        public baikePage()
        {
            InitializeComponent();
        }
        private void AdView_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {

        }

        private void AdView_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }
        private void panoroma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (panoroma.SelectedIndex == 0)
            {
                b1.GoBack();
            }
            if (panoroma.SelectedIndex == 1 && b2.Source == null)
            {
                b2.Navigate(new Uri("http://en.m.wikipedia.org/wiki/Main_Page", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 2 && b3.Source == null)
            {
                b3.Navigate(new Uri("http://m.zhihu.com/read", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 3 && b4.Source == null)
            {
                b4.Navigate(new Uri("http://m.baike.com/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 4 && b5.Source == null)
            {
                b5.Navigate(new Uri("http://m.baike.so.com/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 5 && b6.Source == null)
            {
                b6.Navigate(new Uri("http://baike.m.sogou.com/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 6 && b7.Source == null)
            {
                b7.Navigate(new Uri("http://wapwenku.baidu.com/", UriKind.Absolute));
            }
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            // 在此处添加事件处理程序实现。
            if (panoroma.SelectedIndex == 0 && b1.CanGoBack)
            {
                b1.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 1 && b2.CanGoBack)
            {
                b2.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 2 && b3.CanGoBack)
            {
                b3.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 3 && b4.CanGoBack)
            {
                b4.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 4 && b5.CanGoBack)
            {
                b5.GoBack();
                e.Cancel = true;

            }
            else if (panoroma.SelectedIndex == 5 && b6.CanGoBack)
            {
                b6.GoBack();
                e.Cancel = true;

            }
            else if (panoroma.SelectedIndex == 6 && b7.CanGoBack)
            {
                b7.GoBack();
                e.Cancel = true;

            }
        }
    }
}