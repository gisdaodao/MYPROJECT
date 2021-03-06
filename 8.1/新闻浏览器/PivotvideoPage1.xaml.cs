﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SurfaceAd.SDK.WP;

namespace 股票新闻
{
    public partial class PivotvideoPage1 : PhoneApplicationPage
    {
        public PivotvideoPage1()
        {
            InitializeComponent();
            this.surfaceAdImageXaml.InitAdControl(AdModeType.Normal); 
        }
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot OBJ = sender as Pivot;
            if (OBJ.SelectedIndex == 1 && WB2.Source == null)
            {
                WB2.Navigate(new Uri(" http://letv.com", UriKind.Absolute));
            }
            if (OBJ.SelectedIndex == 2 && WB3.Source == null)
            {
                WB3.Navigate(new Uri("http://iqiyi.com/", UriKind.Absolute));
            }
            if (OBJ.SelectedIndex == 3 && WB4.Source == null)
            {
                WB4.Navigate(new Uri("https://m.pptv.com/", UriKind.Absolute));
            }
            if (OBJ.SelectedIndex == 4 && WB5.Source == null)
            {
                WB5.Navigate(new Uri("http://m.ku6.com/", UriKind.Absolute));
            }
            //if (OBJ.SelectedIndex == 5 && WB6.Source == null)
            //{
            //    WB6.Navigate(new Uri("http://mobile.globaltimes.cn/", UriKind.Absolute));
            //}
            //if (OBJ.SelectedIndex == 6 && WB7.Source == null)
            //{
            //    WB7.Navigate(new Uri("https://m.yahoo.com/", UriKind.Absolute));
            //}
        }
        private void PivotItem_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PivotItem_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
        private void AdView_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {

        }

        private void AdView_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            // 在此处添加事件处理程序实现。
            if (pivot.SelectedIndex == 0 && b1.CanGoBack)
            {
                b1.GoBack();
                e.Cancel = true;
            }
            else if (pivot.SelectedIndex == 1 && WB2.CanGoBack)
            {
                WB2.GoBack();
                e.Cancel = true;
            }
            else if (pivot.SelectedIndex == 2 && WB3.CanGoBack)
            {
                WB3.GoBack();
                e.Cancel = true;
            }
            else if (pivot.SelectedIndex == 3 && WB4.CanGoBack)
            {
                WB4.GoBack();
                e.Cancel = true;
            }
            else if (pivot.SelectedIndex == 4 && WB5.CanGoBack)
            {
                WB5.GoBack();
                e.Cancel = true;

            }
        }

    }
}