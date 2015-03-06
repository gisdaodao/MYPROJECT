using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using htmlalpgt.Resources;
using HtmlAgilityPack;
using 股票新闻;
using System.Diagnostics;
namespace htmlalpgt
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        string str = "http://edu.qq.com/l/photo/xbtp/tpxhxc/list20140312133211.htm";
        string changgehefashengstr = "http://www.youku.com/playlist_show/id_18972217.html?sf=10701";
        string mvchanggehefashengstr = "http://www.youku.com/playlist_show/id_18972217.html?sf=10701";
        string mchanggehefashengstr = "http://www.youku.com/playlist_show/id_18972217.html?sf=10701";
        WebClient pclient = new WebClient();
        WebClient changgehefashengclient = new WebClient();
        public MainPage()
        {
            InitializeComponent();
            HtmlAgilityPack.HtmlWeb p = new HtmlAgilityPack.HtmlWeb();
            pclient.Encoding = DBCSCodePage.DBCSEncoding.GetDBCSEncoding("gb2312");
            pclient.DownloadStringAsync(new Uri(str, UriKind.RelativeOrAbsolute));
            pclient.DownloadStringCompleted += pclient_DownloadStringCompleted;
           // p.LoadAsync(str,System.Text.UTF8Encoding.Unicode);
            p.LoadCompleted += p_LoadCompleted;
            changgehefashengclient.Encoding = System.Text.UTF8Encoding.UTF8;
            changgehefashengclient.DownloadStringAsync(new Uri(mvchanggehefashengstr, UriKind.RelativeOrAbsolute));
            changgehefashengclient.DownloadStringCompleted += changgehefashengclient_DownloadStringCompleted;
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }
        List<Info> youkuchanggejiqiao = new List<Info>();
        void changgehefashengclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            bool rebool;
            string reustlstr = e.Result;
            HtmlAgilityPack.HtmlDocument result = new HtmlDocument();
            result.LoadHtml(reustlstr);
            IEnumerable<HtmlNode> div = result.DocumentNode.Descendants("div").Where((aa, retask) =>
            {
                if (aa.HasAttributes && aa.Attributes["class"] != null && aa.Attributes["class"].Value == "items")
                { return true; }
                else
                {
                    return false;
                }
            });
            HtmlNode divnode = div.First();
            IEnumerable<HtmlNode> ulnodes = divnode.Descendants("ul");
            foreach(var a in ulnodes)
            {
                var anode = a.Descendants("a").First();
                Info oneinfo = new Info();
                oneinfo.dataurl = anode.Attributes["href"].Value;
                oneinfo.text = anode.Attributes["title"].Value;
                oneinfo.picurl = a.Descendants("img").First().Attributes["src"].Value;
                Debug.WriteLine(oneinfo.dataurl + oneinfo.text + oneinfo.picurl);
                youkuchanggejiqiao.Add(oneinfo);
            }
        }
        //腾讯校花堂解析
        void pclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string reustlstr = e.Result;
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
        List<Info> infolist = new List<Info>();
        IEnumerable<HtmlAgilityPack.HtmlNode> ullist = null;
        HtmlNode ulhtmlnode = null;
        void p_LoadCompleted(object sender, HtmlAgilityPack.HtmlDocumentLoadCompleted e)
        {
            HtmlAgilityPack.HtmlDocument result = e.Document;
            ullist = result.DocumentNode.Descendants("ul");
            foreach(var a in ullist)
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
                        oneinfo.picurl=    img.Attributes["src"].Value;
                        oneinfo.text = img.Attributes["alt"].Value;
                        Debug.WriteLine(oneinfo.dataurl+oneinfo.picurl+oneinfo.text);
                        }
                       // return;
                    }
                   
                }
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