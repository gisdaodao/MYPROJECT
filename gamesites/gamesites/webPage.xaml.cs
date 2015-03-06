using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace gamesites
{
    public partial class webPage : PhoneApplicationPage
    {
        public webPage()
        {
            InitializeComponent();
        }
        string url = string.Empty;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            url = this.NavigationContext.QueryString["url"];
            wb.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
           // tb.Text = url;
            base.OnNavigatedTo(e);
        }
    }
}