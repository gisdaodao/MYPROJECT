using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using Microsoft.Phone.Tasks;
using System.Xml.Linq;
using System.IO;
using 股票新闻;

namespace gameuser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            Pclient.OpenReadCompleted += Pclient_OpenReadCompleted;
            Pclient.OpenReadAsync(new Uri("https://raw.githubusercontent.com/gisdaodao/MYPROJECT/master/data/recoomendapplist.xml", UriKind.Absolute));
            indicator.Text = "请求中...";
            indicator.IsVisible = true;
            indicator.IsIndeterminate = true;
            // 将 listbox 控件的数据上下文设置为示例数据
         
        }
        string title = string.Empty;
        // 为 ViewModel 项加载数据
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
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
                    //XName xitems = XName.Get("Items");
                    //XElement itemelents = p.Descendants(xitems).First();
                    title = p.Value;

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
                        XName xname = XName.Get("url");
                          XName xpicname = XName.Get("picurl");
                          items.Add(new Info() { text = b.FirstAttribute.Value, info = b.LastAttribute.Value, dataurl = b.Descendants(xname).First().Value, picurl = b.Descendants(xpicname).First().Value });
                    }
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        lstbox.ItemsSource = items; indicator.IsVisible = false;
                        indicator.IsIndeterminate = false;
                    });
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
            this.NavigationService.Navigate(new Uri("/VideoPage.xaml?url="+info.dataurl, UriKind.RelativeOrAbsolute));
            Debug.WriteLine(info.dataurl);
            App.tranferinfo = info;
            return;
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(info.dataurl, UriKind.RelativeOrAbsolute);
            task.Show();

        }
    }
}