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
    public partial class inputPanoramaPage : PhoneApplicationPage
    {
        string urlscheme1 = "http://";
        string urlscheme2 = "http://";
        string fullurl = "";
        public inputPanoramaPage()
        {
            InitializeComponent();
        }
        private void AdView_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {

        }

        private void AdView_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }
        private void rate_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(inputtb.Text)))
            {
                fullurl = urlscheme1 + inputtb.Text + list.DisplayMemberPath;
                wb.Navigate(new Uri(fullurl, UriKind.RelativeOrAbsolute));
            }
        }

        private void inputtb_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Enter && (!string.IsNullOrEmpty(inputtb.Text)))
                {
                    fullurl = urlscheme1 + inputtb.Text + list.SelectedItem.ToString();
                    wb.Navigate(new Uri(fullurl, UriKind.RelativeOrAbsolute));
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                
               
            }
           
        }

        private void ListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (inputtb != null && (!string.IsNullOrEmpty(inputtb.Text)))
                {
                    fullurl = urlscheme1 + inputtb.Text + list.SelectedItem.ToString();

                    wb.Navigate(new Uri(fullurl, UriKind.RelativeOrAbsolute));

                }
            }
            catch (Exception)
            {                
               
            }
           
        }
    }
}