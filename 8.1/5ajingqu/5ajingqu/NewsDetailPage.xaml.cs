using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppStudio.Data;
using Windows.System;

namespace _5ajingqu
{
    public partial class NewsDetailPage : PhoneApplicationPage
    {
        RssSchema one;
        public NewsDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("onenew"))
            {
                one = PhoneApplicationService.Current.State["onenew"] as RssSchema;
                tbHeader.Text = one.DefaultTitle;
                tbcontent.Text = one.Summary;
                
            }
            base.OnNavigatedTo(e);
        }

        private async void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            string url = one.FeedUrl;
            if (!String.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                await Launcher.LaunchUriAsync(new Uri(url,UriKind.Absolute));
            }
        }  
    }
}