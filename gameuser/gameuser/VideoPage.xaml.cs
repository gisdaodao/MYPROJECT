using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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
          }
          title.Text = App.tranferinfo.text; 
        }
    }
}