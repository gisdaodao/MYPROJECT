using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using HtmlAgilityPack;
using 股票新闻;

namespace cctv
{
    public partial class seachPage : PhoneApplicationPage
    {
        public seachPage()
        {
            InitializeComponent();
            //p.OpenReadAsync(new Uri(api, UriKind.RelativeOrAbsolute));
            //p.OpenReadCompleted += p_OpenReadCompleted;
            p.DownloadStringAsync(new Uri(api, UriKind.RelativeOrAbsolute));
            p.DownloadStringCompleted += p_DownloadStringCompleted;
        }

        void p_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
        IEnumerable<HtmlAgilityPack.HtmlNode> ullist = null;
        void p_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
 if(e.Result!=null)
            {
                string str = e.Result;
                Debug.WriteLine(str);
                HtmlAgilityPack.HtmlDocument docmennt = new HtmlAgilityPack.HtmlDocument();
                docmennt.LoadHtml(str);
                ullist = docmennt.DocumentNode.Descendants("div");
                foreach (var a in ullist)
                {
                    if (a.HasAttributes && a.Attributes["class"] != null && a.Attributes["class"].Value == "seah_main bor_t")
                    {
                     HtmlAgilityPack.HtmlNode node = a;
                   
                     foreach (var li in node.Descendants("li"))
                        {
                           
                            HtmlNode anode = li.Descendants("a").First();
                            if (anode.HasAttributes && anode.Attributes["class"] != null && anode.Attributes["class"].Value == "list_rec_video")
                         {
                             var ataglist = li.Descendants("a");
                             var ptaglist = li.Descendants("p");
                             Info oneinfo = new Info();
                             if (anode.HasAttributes)
                             {
                                 string href = anode.Attributes["href"].Value;
                                 Debug.WriteLine(href);
                                 string[] resultsplitstr = href.Split('&');
                                 string videoid = resultsplitstr[1].Split('=')[1];
                                 DateTime dt = DateTime.Now;
                                 oneinfo.id = videoid;
                                 Debug.WriteLine(videoid + "videoid");
                                 oneinfo.videoid = videoid;
                                 //oneinfo.dataurl = href;
                                 HtmlNode img = anode.Descendants("img").First();
                                 oneinfo.picurl = img.Attributes["src"].Value;
                                 //oneinfo.text = img.Attributes["alt"].Value;
                                 //Debug.WriteLine(oneinfo.dataurl + oneinfo.picurl + oneinfo.text);
                             }
                             if (ataglist.Count() > 1)
                             {
                                 HtmlNode atextnode = ataglist.ElementAt(1);
                                 oneinfo.text = atextnode.InnerText;

                             }
                             if (ptaglist.Count() > 0)
                             {
                                 oneinfo.duration = ptaglist.First().InnerText;
                                 if (ptaglist.Count() > 0)
                                 {
                                     oneinfo.date = ptaglist.ElementAt(1).InnerText;
                                 }
                             }
                             plist.Add(oneinfo);

                             // return;
                         }
                            
                        }
                     lstbox.ItemsSource = plist;

                    }
                }
            }
            }
            catch (Exception)
            {
                
             
            }
         
          //  throw new NotImplementedException();
        }
        string api = "http://search.cctv.com/search.php?qtext=%E7%94%9F%E8%B4%A2%E6%9C%89%E9%81%93&redirect=1";
        WebClient p = new WebClient();
        List<Info> plist = new List<Info>();
        string videourl = "http://v.cctv.com/flash/mp4video40/TMS/";
        string datestr = string.Empty;
        string fileid = string.Empty;
        string commonstr = "_h264418000nero_aac32-";
        int videoindex = 1;
        string houzuistr = ".mp4";
        string fullpath = string.Empty;

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel st = sender as StackPanel;
            Info date = st.DataContext as Info;        
            int index = date.picurl.LastIndexOf('/');
            string datestr = date.picurl.Substring(index - 10, 11);
          //  DateTime.
            DateTime dt = DateTime.ParseExact(date.date, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture); ;
           // fileid = tempstr.Substring(intindex.ElementAt(2) + 1, intindex.ElementAt(3) - intindex.ElementAt(2) - 1);
            fullpath = videourl + datestr + date.id + commonstr + videoindex.ToString() + houzuistr;
           // string datestr = date.date;
            //fullpath = videourl + dt.Date.ToString("yyyy/MM/dd") + "/" + fileid + commonstr + videoindex.ToString() + houzuistr;
        }
    }
}