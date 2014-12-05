using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GoogleAds;
using Microsoft.Phone.Tasks;
using SurfaceAd.SDK.WP;
using System.Windows.Media;

namespace 股票新闻
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            // 将 listbox 控件的数据上下文设置为示例数据
            interstitialAd = new InterstitialAd("ca-app-pub-1598808565430684/4760146055");
            // NOTE: You can edit the event handler to do something custom here. Once the
            // interstitial is received it can be shown whenever you want.
            interstitialAd.ReceivedAd += OnAdReceived;
           
            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = false;
            interstitialAd.LoadAd(adRequest);
    
        }
        private InterstitialAd interstitialAd;
        private void OnAdReceived(object sender, AdEventArgs e)
        {
            Random adrandeom = new Random();
            int i = adrandeom.Next(1, 100);
            if(i<=10)
            {
                interstitialAd.ShowAd();
            }          
        }
        // 为 ViewModel 项加载数据
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.NavigationMode==NavigationMode.Back)
            {
                return;
            }
            this.surfaceAdImageXaml.InitAdControl(AdModeType.Normal); 
           // this.surfaceAdImageXaml.InitAdControl(AdModeType.Debug); 
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
         
            // 在此处添加事件处理程序实现。
            if (panoroma.SelectedIndex == 0&&b1.CanGoBack)
            {
                b1.GoBack();
                e.Cancel = true;
            }
      else      if (panoroma.SelectedIndex == 1 && b2.CanGoBack)
            {
                b2.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 2 && b3.CanGoBack)
            {
                b3.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 3 && b4.CanGoBack)
            {
                b4.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 4 && b5.CanGoBack)
            {
                b5.GoBack();
                e.Cancel = true;

            }
            else if (panoroma.SelectedIndex == 5 && b6.CanGoBack)
            {
                b6.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 6 && b7.CanGoBack)
            {
                b7.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 7 && b8.CanGoBack)
            {
                b8.GoBack();
                e.Cancel = true;
            }
            else if (panoroma.SelectedIndex == 8 && b9.CanGoBack)
            {
                b9.GoBack();
                e.Cancel = true;
            }
           
            else
            {
                PhoneApplicationFrame myFrame = Application.Current.RootVisual as PhoneApplicationFrame;
                MessageBoxResult result = MessageBox.Show("确认退出?", "提示", MessageBoxButton.OKCancel);
                //  settile();
                // If the user agreed, change to strobe mode 
                if (result == MessageBoxResult.OK)
                {

                }
                else
                {
                    e.Cancel = true;
                }
                base.OnBackKeyPress(e);
            }

        }
        private void ApplicationBarIconButton_Click_1(object sender, System.EventArgs e)
        {
        	// 在此处添加事件处理程序实现。
            if(panoroma.SelectedIndex==0)
            {
                b1.GoBack();
            }
             if(panoroma.SelectedIndex==1)
            {
                b2.GoBack();
            }
             if(panoroma.SelectedIndex==2)
            {
                b3.GoBack();
            }
             if(panoroma.SelectedIndex==3)
            {
                b4.GoBack();
            }
             if(panoroma.SelectedIndex==4)
            {
                b5.GoBack();

            }
             if(panoroma.SelectedIndex==5)
            {
                b6.GoBack();
            }
             if(panoroma.SelectedIndex==6)
            {
                b7.GoBack();
            }
             if(panoroma.SelectedIndex==7)
            {
                b8.GoBack();
            }
             if(panoroma.SelectedIndex==8)
            {
                b9.GoBack();
            }
        }

        private void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        	// 在此处添加事件处理程序实现。
           
        }

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/dacxiao.xaml",UriKind.Relative));
        }

        private void panoroma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (panoroma.SelectedIndex == 0)
            {
                b1.GoBack();
            }
            if (panoroma.SelectedIndex == 1 && b2.Source == null)
            {
                b2.Navigate(new Uri("http://wap.people.com.cn/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 2 && b3.Source == null)
            {
                b3.Navigate(new Uri("http://wap.cctv.com", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 3 && b4.Source == null)
            {
                b4.Navigate(new Uri("http://wap.gmw.cn/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 4 && b5.Source == null)
            {
                b5.Navigate(new Uri("http://wap.ycwb.com/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 5&& b6.Source == null)
            {
                b6.Navigate(new Uri("http://wap.cnhubei.com/", UriKind.Absolute));
            }
            if (panoroma.SelectedIndex == 6 && b7.Source == null)
            {
                b7.Navigate(new Uri("http://wap.cnwest.com/", UriKind.Absolute));
            } 
           
            if (panoroma.SelectedIndex == 7 && b8.Source == null)
            {
                b8.Navigate(new Uri("http://m.news.cn/html/", UriKind.Absolute));
            } 
            if (panoroma.SelectedIndex == 8 && b9.Source == null)
            {
                b9.Navigate(new Uri("http://m.cnr.cn/", UriKind.Absolute));
            }


        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
           this.NavigationService.Navigate(new Uri("/Ot.xaml", UriKind.Relative));
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            List<WebBrowser>  listbrower=new List<WebBrowser>();
            GetVisualChildCollection(panoroma, listbrower);
            if(listbrower.Count>0)
            {
               for(int I=0; I<listbrower.Count;I++)
               {
                   listbrower[I] = null;
               }
            }

        }
        private static void GetVisualChildCollection<T>(DependencyObject parent, List<T> visualCollection) where T : UIElement
        {
            //查找parent的子控件集合中存在的子级数目
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                //获取parent控件的i级子控件
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    //若子控件属于ScrollBar控件则将之添加到结果List中
                    visualCollection.Add(child as T);
                }
                else if (child != null)
                {
                    //若子控件不属于ScrollBar控件，且不是null，则使用递归方法再次查询该子控件的子控件
                    GetVisualChildCollection(child, visualCollection);
                }
            }
        }
        public static T FindChildOfType<T>(DependencyObject root) where T : class
        {
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                DependencyObject current = queue.Dequeue();
                for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; 0 <= i; i--)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typedChild = child as T;
                    if (typedChild != null)
                    {
                        return typedChild;
                    }
                    queue.Enqueue(child);
                }
            }
            return null;
        }
        private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PivotPageenlish.xaml", UriKind.Relative));
        }

        private void TextBlock_Tap_3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/menhuPanoramaPage.xaml", UriKind.Relative));
        }

        private void countryboaerder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/RegionPage.xaml", UriKind.Relative));
        }

        private void rate_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void seracbar_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SearchPanoramaPage.xaml", UriKind.Relative));
        }

        private void shenghuoborder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ShenghuoPanoramaPage.xaml", UriKind.Relative));
        }

        private void inputbar_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/inputPanoramaPage.xaml", UriKind.Relative));
        }
        private void AdView_ReceivedAd(object sender, GoogleAds.AdEventArgs e)
        {

        }

        private void AdView_FailedToReceiveAd(object sender, GoogleAds.AdErrorEventArgs e)
        {

        }

        private void TextBlock_Tap_5(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PivotvideoPage1.xaml", UriKind.Relative));
        }

        private void baikeborder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/baikePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void readbook_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/novelPage.xaml",UriKind.RelativeOrAbsolute));
        }

        private void jingjiborder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/jingjiPanoramaPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void kejiborder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/kejiPanoramaPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tiebaborder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/TiebalistPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tuijianwangzhan_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ReommendWebSitePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void tuijianyingyon_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ApplistPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationBarMenuItem obj = sender as ApplicationBarMenuItem;
           if(obj.Text=="更多")
           {
               this.NavigationService.Navigate(new Uri("/MorePage.xaml", UriKind.RelativeOrAbsolute));
           }
           if (obj.Text == "联系我")
           {
               EmailComposeTask task = new EmailComposeTask();

               task.Subject = "你好";
               task.To = "nan06jing06ok@hotmail.com";
               task.Show();

              // task.Cc = "875867090@qq.com";


            
           }
        }

        private void AdControl_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {

        }

        private void AdControl_AdRefreshed(object sender, EventArgs e)
        {

        }

        private void AdControl_ErrorOccurred_1(object sender, OpenXLive.Advertising.AdErrorEventArgs e)
        {

        }

        private void AdControl_AdCompleted(object sender, EventArgs e)
        {

        }

        private void AdView_AdSdkExceptionEvent(object sender, MSNADSDK.AD.ADExceptionEventArgs e)
        {

        }

        private void AdView_AdRequestSuccessEvent(object sender, MSNADSDK.AD.AdRequestStatesEventArgs args)
        {

        }

        private void jyad_GetAdBackMessageEvent(object sender, JiuYouWp8Ad.GetAdBackMessage e)
        {

        }

        private void jyad_ClickBackMessageEvent(object sender, JiuYouWp8Ad.ClickBackMessage e)
        {

        }
        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    PhoneApplicationFrame myFrame = Application.Current.RootVisual as PhoneApplicationFrame;
        //    MessageBoxResult result = MessageBox.Show("确认退出?", "提示", MessageBoxButton.OKCancel);
        //    //  settile();
        //    // If the user agreed, change to strobe mode 
        //    if (result == MessageBoxResult.OK)
        //    {

        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //    base.OnBackKeyPress(e);
        //}
     
    }
}