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
using System.Xml.Linq;


namespace cctv
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        string lmstr = "http://cctv.cntv.cn/lm/tiyuxinwen/";
        string rquestdate = string.Empty;
        string requestformat = ".shtml";
        string requesturl = string.Empty;


        string videourl = "http://v.cctv.com/flash/mp4video43/TMS/";
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
          //  rquestdate = DateTime.Now.Date.ToString("yyyy/MM/dd");
            requesturl = lmstr + rquestdate + requestformat;
            todayclient.OpenReadAsync(new Uri(lmstr, UriKind.RelativeOrAbsolute));
            todayclient.OpenReadCompleted += todayclient_OpenReadCompleted;
            Debug.WriteLine(lmstr);
            Random pr = new Random();
            //int ji = pr.Next(1, 3);
            //if (ji > 1.5)
            //{
            //    AdView adView = new AdView();

            //    adView.Appid = "145456";

            //    adView.SecretKey = "db1196a55e984251bcaddf37575a8464";



            //    adView.SizeForAd = AdSize.Large;
            //    adView.IsInterstitial = true;
            //    adView.Adid = "191344";
            //    adView.GetInterstitialAd();
            //    this.LayoutRoot.Children.Add(adView);

            //}
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
            string Getstr = "https://raw.githubusercontent.com/gisdaodao/MYPROJECT/master/adlist.xml";
            //   string Getstr = CommonString.ip + CommonFunction.GetDictionaryString(dic);
            // Debug.WriteLine(Getstr);
            //string encuodeurl=  HttpUtility.UrlEncode(Getstr);
            //Debug.WriteLine(encuodeurl);
            HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(Getstr));
            //设置请求方式GET POST
            request.Method = "GET";
            //if (request.Headers == null)
            //{
            //    request.Headers = new WebHeaderCollection();
            //}
            //request.Headers[HttpRequestHeader.IfModifiedSince] = DateTime.UtcNow.ToString();
            Debug.WriteLine(Getstr);
            //返回应答请求异步操作的状态
            request.BeginGetResponse((ar) => {
                try
                {
                    HttpWebRequest request2 = (HttpWebRequest)ar.AsyncState;
                    //结束对 Internet 资源的异步请求
                    HttpWebResponse response2 = (HttpWebResponse)request2.EndGetResponse(ar);
                    //解析应答头
                    //parseRecvHeader(response.Headers);
                    //获取请求体信息长度
                    long contentLength2 = response2.ContentLength;

                    //获取应答码
                    int statusCode2 = (int)response2.StatusCode;
                    string str2 = response2.ContentType;
                    string statusText2 = response2.StatusDescription;
                    Stream stream = response2.GetResponseStream();
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

                        //XName xurl = XName.Get("url");
                        //XName xname = XName.Get("name");
                        //  items.Add(new Info() { text = b.Descendants(xname).First().Value, dataurl = b.Descendants(xurl).First().Value });
                    }
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        favouratelstbox.ItemsSource = itemnodes;
                    });
                    //应答头信息验证
                    //using (StreamReader reader = new StreamReader(response2.GetResponseStream()))
                    //{
                    //}
                }
                catch
                {

                }
            }, request);
        }

        private void responseCallbacky(IAsyncResult ar)
        {
            try
            {
                HttpWebRequest request2 = (HttpWebRequest)ar.AsyncState;
                //结束对 Internet 资源的异步请求
                HttpWebResponse response2 = (HttpWebResponse)request2.EndGetResponse(ar);
                //解析应答头
                //parseRecvHeader(response.Headers);
                //获取请求体信息长度
                long contentLength2 = response2.ContentLength;

                //获取应答码
                int statusCode2 = (int)response2.StatusCode;
                string str2 = response2.ContentType;
                string statusText2 = response2.StatusDescription;
                Stream stream = response2.GetResponseStream();
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
                   
                    //XName xurl = XName.Get("url");
                    //XName xname = XName.Get("name");
                  //  items.Add(new Info() { text = b.Descendants(xname).First().Value, dataurl = b.Descendants(xurl).First().Value });
                }
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                                  favouratelstbox.ItemsSource=itemnodes;
                });
                //应答头信息验证
                using (StreamReader reader = new StreamReader(response2.GetResponseStream()))
                {
                }
            }
            catch
            {

            }
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

                MessageBox.Show("连接服务器错误");
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
        DateTime slectedtime;

        private void mediaelent_MediaEnded(object sender, RoutedEventArgs e)
        {
            try
            {
                videoindex = videoindex + 1;
                if (videoindex < 6)
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
                   
                    slectedtime = e.NewDateTime.Value;
                    if (slectedtime > DateTime.Parse("2015/04/09") && slectedtime < DateTime.Parse("2015/06/03"))
                    {
                        videourl = "http://v.cctv.com/flash/mp4video41/TMS/";
                    }
                    else if (slectedtime > DateTime.Parse("2015/06/03"))
                    {
                        videourl = "http://v.cctv.com/flash/mp4video43/TMS/";
                    }

                    else
                    {
                        videourl = "http://v.cctv.com/flash/mp4video40/TMS/";
                    }
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
//            mediaelent.Stop();
            TitlePanel.Visibility =Visibility.Collapsed;
        }

        private void SendzanBar_Click(object sender, EventArgs e)
        {
            WebBrowserTask webtask = new WebBrowserTask();
            webtask.Uri = mediaelent.Source;
            webtask.Show();

            //requesturl = lmstr + rquestdate + requestformat;
            //todayclient.OpenReadAsync(new Uri(lmstr, UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
         XElement  element=   btn.DataContext as XElement;
         MarketplaceDetailTask detial = new MarketplaceDetailTask() { ContentIdentifier = element.LastAttribute.Value };

                detial.Show();
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