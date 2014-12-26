using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _5ajingqu.Resources;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;
using System.Windows.Resources;
using System.Diagnostics;
using GoogleAds;
using System.Windows.Media;
using AppStudio.Data;
using System.Threading.Tasks;
using AppStudio;
using System.Collections.ObjectModel;
using System.Xml;
using System.Threading;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;



namespace _5ajingqu
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        private void OnAdReceived(object sender, AdEventArgs e)
        {
            Random p = new Random();
            int i = p.Next(0, 6);
            if(i>=5)
            {
                interstitialAd.ShowAd();
            }
        }

        private void OnFailedToReceiveAd(object sender, AdErrorEventArgs errorCode)
        {

        }
        public MainPage()
        {
            InitializeComponent();
            getdataandupdateui("Book1.csv", listselector);
            interstitialAd = new InterstitialAd("ca-app-pub-1598808565430684/7440342450");
            // NOTE: You can edit the event handler to do something custom here. Once the
            // interstitial is received it can be shown whenever you want.
            interstitialAd.ReceivedAd += OnAdReceived;

            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = false;
          interstitialAd.LoadAd(adRequest);
            if(!settings.Contains("guanggao"))
            {
                settings.Add("guanggao", 0);
            }
            else
            {
                int i = (int)settings["guanggao"];
                if(i>=1)
                {
                    sethide();
                }
            }
          
        }
        private void sethide()
        {
            tb.Visibility = Visibility.Collapsed;
            btn.Visibility = Visibility.Collapsed;
            ad1.Visibility = Visibility.Collapsed;
            ad.Children.Remove(AdControl22);
        }
     private InterstitialAd interstitialAd;
 

        
        private async void Panorama_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Panorama obj = sender as Panorama;
            if (obj.SelectedIndex == 1)
            {
                getdataandupdateui("aaaa1.csv", listselector2);
            }
            if (obj.SelectedIndex == 3)
            {
               // DataSource1DataSource p = new DataSource1DataSource();
               // var records = await p.LoadData();
                wb.Navigate(new Uri("http://m.lotour.com/index.aspx", UriKind.RelativeOrAbsolute));
               //travelpanorama.ItemsSource= new ObservableCollection<RssSchema>(records);
                WebClient webClient = new WebClient();
              //  webClient.Headers.i("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
                webClient.AllowReadStreamBuffering = true;
                //webClient.UseDefaultCredentials = true;
                //webClient.OpenReadCompleted += webClient_OpenReadCompleted;
                //webClient.OpenReadAsync(new System.Uri("http://www.xinhuanet.com/travel/news_travel.xml", UriKind.Absolute));
                //// Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
                //webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
                //webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                //// Download the RSS feed. DownloadStringAsync was used instead of OpenStreamAsync because we do not need 
                //// to leave a stream open, and we will not need to worry about closing the channel. 
                //webClient.DownloadStringAsync(new System.Uri("http://www.xinhuanet.com/travel/news_travel.xml",UriKind.Absolute));
            } 
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
          
        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
           
        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                this.State["feed"] = e.Result;

                UpdateFeedList(e.Result);
            }
        }
        // This method sets up the feed and binds it to our ListBox. 
        private void UpdateFeedList(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance.
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
         ///   SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            // In Windows Phone OS 7.1 or later versions, WebClient events are raised on the same type of thread they were called upon. 
            // For example, if WebClient was run on a background thread, the event would be raised on the background thread. 
            // While WebClient can raise an event on the UI thread if called from the UI thread, a best practice is to always 
            // use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                // Bind the list of SyndicationItems to our ListBox.
               // feedListBox.ItemsSource = feed.Items;

              //  loadFeedButton.Content = "Refresh Feed";
            });
        }
        public void getdataandupdateui(string filename,LongListSelector objitem)
        {
           
            StreamResourceInfo resourceInfo = Application.GetResourceStream(new Uri(filename, UriKind.Relative));
            List<Place> ps = new List<Place>();
            using (StreamReader reader = new StreamReader(resourceInfo.Stream))
            {
                List<string> province = new List<string>();
                string oneprovince = string.Empty;
                List<string> jingdian = new List<string>();
                while (!reader.EndOfStream)
                {
                    Place one = new Place();
                    string pp = reader.ReadLine();
                    string[] oo = pp.Split(',');
                    if (oo[0] == string.Empty)
                    {
                        jingdian.Add(oo[2]);
                        if (oneprovince == "新疆" && reader.EndOfStream)
                        {
                            one.Province = oneprovince;
                            one.AddRange(jingdian);
                            ps.Add(one);
                            jingdian.Clear();
                        }
                    }
                    else
                    {
                       if (oo[0] == "省份") { continue; }
                        if (oneprovince != oo[0] && !string.IsNullOrEmpty(oneprovince))
                        {
                            one.Province = oneprovince;
                            one.AddRange(jingdian);
                            ps.Add(one);
                            jingdian.Clear();
                        }
                        oneprovince = oo[0];
                        jingdian.Add(oo[2]);
                    }
                }
                reader.Close();
                objitem.ItemsSource = ps;
            }
        }

        private void Grid_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = e.OriginalSource as TextBlock;
            //interstitialAd.ShowAd();
            if (tb != null)
            {
                if (tb.Text == "北京")
                {
                    this.NavigationService.Navigate(new Uri("/citydetail.xaml?key=beijing", UriKind.Relative));
                }
                else
                {
                    this.NavigationService.Navigate(new Uri("/citydetail.xaml?key=shanghai", UriKind.Relative));
                }
            }
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
         //  interstitialAd.ShowAd();
            this.NavigationService.Navigate(new Uri("/controy.xaml", UriKind.Relative));
        }

        private void travelpanorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(travelpanorama.SelectedItem!=null)
            //{
            //    PhoneApplicationService.Current.State["onenew"] = travelpanorama.SelectedItem as RssSchema;  
            //    this.NavigationService.Navigate(new Uri("/NewsDetailPage.xaml", UriKind.Relative));
            //}
        }
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
           
        //    base.OnNavigatedTo(e);
        //}
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //interstitialAd.ShowAd();
            //Thread.Sleep(3000);
            base.OnBackKeyPress(e);
        }
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            if (panorama.SelectedIndex==1)
            {
                this.NavigationService.Navigate(new Uri("/jingqubaike.xaml?word=" + tb.Text.Split(' ')[1], UriKind.Relative));
                return;
                ;
            }
            this.NavigationService.Navigate(new Uri("/jingqubaike.xaml?word=" + tb.Text, UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask p = new MarketplaceReviewTask(); p.Show();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                if (e.IsNavigationInitiator == false && e.NavigationMode == NavigationMode.Back)
                {

                    int i = 1;
                    if (!settings.Contains("guanggao"))
                    {
                        settings.Add("guanggao", i);
                        settings.Save();
                    }
                    else
                    {
                        int k = (int)settings["guanggao"];
                        k = k + i;
                        settings["guanggao"] = k;
                        settings.Save();
                        sethide();
                    }



                }
                if (e.NavigationMode == NavigationMode.New)
                {
                    if (!settings.Contains("guanggao"))
                    {
                        settings.Add("guanggao", 0);
                        settings.Save();
                    }
                    else
                    {
                        int k = (int)settings["guanggao"];
                        if (k >= 1)
                        {
                            sethide();
                        }
                        //k = k + i;
                        //settings["guanggao"] = k;
                        // settings.Save();
                    }



                }
               
                base.OnNavigatedTo(e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //this.surfaceAdImageXaml.InitAdControl(AdModeType.Normal);
            // this.surfaceAdImageXaml.InitAdControl(AdModeType.Debug); 
        }
    
    }  
    public class Place : List<string>
    {
        public string Province { get; set; }
        public int count { get; set; }
    }
    public class DataSource1DataSource : IDataSource<RssSchema>
    {
        private const string _url = @"http://www.xinhuanet.com/travel/news_travel.xml";

        private IEnumerable<RssSchema> _data = null;

        public DataSource1DataSource()
        {
        }

        public async Task<IEnumerable<RssSchema>> LoadData()
        {
            if (_data == null)
            {
                try
                {
                    var rssDataProvider = new RssDataProvider(_url);
                    _data = await rssDataProvider.Load();
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("DataSource1DataSourceDataSource.LoadData", ex.ToString());
                }
            }
            return _data;
        }

        public async Task<IEnumerable<RssSchema>> Refresh()
        {
            _data = null;
            return await LoadData();
        }
    }
}