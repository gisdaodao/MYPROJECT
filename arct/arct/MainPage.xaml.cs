using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using arct.Resources;
using System.Diagnostics;

namespace arct
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        Dictionary<string, string> datedic = new Dictionary<string, string>();
        List<Helperinfo> phelperinfolist = new List<Helperinfo>();
        List<string> HPBkind = new List<string>();
        List<string> antiearrhquakekindlist = new List<string>();
        List<string> shanggonglist = new List<string>();
        //List<string> HPBkind = new List<string>();
        string[] hpnbkindarrary = new string[4] { "HPB300", "HRB335、HRBF335", "HRB400、HRBF400、RRB400", "HRB500、HRBF500" };
        string[] antiearrhquakekindarrary = new string[4] { "一、二级（labE）", "三级（labE）", "四级（labE）", "非抗震（lab）" };
        string[] shanggongrrary = new string[9] { "C20", "C25", "C30", "C35", "C40", "C45", "C50", "C55", "≥C60" };
        string[] steelkindarrary = new string[15] { "φ6", "φ8", "φ10", "φ12", "φ14", "φ16", "φ18", "φ20", "φ22", "φ25", "φ28", "φ30", "φ32", "φ38", "φ40" };
        string[] percentarrary = new string[3] { "≤25=1.2", "50=1.4", "100=1.6" };
        string[] paramarrary = new string[1] { "37d=1.110" };
        public MainPage()
        {
            InitializeComponent();
            HPBkind.AddRange(hpnbkindarrary);
            antiearrhquakekindlist.AddRange(antiearrhquakekindarrary);
            shanggonglist.AddRange(shanggongrrary);
            listpickerhpbkind.ItemsSource = HPBkind;
            listpickerhantiearthquake.ItemsSource = antiearrhquakekindlist;
            listpickershanggong.ItemsSource = shanggonglist;
            listpickerhsteelkind.ItemsSource = steelkindarrary;
            listpickerhpercent.ItemsSource = percentarrary;
            listpickerparam.ItemsSource = paramarrary;
            datedic.Add("HPB300一、二级（labE）C20", "45d");
            datedic.Add("HPB300一、二级（labE）C25", "39d");
            datedic.Add("HPB300一、二级（labE）C30", "35d");
            datedic.Add("HPB300一、二级（labE）C35", "32d");
            datedic.Add("HPB300一、二级（labE）C40", "29d");
            datedic.Add("HPB300一、二级（labE）C45", "28d");
            datedic.Add("HPB300一、二级（labE）C50", "26d");
            datedic.Add("HPB300一、二级（labE）C55", "25d");
            datedic.Add("HPB300一、二级（labE）≥C60", "24d");
            datedic.Add("HPB300三级（labE）C20", "41d");
            datedic.Add("HPB300三级（labE）C25", "36d");
            datedic.Add("HPB300三级（labE）C30", "32d");
            datedic.Add("HPB300三级（labE）C35", "29d");
            datedic.Add("HPB300三级（labE）C40", "26d");
            datedic.Add("HPB300三级（labE）C45", "25d");
            datedic.Add("HPB300三级（labE）C50", "24d");
            datedic.Add("HPB300三级（labE）C55", "23d");
            datedic.Add("HPB300三级（labE）≥C60", "22d");
            datedic.Add("HPB300四级（labE）C20", "39d");
            datedic.Add("HPB300四级（labE）C25", "34d");
            datedic.Add("HPB300四级（labE）C30", "30d");
            datedic.Add("HPB300四级（labE）C35", "28d");
            datedic.Add("HPB300四级（labE）C40", "25d");
            datedic.Add("HPB300四级（labE）C45", "24d");
            datedic.Add("HPB300四级（labE）C50", "23d");
            datedic.Add("HPB300四级（labE）C55", "22d");
            datedic.Add("HPB300四级（labE）≥C60", "24d");
            datedic.Add("HPB300非抗震（lab）C20", "39d");
            datedic.Add("HPB300非抗震（lab）C25", "34d");
            datedic.Add("HPB300非抗震（lab）C30", "30d");
            datedic.Add("HPB300非抗震（lab）C35", "28d");
            datedic.Add("HPB300非抗震（lab）C40", "25d");
            datedic.Add("HPB300非抗震（lab）C45", "24d");
            datedic.Add("HPB300非抗震（lab）C50", "23d");
            datedic.Add("HPB300非抗震（lab）C55", "22d");
            datedic.Add("HPB300非抗震（lab）≥C60", "21d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C20", "44d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C25", "38d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C30", "33d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C35", "31d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C40", "29d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C45", "26d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C50", "25d");
            datedic.Add("HRB335、HRBF335一、二级（labE）C55", "24d");
            datedic.Add("HRB335、HRBF335一、二级（labE）≥C60", "24d");
            datedic.Add("HRB335、HRBF335三级（labE）C20", "40d");
            datedic.Add("HRB335、HRBF335三级（labE）C25", "35d");
            datedic.Add("HRB335、HRBF335三级（labE）C30", "31d");
            datedic.Add("HRB335、HRBF335三级（labE）C35", "28d");
            datedic.Add("HRB335、HRBF335三级（labE）C40", "26d");
            datedic.Add("HRB335、HRBF335三级（labE）C45", "24d");
            datedic.Add("HRB335、HRBF335三级（labE）C50", "23d");
            datedic.Add("HRB335、HRBF335三级（labE）C55", "22d");
            datedic.Add("HRB335、HRBF335三级（labE）≥C60", "22d");
            datedic.Add("HRB335、HRBF335四级（labE）C20", "38d");
            datedic.Add("HRB335、HRBF335四级（labE）C25", "33d");
            datedic.Add("HRB335、HRBF335四级（labE）C30", "29d");
            datedic.Add("HRB335、HRBF335四级（labE）C35", "27d");
            datedic.Add("HRB335、HRBF335四级（labE）C40", "25d");
            datedic.Add("HRB335、HRBF335四级（labE）C45", "23d");
            datedic.Add("HRB335、HRBF335四级（labE）C50", "22d");
            datedic.Add("HRB335、HRBF335四级（labE）C55", "21d");
            datedic.Add("HRB335、HRBF335四级（labE）≥C60", "21d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C20", "38d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C25", "33d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C30", "29d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C35", "27d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C40", "25d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C45", "23d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C50", "22d");
            datedic.Add("HRB335、HRBF335非抗震（lab）C55", "21d");
            datedic.Add("HRB335、HRBF335非抗震（lab）≥C60", "21d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C20", "-");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C25", "46d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C30", "40d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C35", "37d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C40", "33d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C45", "32d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C50", "31d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）C55", "30d");
            datedic.Add("HRB400、HRBF400、RRB400一、二级（labE）≥C60", "29d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C20", "-");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C25", "42d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C30", "37d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C35", "34d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C40", "30d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C45", "29d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C50", "28d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）C55", "27d");
            datedic.Add("HRB400、HRBF400、RRB400三级（labE）≥C60", "26d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C20", "-");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C25", "40d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C30", "35d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C35", "32d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C40", "29d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C45", "28d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C50", "27d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）C55", "26d");
            datedic.Add("HRB400、HRBF400、RRB400四级（labE）≥C60", "25d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C20", "-");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C25", "40d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C30", "35d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C35", "32d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C40", "29d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C45", "28d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C50", "27d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）C55", "26d");
            datedic.Add("HRB400、HRBF400、RRB400非抗震（lab）≥C60", "25");
            datedic.Add("HRB500、HRBF500一、二级（labE）C20", "-");
            datedic.Add("HRB500、HRBF500一、二级（labE）C25","55d");
            datedic.Add("HRB500、HRBF500一、二级（labE）C30","49d");
            datedic.Add("HRB500、HRBF500一、二级（labE）C35","45d");
            datedic.Add("HRB500、HRBF500一、二级（labE）C40","41d");
            datedic.Add("HRB500、HRBF500一、二级（labE）C45","39d");
            datedic.Add("HRB500、HRBF500一、二级（labE）C50","37d");
            datedic.Add("HRB500、HRBF500一、二级（labE）C55","36d");
            datedic.Add("HRB500、HRBF500一、二级（labE）≥C60", "35d");
            datedic.Add("HRB500、HRBF500三级（labE）C20", "-");
            datedic.Add("HRB500、HRBF500三级（labE）C25", "50d");
            datedic.Add("HRB500、HRBF500三级（labE）C30", "45d");
            datedic.Add("HRB500、HRBF500三级（labE）C35", "41d");
            datedic.Add("HRB500、HRBF500三级（labE）C40", "38d");
            datedic.Add("HRB500、HRBF500三级（labE）C45", "36d");
            datedic.Add("HRB500、HRBF500三级（labE）C50", "34d");
            datedic.Add("HRB500、HRBF500三级（labE）C55", "33d");
            datedic.Add("HRB500、HRBF500三级（labE）≥C60", "32d");
            datedic.Add("HRB500、HRBF500四级（labE）C20", "-");
            datedic.Add("HRB500、HRBF500四级（labE）C25", "48d");
            datedic.Add("HRB500、HRBF500四级（labE）C30", "43d");
            datedic.Add("HRB500、HRBF500四级（labE）C35", "39d");
            datedic.Add("HRB500、HRBF500四级（labE）C40", "36d");
            datedic.Add("HRB500、HRBF500四级（labE）C45", "34d");
            datedic.Add("HRB500、HRBF500四级（labE）C50", "32d");
            datedic.Add("HRB500、HRBF500四级（labE）C55", "31d");
            datedic.Add("HRB500、HRBF500四级（labE）≥C60", "30d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C20", "-");
            datedic.Add("HRB500、HRBF500非抗震（lab）C25", "48d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C30", "43d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C35", "39d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C40", "36d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C45", "34d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C50", "32d");
            datedic.Add("HRB500、HRBF500非抗震（lab）C55", "31d");
            datedic.Add("HRB500、HRBF500非抗震（lab）≥C60", "30d");
            getdata();
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }
        private void getdata()
        {
            foreach(string a in HPBkind)
            {
                foreach(string b in antiearrhquakekindlist)
                {
                    foreach(string c in shanggonglist)
                    {
                        Helperinfo onehelpinfo = new Helperinfo();
                        string tempstr = a + b + c;
                        onehelpinfo.contition = tempstr;
                        phelperinfolist.Add(onehelpinfo);
                      //  datedic.Add(tempstr,"d");
                        Debug.WriteLine("datedic.Add(" + "\"" + tempstr + "\"" + "," + "\"d\"" + ")"+";");
                       // Debug.WriteLine(tempstr);
                    }
                }
            }
        }
        public class Helperinfo
        {
         public   string contition {get;set;}
               public   string result {get;set;}
        }

        private void listpickerhpbkind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            caculate();
        }

        private void listpickerhantiearthquake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            caculate();
        }

        private void listpickerhsteelkind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            caculate();
        }

        private void listpickershanggong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            caculate();
        }
        string sumstr = string.Empty;
        private void caculate()
        {
            if (listpickerhantiearthquake.SelectedItem == null) return;
            if (listpickershanggong.SelectedItem == null) return;
            if (listpickershanggong.SelectedItem == null) return;
            if (listpickerhsteelkind.SelectedItem == null) return;
            if (listpickerhpercent.SelectedItem == null) return;
        sumstr=     listpickerhpbkind.SelectedItem.ToString() + listpickerhantiearthquake.SelectedItem.ToString() + listpickershanggong.SelectedItem.ToString();
        Debug.WriteLine(sumstr);
           if(datedic.Keys.Contains(sumstr))
           {
               string zhijingstr = datedic[sumstr];
               Debug.WriteLine(zhijingstr);
               if(zhijingstr.Length>2)
               {
                   int zhijingint = int.Parse(zhijingstr.Substring(0, 2));
              int steelguige=    int.Parse(listpickerhsteelkind.SelectedItem.ToString().Substring(1));
              double tempresult = zhijingint * steelguige;
              shoulabox.Text = (tempresult/1000).ToString();
                   if(listpickerhpercent.SelectedIndex==0)
                   {
                       zongxiangshoula.Text = ((zhijingint * steelguige * 1.2)/1000).ToString();
                   }
                   if (listpickerhpercent.SelectedIndex == 1)
                   {
                       zongxiangshoula.Text = ((zhijingint * steelguige * 1.4)/1000).ToString();
                   }
                   if (listpickerhpercent.SelectedIndex == 2)
                   {
                       zongxiangshoula.Text = ((zhijingint * steelguige * 1.6)/1000).ToString();
                   }

                  
               }
               else
               {

               }
           }
        }

        private void listpickerhpercent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            caculate();
        }

        private void btn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PicPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PicPage.xaml", UriKind.RelativeOrAbsolute));
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