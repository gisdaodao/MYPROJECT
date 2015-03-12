using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using cctv.Resources;
using HtmlAgilityPack;
using System.Diagnostics;
using 股票新闻;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
//using JiuYouAd;
//using JiuYouAd.Models;
//using MSNADSDK.AD;

namespace cctv
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        string lmstr = "http://cctv.cntv.cn/lm/tiyushijie/";
        string rquestdate = string.Empty;
        string requestformat = ".shtml";
        string requesturl = string.Empty;


        string videourl = "http://v.cctv.com/flash/mp4video40/TMS/";
        string datestr = string.Empty;
        string fileid = string.Empty;
        string commonstr = "_h264418000nero_aac32-";
        int videoindex = 1;
        string houzuistr = ".mp4";
        string fullpath = string.Empty;
        WebClient pclient = new WebClient();
        WebClient todayclient = new WebClient();
        public MainPage()
        {
            InitializeComponent();
          
          //  pclient.DownloadStringAsync(new Uri(str, UriKind.RelativeOrAbsolute));
            pclient.DownloadStringCompleted += pclient_DownloadStringCompleted;         
            rquestdate = DateTime.Now.Date.ToString("yyyyMMdd");
            Debug.WriteLine(rquestdate+"rquestdate");
            requesturl = lmstr + rquestdate + requestformat;
            todayclient.OpenReadAsync(new Uri(lmstr, UriKind.RelativeOrAbsolute));
            todayclient.OpenReadCompleted += todayclient_OpenReadCompleted;
            pclient.OpenReadCompleted += pclient_OpenReadCompleted;
            Debug.WriteLine(requesturl);
            Random pr = new Random();
            int ji = pr.Next(1, 10);
            if (ji > 8)
            {
                //JiuYouAd.AdControl adView = new AdControl();

                //adView.ApplicationKey = "f21af0bd8d97b649fe2290ef4dec8ce3";

                //adView.AdType = AdType.FullScreen;



                //adView.Visibility = Visibility.Visible;

                //this.LayoutRoot.Children.Add(adView);

            }
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        void todayclient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {

                    Stream stream = e.Result;
                    StreamReader reader = new StreamReader(stream, DBCSCodePage.DBCSEncoding.GetDBCSEncoding("gb2312"));
                    while (!reader.EndOfStream)
                    {
                        string str = reader.ReadLine();
                        Debug.WriteLine(str);
                        if (str.Contains("dateurl = 2"))
                        {
                            Debug.WriteLine(str);
                            rquestdate = str.Split('=')[1].TrimStart().Substring(0, 8);
                            Debug.WriteLine(datestr);
                            Debug.WriteLine("ffffffffffffffffffdatestr");
                            requesturl = lmstr + rquestdate + requestformat;
                            Debug.WriteLine(requesturl);
                            pclient.Encoding = DBCSCodePage.DBCSEncoding.GetDBCSEncoding("gb2312");
                            pclient.OpenReadAsync(new Uri(requesturl, UriKind.RelativeOrAbsolute));
                            pclient.OpenReadCompleted += pclient_OpenReadCompleted;
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("今天还没更新,请选择其他日期");
            }
           
        }

        void pclient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs er)
        {
            try
            {
                if (er.Result != null)
                {

                    Stream stream = er.Result;
                    StreamReader reader = new StreamReader(stream, DBCSCodePage.DBCSEncoding.GetDBCSEncoding("gb2312"));
                    while (!reader.EndOfStream)
                    {
                        string tempstr = reader.ReadLine();
                        //    Debug.WriteLine(reader.ReadToEnd());
                        if (tempstr.Contains("videoCenterId"))
                        {
                            List<int> intindex = new List<int>();
                            char[] chararray = tempstr.ToCharArray();
                            for (int i = 0; i < chararray.Length - 1; i++)
                            {
                                char a = chararray[i];
                                Debug.WriteLine(a);
                                if (a == '"')
                                {
                                    intindex.Add(i);
                                    Debug.WriteLine(i);
                                }
                            }
                            DateTime dt = DateTime.ParseExact(rquestdate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture); ;
                            fileid = tempstr.Substring(intindex.ElementAt(2) + 1, intindex.ElementAt(3) - intindex.ElementAt(2) - 1);
                            fullpath = videourl + dt.Date.ToString("yyyy/MM/dd") + "/" + fileid + commonstr + videoindex.ToString() + houzuistr;
                            currenttb.Text = "当前节目时间是：" + rquestdate;
                            mediaelent.Source = new Uri(fullpath, UriKind.RelativeOrAbsolute);
                            Debug.WriteLine(fullpath);
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("连接请求错误或者今天没有改节目");
               
            }
         
        }
        void pclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                string reustlstr = e.Result;
                Debug.WriteLine(reustlstr);
                HtmlAgilityPack.HtmlDocument result = new HtmlDocument();
                result.LoadHtml(reustlstr);
                ullist = result.DocumentNode.Descendants("ul");
                foreach (var a in ullist)
                {
                    if (a.HasAttributes && a.Id == "piclist")
                    {
                        ulhtmlnode = a;
                        foreach (var li in ulhtmlnode.Descendants("li"))
                        {
                            HtmlNode anode = li.Descendants("a").First();
                            Info oneinfo = new Info();
                            if (anode.HasAttributes)
                            {
                                string href = anode.Attributes["href"].Value;
                                oneinfo.dataurl = href;
                                HtmlNode img = anode.Descendants("img").First();
                                oneinfo.picurl = img.Attributes["src"].Value;
                                oneinfo.text = img.Attributes["alt"].Value;
                                Debug.WriteLine(oneinfo.dataurl + oneinfo.picurl + oneinfo.text);
                            }
                            // return;
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("连接服务器错误");
                
            }
            
        }
        List<Info> infolist = new List<Info>();
        IEnumerable<HtmlAgilityPack.HtmlNode> ullist = null;
        HtmlNode ulhtmlnode = null;

        private void mediaelent_MediaEnded(object sender, RoutedEventArgs e)
        {
            try
            {
                videoindex = videoindex + 1;
                if (videoindex < 4)
                {
                    DateTime dt = DateTime.ParseExact(rquestdate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture); ;
                    fullpath = videourl + dt.Date.ToString("yyyy/MM/dd") + "/" + fileid + commonstr + videoindex.ToString() + houzuistr;
                    mediaelent.Source = new Uri(fullpath, UriKind.RelativeOrAbsolute);
                    Debug.WriteLine(fullpath);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("播放错误");
            }
          
        }

        private void DatePicker_ValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            try
            {
                if (e.NewDateTime.HasValue)
                {
                    rquestdate = e.NewDateTime.Value.Date.ToString("yyyyMMdd"); ;
                    requesturl = lmstr + rquestdate + requestformat;
                    Debug.WriteLine(requesturl);
                    pclient.Encoding = DBCSCodePage.DBCSEncoding.GetDBCSEncoding("gb2312");
                    pclient.OpenReadAsync(new Uri(requesturl, UriKind.RelativeOrAbsolute));
                }
            }
            catch (Exception)
            {
                
              
            }
           
        }
        private void AdView_AdExpanded(object sender, EventArgs e)
        {
            st.Visibility = Visibility.Collapsed;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clicked"))
            {
                settings.Add("clicked", DateTime.Now.Date.ToString());
                settings.Save();
            }
            //else
            //{
            //    settings["clicked"] = App.User.UserId;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            st.Visibility = Visibility.Collapsed;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clicked"))
            {
                settings.Add("clicked", DateTime.Now.Date.ToString());
                settings.Save();
            }
            MarketplaceReviewTask p = new MarketplaceReviewTask();

            p.Show();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clicked"))
            {
                //settings.Add("clicked", DateTime.Now.Date.ToString());
                //settings.Save();
            }
            else
            {
                string clikecdate = settings["clicked"].ToString();
                if (clikecdate == DateTime.Now.Date.ToString())
                {
                    st.Visibility = Visibility.Collapsed;
                }
            }
            base.OnNavigatedTo(e);
        }

        private void paramBar_Click(object sender, EventArgs e)
        {
            mediaelent.Play();
        }

        private void likeBar_Click(object sender, EventArgs e)
        {
            mediaelent.Pause();
        }

        private void SendCommentsBar_Click(object sender, EventArgs e)
        {
            mediaelent.Stop();
        }

        private void SendzanBar_Click(object sender, EventArgs e)
        {
            requesturl = lmstr + rquestdate + requestformat;
            todayclient.OpenReadAsync(new Uri(lmstr, UriKind.RelativeOrAbsolute));
        }

        //private void AdControl_AdClick(object sender, AdClickEventArgs e)
        //{
        //    st.Visibility = Visibility.Collapsed;
        //    var settings = IsolatedStorageSettings.ApplicationSettings;
        //    if (!settings.Contains("clicked"))
        //    {
        //        settings.Add("clicked", DateTime.Now.Date.ToString());
        //        settings.Save();
        //    }
        //}

        private void paramenu_Click(object sender, EventArgs e)
        {
            WebBrowserTask pnew = new WebBrowserTask();
            if (mediaelent.Source!=null)
            {
                pnew.Uri = mediaelent.Source;
                pnew.Show();
            }
           
        }

        private void AdControl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            st.Visibility = Visibility.Collapsed;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("clicked"))
            {
                settings.Add("clicked", DateTime.Now.Date.ToString());
                settings.Save();
            }
        }
        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}