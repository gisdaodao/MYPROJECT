﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GoogleAds;
using SurfaceAd.SDK.WP;

namespace 股票新闻
{
    public partial class jingjiPanoramaPage : PhoneApplicationPage
    {
        public jingjiPanoramaPage()
        {
            InitializeComponent();
            this.surfaceAdImageXaml.InitAdControl(AdModeType.Normal); 
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
            else if (panoroma.SelectedIndex == 7 && b8.CanGoBack)
            {
                b8.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 8 && b9.CanGoBack)
            {
                b9.GoBack();
                e.Cancel = true;
            }

            else
            {
                e.Cancel = false;
            }
        }
          private void AdView_ReceivedAd(object sender, AdEventArgs e)
          {

          }
          private void panoroma_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              try
              {
                  if (panoroma.SelectedIndex == 0)
                  {
                      //  b1.GoBack();
                  }
                  if (panoroma.SelectedIndex == 1 && b2.Source == null)
                  {
                      b2.Navigate(new Uri("http://i.ifeng.com/finance/financei?&vt=5&mid=1Nmkbp", UriKind.Absolute));
                  }
                  if (panoroma.SelectedIndex == 2 && b3.Source == null)
                  {
                      b3.Navigate(new Uri("http://wap.stcn.com/", UriKind.Absolute));
                  }
                  if (panoroma.SelectedIndex == 3 && b4.Source == null)
                  {
                      b4.Navigate(new Uri("http://m.caixin.com/", UriKind.Absolute));
                  }
                  if (panoroma.SelectedIndex == 4 && b5.Source == null)
                  {
                      b5.Navigate(new Uri("http://m.sohu.com/c/5/", UriKind.Absolute));
                  }
                  if (panoroma.SelectedIndex == 5 && b6.Source == null)
                  {
                      b6.Navigate(new Uri("http://www.chinadaily.com.cn/bizchina/economy.html", UriKind.Absolute));
                    //  b6.Navigate(new Uri("http://www.chinadaily.com.cn/bizchina/economy.html", UriKind.Absolute));
                  }
                  if (panoroma.SelectedIndex == 6 && b7.Source == null)
                  {
                      b7.Navigate(new Uri("http://m.china.com.cn/1/wm/2/list_2_1_30.html", UriKind.Absolute));
                  }

                  if (panoroma.SelectedIndex == 7 && b8.Source == null)
                  {
                      b8.Navigate(new Uri("http://m.caijing.com.cn/", UriKind.Absolute));
                  }
                  if (panoroma.SelectedIndex == 8 && b9.Source == null)
                  {
                      b9.Navigate(new Uri("http://m.21jingji.com/", UriKind.Absolute));
                  }

              }
              catch (Exception)
              {
                
              }
              

          }

          private void AdView_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
          {

          }
        
    }
}