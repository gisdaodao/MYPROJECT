using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace OKr.MXReader.Client.View
{
    public partial class MusicPlayPage : PhoneApplicationPage
    {
        public MusicPlayPage()
        {
            InitializeComponent();
            mediaplay.Source = new Uri(App.musicfilepath, UriKind.RelativeOrAbsolute);
        }
    }
}