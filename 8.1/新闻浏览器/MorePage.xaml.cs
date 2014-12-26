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
    public partial class MorePage : PhoneApplicationPage
    {
        public MorePage()
        {
            InitializeComponent();
        }

        private void TBNEWSPHONE_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/phonePage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}