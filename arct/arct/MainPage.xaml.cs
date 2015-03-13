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
        double kangzhen = 1;
        //List<string> HPBkind = new List<string>();
        string[] hpnbkindarrary = new string[4] { "HPB300", "HRB335 HRBF335", "HRB400 HRBF400 RRB400", "HRB500 HRBF500" };
        string[] antiearrhquakekindarrary = new string[4] { "一 二级（LABE）", "三级（LABE）", "四级（LABE）", "非抗震（LAB）" };
        string[] shanggongrrary = new string[9] { "C20", "C25", "C30", "C35", "C40", "C45", "C50", "C55", "≥C60" };
        string[] steelkindarrary = new string[15] { "Ф6", "Ф8", "Ф10", "Ф12", "Ф14", "Ф16", "Ф18", "Ф20", "Ф22", "Ф25", "Ф28", "Ф30", "Ф32", "Ф38", "Ф40" };
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
            datedic.Add("HPB300一 二级（LABE）C20", "45D");
            datedic.Add("HPB300一 二级（LABE）C25", "39D");
            datedic.Add("HPB300一 二级（LABE）C30", "35D");
            datedic.Add("HPB300一 二级（LABE）C35", "32D");
            datedic.Add("HPB300一 二级（LABE）C40", "29D");
            datedic.Add("HPB300一 二级（LABE）C45", "28D");
            datedic.Add("HPB300一 二级（LABE）C50", "26D");
            datedic.Add("HPB300一 二级（LABE）C55", "25D");
            datedic.Add("HPB300一 二级（LABE）≥C60", "24D");
            datedic.Add("HPB300三级（LABE）C20", "41D");
            datedic.Add("HPB300三级（LABE）C25", "36D");
            datedic.Add("HPB300三级（LABE）C30", "32D");
            datedic.Add("HPB300三级（LABE）C35", "29D");
            datedic.Add("HPB300三级（LABE）C40", "26D");
            datedic.Add("HPB300三级（LABE）C45", "25D");
            datedic.Add("HPB300三级（LABE）C50", "24D");
            datedic.Add("HPB300三级（LABE）C55", "23D");
            datedic.Add("HPB300三级（LABE）≥C60", "22D");
            datedic.Add("HPB300四级（LABE）C20", "39D");
            datedic.Add("HPB300四级（LABE）C25", "34D");
            datedic.Add("HPB300四级（LABE）C30", "30D");
            datedic.Add("HPB300四级（LABE）C35", "28D");
            datedic.Add("HPB300四级（LABE）C40", "25D");
            datedic.Add("HPB300四级（LABE）C45", "24D");
            datedic.Add("HPB300四级（LABE）C50", "23D");
            datedic.Add("HPB300四级（LABE）C55", "22D");
            datedic.Add("HPB300四级（LABE）≥C60", "24D");
            datedic.Add("HPB300非抗震（LAB）C20", "39D");
            datedic.Add("HPB300非抗震（LAB）C25", "34D");
            datedic.Add("HPB300非抗震（LAB）C30", "30D");
            datedic.Add("HPB300非抗震（LAB）C35", "28D");
            datedic.Add("HPB300非抗震（LAB）C40", "25D");
            datedic.Add("HPB300非抗震（LAB）C45", "24D");
            datedic.Add("HPB300非抗震（LAB）C50", "23D");
            datedic.Add("HPB300非抗震（LAB）C55", "22D");
            datedic.Add("HPB300非抗震（LAB）≥C60", "21D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C20", "44D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C25", "38D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C30", "33D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C35", "31D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C40", "29D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C45", "26D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C50", "25D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）C55", "24D");
            datedic.Add("HRB335 HRBF335一 二级（LABE）≥C60", "24D");
            datedic.Add("HRB335 HRBF335三级（LABE）C20", "40D");
            datedic.Add("HRB335 HRBF335三级（LABE）C25", "35D");
            datedic.Add("HRB335 HRBF335三级（LABE）C30", "31D");
            datedic.Add("HRB335 HRBF335三级（LABE）C35", "28D");
            datedic.Add("HRB335 HRBF335三级（LABE）C40", "26D");
            datedic.Add("HRB335 HRBF335三级（LABE）C45", "24D");
            datedic.Add("HRB335 HRBF335三级（LABE）C50", "23D");
            datedic.Add("HRB335 HRBF335三级（LABE）C55", "22D");
            datedic.Add("HRB335 HRBF335三级（LABE）≥C60", "22D");
            datedic.Add("HRB335 HRBF335四级（LABE）C20", "38D");
            datedic.Add("HRB335 HRBF335四级（LABE）C25", "33D");
            datedic.Add("HRB335 HRBF335四级（LABE）C30", "29D");
            datedic.Add("HRB335 HRBF335四级（LABE）C35", "27D");
            datedic.Add("HRB335 HRBF335四级（LABE）C40", "25D");
            datedic.Add("HRB335 HRBF335四级（LABE）C45", "23D");
            datedic.Add("HRB335 HRBF335四级（LABE）C50", "22D");
            datedic.Add("HRB335 HRBF335四级（LABE）C55", "21D");
            datedic.Add("HRB335 HRBF335四级（LABE）≥C60", "21D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C20", "38D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C25", "33D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C30", "29D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C35", "27D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C40", "25D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C45", "23D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C50", "22D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）C55", "21D");
            datedic.Add("HRB335 HRBF335非抗震（LAB）≥C60", "21D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C20", "-");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C25", "46D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C30", "40D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C35", "37D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C40", "33D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C45", "32D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C50", "31D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）C55", "30D");
            datedic.Add("HRB400 HRBF400 RRB400一 二级（LABE）≥C60", "29D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C20", "-");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C25", "42D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C30", "37D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C35", "34D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C40", "30D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C45", "29D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C50", "28D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）C55", "27D");
            datedic.Add("HRB400 HRBF400 RRB400三级（LABE）≥C60", "26D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C20", "-");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C25", "40D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C30", "35D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C35", "32D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C40", "29D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C45", "28D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C50", "27D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）C55", "26D");
            datedic.Add("HRB400 HRBF400 RRB400四级（LABE）≥C60", "25D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C20", "-");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C25", "40D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C30", "35D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C35", "32D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C40", "29D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C45", "28D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C50", "27D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）C55", "26D");
            datedic.Add("HRB400 HRBF400 RRB400非抗震（LAB）≥C60", "25D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C20", "-");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C25","55D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C30","49D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C35","45D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C40","41D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C45","39D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C50","37D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）C55","36D");
            datedic.Add("HRB500 HRBF500一 二级（LABE）≥C60", "35D");
            datedic.Add("HRB500 HRBF500三级（LABE）C20", "-");
            datedic.Add("HRB500 HRBF500三级（LABE）C25", "50D");
            datedic.Add("HRB500 HRBF500三级（LABE）C30", "45D");
            datedic.Add("HRB500 HRBF500三级（LABE）C35", "41D");
            datedic.Add("HRB500 HRBF500三级（LABE）C40", "38D");
            datedic.Add("HRB500 HRBF500三级（LABE）C45", "36D");
            datedic.Add("HRB500 HRBF500三级（LABE）C50", "34D");
            datedic.Add("HRB500 HRBF500三级（LABE）C55", "33D");
            datedic.Add("HRB500 HRBF500三级（LABE）≥C60", "32D");
            datedic.Add("HRB500 HRBF500四级（LABE）C20", "-");
            datedic.Add("HRB500 HRBF500四级（LABE）C25", "48D");
            datedic.Add("HRB500 HRBF500四级（LABE）C30", "43D");
            datedic.Add("HRB500 HRBF500四级（LABE）C35", "39D");
            datedic.Add("HRB500 HRBF500四级（LABE）C40", "36D");
            datedic.Add("HRB500 HRBF500四级（LABE）C45", "34D");
            datedic.Add("HRB500 HRBF500四级（LABE）C50", "32D");
            datedic.Add("HRB500 HRBF500四级（LABE）C55", "31D");
            datedic.Add("HRB500 HRBF500四级（LABE）≥C60", "30D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C20", "-");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C25", "48D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C30", "43D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C35", "39D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C40", "36D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C45", "34D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C50", "32D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）C55", "31D");
            datedic.Add("HRB500 HRBF500非抗震（LAB）≥C60", "30D");
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
                      //  datedic.Add(tempstr,"D");
                        Debug.WriteLine("datedic.Add(" + "\"" + tempstr + "\"" + "," + "\"D\"" + ")"+";");
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
            if (listpickerhantiearthquake.SelectedIndex==0)
            {
                kangzhen = 1.15;
            }
            if (listpickerhantiearthquake.SelectedIndex == 1)
            {
                kangzhen = 1.05;
            }
            if (listpickerhantiearthquake.SelectedIndex == 2)
            {
                kangzhen = 1.0;
            }
            if (listpickerhantiearthquake.SelectedIndex == 3)
            {
                kangzhen = 1.0;
            }
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
                if (datedic.Keys.Contains(sumstr))
                {
                    string zhijingstr = datedic[sumstr];
                    Debug.WriteLine(zhijingstr);
                    if (zhijingstr.Length > 2)
                    {
                        int zhijingint = int.Parse(zhijingstr.Substring(0, 2));
                        int steelguige = int.Parse(listpickerhsteelkind.SelectedItem.ToString().Substring(1));
                        if (steelguige> 25)
                        {
                         
                            double tempresult = zhijingint * steelguige ;
                            basickinputbox.Text = zhijingstr + "×" + (int.Parse(listpickerhsteelkind.SelectedItem.ToString().Substring(1)) / 1000.0).ToString() +  "=" + (tempresult / 1000).ToString();
                            double tempkangzhenresult = tempresult * kangzhen;
                            if (tempkangzhenresult < 200)
                            {
                                shoulabox.Text = ((200 )/ 1000.0).ToString();
                                jisuanshoulabox.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString();
                                if (listpickerhpercent.SelectedIndex == 0)
                                {
                                   if(steelguige>25)
                                   {
                                       zongxiangshoula.Text = ((0.2 * 1.2 * 1.1)).ToString();
                                       jisuanzongxiangshoula.Text = "0.2 * 1.2 * 1.1";
                                   }
                                   else
                                   {
                                       zongxiangshoula.Text = ((0.2 * 1.2 )).ToString();
                                       jisuanzongxiangshoula.Text = "0.2 * 1.2 ";
                                   }
                                   
                                }
                                if (listpickerhpercent.SelectedIndex == 1)
                                {
                                    if (steelguige > 25)
                                    {
                                        zongxiangshoula.Text = ((0.2 * 1.4 * 1.1)).ToString();
                                        jisuanzongxiangshoula.Text = "0.2 * 1.4 * 1.1";
                                    }
                                    else
                                    {
                                        zongxiangshoula.Text = ((0.2 * 1.4)).ToString();
                                        jisuanzongxiangshoula.Text = "0.2 * 1.4";
                                    }
                                }
                                if (listpickerhpercent.SelectedIndex == 2)
                                {
                                    if (steelguige > 25)
                                    {
                                        zongxiangshoula.Text = ((0.2 * 1.6 * 1.1)).ToString();
                                        jisuanzongxiangshoula.Text = "0.2 * 1.6 * 1.1";
                                    }
                                    else
                                    {
                                        zongxiangshoula.Text = ((0.2 * 1.6)).ToString();
                                        jisuanzongxiangshoula.Text = "0.2 * 1.6";
                                    }
                                }
                            }
                            else
                            {
                                shoulabox.Text = ((tempkangzhenresult) / 1000.0).ToString();
                                jisuanshoulabox.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString();
                                if (listpickerhpercent.SelectedIndex == 0)
                                {
                                    if (steelguige > 25)
                                    {
                                        zongxiangshoula.Text = ((tempkangzhenresult * 1.2 * 1.1) / 1000).ToString();
                                        jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.2×1.1";
                                    }
                                    else
                                    {
                                        zongxiangshoula.Text = ((tempkangzhenresult * 1.2 ) / 1000).ToString();
                                        jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.2";
                                    }
                                }
                                if (listpickerhpercent.SelectedIndex == 1)
                                {
                                    if (steelguige > 25)
                                    {
                                        zongxiangshoula.Text = ((tempkangzhenresult * 1.4 * 1.1) / 1000).ToString();
                                        jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.4×1.1";
                                    }
                                    else
                                    {
                                        zongxiangshoula.Text = ((tempkangzhenresult * 1.4 ) / 1000).ToString();
                                        jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.4";
                                    }
                                }
                                if (listpickerhpercent.SelectedIndex == 2 )
                                {
                                    if (steelguige > 25)
                                    {
                                        zongxiangshoula.Text = ((tempkangzhenresult * 1.6 * 1.1) / 1000).ToString();
                                        jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.6×1.1";
                                    }
                                    else
                                    {
                                        zongxiangshoula.Text = ((tempkangzhenresult * 1.6) / 1000).ToString();
                                        jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.6";
                                    }
                                }
                            }
                        }
                        else
                        {
                           
                            double tempresult = zhijingint * steelguige;
                            double tempkangzhenresult = tempresult * kangzhen;
                            basickinputbox.Text = zhijingstr + "×" + (int.Parse(listpickerhsteelkind.SelectedItem.ToString().Substring(1)) / 1000.0).ToString() + "=" + (tempresult / 1000).ToString();
                            if (tempkangzhenresult < 200)
                            {
                                shoulabox.Text = ((200) / 1000.0).ToString();
                                jisuanshoulabox.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString();
                                if (listpickerhpercent.SelectedIndex == 0)
                                {
                                    zongxiangshoula.Text = ((0.2 * 1.2 )).ToString();
                                    jisuanzongxiangshoula.Text = "0.2 * 1.2";
                                }
                                if (listpickerhpercent.SelectedIndex == 1)
                                {
                                    zongxiangshoula.Text = ((0.2 * 1.4 )).ToString();
                                    jisuanzongxiangshoula.Text = "0.2 * 1.4";
                                }
                                if (listpickerhpercent.SelectedIndex == 2)
                                {
                                    zongxiangshoula.Text = ((0.2 * 1.6 )).ToString();
                                    jisuanzongxiangshoula.Text = "0.2 * 1.6 ";
                                }
                            }
                            else
                            {
                                shoulabox.Text = ((tempkangzhenresult) / 1000.0).ToString();
                                jisuanshoulabox.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString();
                                if (listpickerhpercent.SelectedIndex == 0)
                                {
                                    zongxiangshoula.Text = ((tempkangzhenresult * 1.2) / 1000).ToString();
                                    jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.2";
                                }
                                if (listpickerhpercent.SelectedIndex == 1)
                                {
                                    zongxiangshoula.Text = ((tempkangzhenresult * 1.4) / 1000).ToString();
                                    jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige/1000.0).ToString() + "×" + kangzhen.ToString() + "×1.4";
                                }
                                if (listpickerhpercent.SelectedIndex == 2)
                                {
                                    zongxiangshoula.Text = ((tempkangzhenresult * 1.6) / 1000).ToString();
                                    jisuanzongxiangshoula.Text = zhijingint.ToString() + "D×" + (steelguige / 1000.0).ToString() + "×" + kangzhen.ToString() + "×1.6";
                                }
                            }
                        }
                       
                    }
                    else
                    {
                        if(zhijingstr=="-")
                        {
                            basickinputbox.Text = "0";
                            shoulabox.Text = "0.200";
                           
                            if (listpickerhpercent.SelectedIndex == 0)
                            {
                                zongxiangshoula.Text =  ((0.2 * 1.2)).ToString();
                            }
                            if (listpickerhpercent.SelectedIndex == 1)
                            {
                                zongxiangshoula.Text = ((0.2 * 1.4)).ToString();
                            }
                            if (listpickerhpercent.SelectedIndex == 2)
                            {
                                zongxiangshoula.Text = ((0.2* 1.6)).ToString();
                            }
                        }
                       
                    }
              
            }
            else
             {

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

        private void SendBar_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/aboutPage.xaml", UriKind.RelativeOrAbsolute));
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