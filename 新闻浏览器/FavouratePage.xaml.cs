using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using Microsoft.Phone.Tasks;

namespace 股票新闻
{
    public partial class FavouratePage : PhoneApplicationPage
    {
        public FavouratePage()
        {
            InitializeComponent();

            falist = sitesttings["favaouratesite"] as List<Info>;
            favaroutelistbox.ItemsSource = falist;
        }
        //IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
        IsolatedStorageSettings sitesttings = IsolatedStorageSettings.ApplicationSettings;
        List<Info> falist = new List<Info>();

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid border = sender as Grid;
            Info info = border.DataContext as Info;
            Debug.WriteLine(info.dataurl);
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(info.dataurl, UriKind.RelativeOrAbsolute);
            task.Show();
        }
    }
}