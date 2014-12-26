using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using System.IO;
using Microsoft.Phone.Tasks;
using System.Diagnostics;

namespace 股票新闻
{
    public partial class phonePage : PhoneApplicationPage
    {
        public phonePage()
        {
            InitializeComponent();
            Pclient.OpenReadCompleted += Pclient_OpenReadCompleted;
            Pclient.OpenReadAsync(new Uri("https://raw.githubusercontent.com/gisdaodao/MYPROJECT/master/data/phonenumbers.xml", UriKind.Absolute));  
        }
        WebClient Pclient = new WebClient();
        List<string> urls = new List<string>();
        List<Info> items = new List<Info>();


        void Pclient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    Stream stream = e.Result;
                    XElement p = XElement.Load(stream);
                    //XName xname = XName.Get("url");
                    //IEnumerable<XElement> nodes = p.Descendants(xname).ToList<XElement>();
                    //foreach (var a in nodes)
                    //{
                    //    urls.Add(a.Value);
                    //}
                    // Deployment.Current.Dispatcher.BeginInvoke(() => { lstbox.ItemsSource = urls; });
                    XName xitemname = XName.Get("item");
                    IEnumerable<XElement> itemnodes = p.Descendants(xitemname).ToList<XElement>();
                    foreach (var b in itemnodes)
                    {
                        XName xurl = XName.Get("url");
                        XName xname = XName.Get("name");
                        items.Add(new Info() { text = b.Descendants(xname).First().Value,  dataurl = b.Descendants(xurl).First().Value });
                    }
                    Deployment.Current.Dispatcher.BeginInvoke(() => { lstbox.ItemsSource = items; });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Border border = sender as Border;
            Info info = border.DataContext as Info;
             PhoneCallTask pne = new PhoneCallTask();
            pne.PhoneNumber = info.dataurl;
            pne.Show();
            //Debug.WriteLine(info.dataurl);
            //WebBrowserTask task = new WebBrowserTask();
            //task.Uri = new Uri(info.dataurl, UriKind.RelativeOrAbsolute);
            //task.Show();

        }
    }
}