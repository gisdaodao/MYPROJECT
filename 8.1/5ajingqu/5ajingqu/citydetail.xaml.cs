using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Resources;
using System.IO;
using GoogleAds;
using Microsoft.Phone.Tasks;
using System.Windows.Media;

namespace _5ajingqu
{

    public class Placeinfo
    {
        public string name { get; set; }
        public string location { get; set; }
        public string rank { get; set; }
        public string downtown { get; set; }
    }
    public partial class citydetail : PhoneApplicationPage
    {
        public citydetail()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        string str=    this.NavigationContext.QueryString.Values.First();
        if (str == "beijing")
        {
            tbtitle.Text = "北京";
        }
        else
        {
            tbtitle.Text = "上海";
        }
        getdataandupdateui(str + ".csv", detailLongListSelector);
            base.OnNavigatedTo(e);
        }
      
        public void getdataandupdateui(string filename, LongListSelector objitem)
        {
            StreamResourceInfo resourceInfo = Application.GetResourceStream(new Uri(filename, UriKind.Relative));
            List<Placeinfo> ps = new List<Placeinfo>();
            using (StreamReader reader = new StreamReader(resourceInfo.Stream))
            {
               
                while (!reader.EndOfStream)
                {
                   
                    string pp = reader.ReadLine();
                    string[] oo = pp.Split(',');
                    if (oo.Length >= 4)
                    {
                        Placeinfo one = new Placeinfo() { downtown = oo[0], rank = oo[1], name = oo[2], location = oo[3] };
                        ps.Add(one);
                    }
                    else
                    {
                        Placeinfo one = new Placeinfo() { name = oo[0], location = oo[1] };
                        ps.Add(one);
                    }
                  
                }
                reader.Close();
                objitem.ItemsSource = ps;
            }
        }
        private void OnAdReceived(object sender, AdEventArgs e)
        {

        }
       
        private void OnFailedToReceiveAd(object sender, AdErrorEventArgs errorCode)
        {

        }
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            if (detailLongListSelector.SelectedItem != null)
            {
                ShareStatusTask shareStatusTask = new ShareStatusTask();
                string sharetext = detailLongListSelector.SelectedItem.ToString();
                shareStatusTask.Status = sharetext;

                shareStatusTask.Show();
            }
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel ST = sender as StackPanel;
            Placeinfo plcae = ST.DataContext as Placeinfo;
            this.NavigationService.Navigate(new Uri("/jingqubaike.xaml?word=" + plcae.name, UriKind.Relative));
        }
       
        }
   
}