using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 股票新闻;
using System.Xml.Linq;
using System.IO;
using Windows.Phone.Speech.Synthesis;
using System.Text;

namespace gameuser
{
    public partial class txtPage : PhoneApplicationPage
    {
        public txtPage()
        {
            InitializeComponent();
         
            indicator.Text = "请求中...";
            indicator.IsVisible = true;
            indicator.IsIndeterminate = true;
        }
        string url = string.Empty;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                url = this.NavigationContext.QueryString["url"];
                Pclient.OpenReadCompleted += Pclient_OpenReadCompleted;
                Pclient.OpenReadAsync(new Uri(url, UriKind.Absolute));
                //urlname.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
                // CreateScreenAd();
            }
            //title.Text = App.tranferinfo.text;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            synth.CancelAll();
            //synth.
            base.OnNavigatedFrom(e);
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
                    StreamReader reader = new StreamReader(stream);
                  
                   while (!reader.EndOfStream)
                   {
                       string str = reader.ReadLine();
                       urls.Add(str);
                   }
                   stream.Close();
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        txtstringbox.ItemsSource = urls;
                        indicator.IsVisible = false;
                        indicator.IsIndeterminate = false;
                        //if (panorama.SelectedIndex == 0)
                        //{
                        //    lstbox.ItemsSource = items; indicator.IsVisible = false;
                        //    indicator.IsIndeterminate = false;
                        //}
                        //if (panorama.SelectedIndex == 2)
                        //{
                        //    otherlstbox.ItemsSource = otheritems; indicator.IsVisible = false;
                        //    indicator.IsIndeterminate = false;
                        //}

                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        SpeechSynthesizer synth = new SpeechSynthesizer();
        private async void Appbarread_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringb = new StringBuilder();
                foreach (var a in urls)
                {
                    stringb.AppendLine(a);
                }
                string str = stringb.ToString();
                if (string.IsNullOrEmpty(str)) return;
                await synth.SpeakTextAsync(str);
            }
            catch (Exception)
            {
                
             
            }
           

        }
    }
}