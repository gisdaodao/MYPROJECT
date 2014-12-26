using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Windows.Resources;
using GoogleAds;
using Microsoft.Phone.Tasks;
using System.Windows.Media;

namespace _5ajingqu
{
    public partial class controy : PhoneApplicationPage
    {
        List<string> ps = new List<string>();
        public controy()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            getdataandupdateui("guojia.csv", detailLongListSelector);
        }
        private void OnAdReceived(object sender, AdEventArgs e)
        {

        }

        private void OnFailedToReceiveAd(object sender, AdErrorEventArgs errorCode)
        {

        }
        private void listselector2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            LongListSelector senderobj = sender as LongListSelector;
            List<TextBlock> userControlList = new List<TextBlock>();
            ClassHelper.GetItemsRecursive<TextBlock>(senderobj, ref userControlList);
            // Selected. 
            if (e.AddedItems.Count > 0 && e.AddedItems[0] != null)
            {
                foreach (TextBlock userControl in userControlList)
                {
                    if (e.AddedItems[0].Equals(userControl.Text))
                    {
                        userControl.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
            }
            // Unselected. 
            if (e.RemovedItems.Count > 0 && e.RemovedItems[0] != null)
            {
                foreach (TextBlock userControl in userControlList)
                {
                    if (e.RemovedItems[0].Equals(userControl.DataContext))
                    {
                        userControl.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }

        }
        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            //detailLongListSelector. = true;

            if (detailLongListSelector.SelectedItem!=null)
            {
                   ShareStatusTask shareStatusTask = new ShareStatusTask();
             string sharetext = detailLongListSelector.SelectedItem.ToString();
             shareStatusTask.Status = sharetext;

             shareStatusTask.Show();
            }
        }
        public void getdataandupdateui(string filename, LongListSelector objitem)
        {
            StreamResourceInfo resourceInfo = Application.GetResourceStream(new Uri(filename, UriKind.Relative));
       
            using (StreamReader reader = new StreamReader(resourceInfo.Stream))
            {

                while (!reader.EndOfStream)
                {

                    string pp = reader.ReadLine();
                    ps.Add(pp);
                }
                reader.Close();
                objitem.ItemsSource = ps;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = txtbox.Text;
          var a=from one in ps 
                where one.Contains(str)
                select  one;
          if (a.Count() > 0)
          {
              detailLongListSelector.ItemsSource =a.ToList<string>();
          }
          else
          {
              detailLongListSelector.ItemsSource = new List<string>();
          }
        }
        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            
            if (detailLongListSelector.SelectedItem != null)
            {
                SmsComposeTask composeSMS = new SmsComposeTask();
                composeSMS.Body = detailLongListSelector.SelectedItem.ToString();

                //composeSMS.To = "15952003521";

                composeSMS.Show();
            }
           

        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            this.NavigationService.Navigate(new Uri("/jingqubaike.xaml?word=" + tb.Text, UriKind.Relative));
        }
    }
}