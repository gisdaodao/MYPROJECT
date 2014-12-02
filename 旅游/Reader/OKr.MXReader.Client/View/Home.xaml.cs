using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using OKr.MXReader.Client.Core.Data;
using System.IO.IsolatedStorage;
using OKr.MXReader.Client.Core;
using OKr.MXReader.Client.View.Shared;
using OKr.MXReader.Client.Core.Context;
using At.Phone.Common.Utils;
using GoogleAds;
using SurfaceAd.SDK.WP;
using Microsoft.Phone.Tasks;
using System.Diagnostics;

namespace OKr.MXReader.Client.View
{
    public partial class Home : PhoneApplicationPage
    {
        private InterstitialAd interstitialAd;
        public Home()
        {
            InitializeComponent();
            interstitialAd = new InterstitialAd("ca-app-pub-1598808565430684/4412492859");
            // NOTE: You can edit the event handler to do something custom here. Once the
            // interstitial is received it can be shown whenever you want.
            interstitialAd.ReceivedAd += OnAdReceived;
            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = false;
            interstitialAd.LoadAd(adRequest);
            base.Loaded += new RoutedEventHandler(this.OnLoaded);
           // ad.Start();

            this.surfaceAdImageXaml.InitAdControl(AdModeType.Normal); 
        }
     private void OnAdReceived(object sender, AdEventArgs e)
        {
            Random p = new Random();
            int j = p.Next(1, 100);
         if(j>=88)
         {
             interstitialAd.ShowAd();
         }          
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            NavHelper.Quit(this);

            //if (MessageBox.Show("确定退出" + OkrBookContext.Current.Config.Name + "吗？", OkrBookContext.Current.Config.Name, MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
            //else
            //{
            //    NavHelper.Quit(this);
            //}
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.loader.Start();

            IsolatedStorageSettings.ApplicationSettings.TryGetValue<Book>("bookinfo", out this.book);
            if (this.book == null)
            {
                this.book = TextParser.GetBook(OkrBookContext.Current.Config.Data +"/category.txt", UriKind.Relative);
                IsolatedStorageSettings.ApplicationSettings["bookinfo"] = this.book;
            }

            Progress progress = null;

            IsolatedStorageSettings.ApplicationSettings.TryGetValue<Progress>("current", out progress);
            if (progress == null)
            {
                progress = new Progress();
                progress.Chapter = 0;
                progress.Page = 0;
                progress.Percent = 0.0;
                IsolatedStorageSettings.ApplicationSettings["current"] = progress;
            }

            this.Init();
        }

        private void Init()
        {
            clist.Items.Clear();

            this.tbIntro.Text = OkrBookContext.Current.Config.Intro;
            this.tbName.Text = OkrBookContext.Current.Config.Name;
            this.tbAuthor.Text = OkrBookContext.Current.Config.Author;

            this.LoadChapter();
            this.LoadMarks();

            this.loader.Stop();
        }

        private void OnPanoChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch (this.pano.SelectedIndex)
            //{
            //    case 1:
            //        LoadChapter();
            //        break;
            //    case 2:
            //        LoadMarks();
            //        break;
            //    default:
            //        break;
            //}
        }

        private void OnShow(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Viewer.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnBooks(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Apps.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnComment(object sender, RoutedEventArgs e)
        {
            OKrHelper.Comment();
        }

        private void OnFeedback(object sender, RoutedEventArgs e)
        {
            OKrHelper.Feedback(OkrBookContext.Current.App.AppName, OkrBookContext.Current.App.Version, OkrBookContext.Current.App.Email);
        }

        private void OnShare(object sender, RoutedEventArgs e)
        {
            string appid = OkrBookContext.Current.App.AppId;

            if (string.IsNullOrEmpty(appid))
            {
                appid = WMAppManifestUtils.GetWMAppManifest().ProductID;
            }

            OKrHelper.Share(OkrBookContext.Current.App.AppName, OkrBookContext.Current.App.AppId);
        }

        private void OnSetting(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Setting.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnAbout(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/About.xaml", UriKind.RelativeOrAbsolute));
        }

        private void LoadChapter()
        {
            int index = 0;
            foreach (var chapter in this.book.Chapters)
            {
                ChapterItem item = new ChapterItem();
                chapter.ChapterNo = index;
                item.DataContext = chapter;

                clist.Items.Add(item);
                index++;
            }
        }

        private void LoadMarks()
        {
            mlist.Items.Clear();
            this.mark = GetMark();

            foreach (var mark in this.mark.Marks)
            {
                ChapterMark tmp = mark;
                BookmarkItem item = new BookmarkItem();
                item.DataContext = tmp;

                item.Click += (sender, ex) =>
                {
                    Progress progress = null;

                    IsolatedStorageSettings.ApplicationSettings.TryGetValue<Progress>("current", out progress);
                    if (progress == null)
                    {
                        progress = new Progress();
                    }
                    progress.Chapter = tmp.ChapterNo;
                    progress.Page = tmp.Current;
                    progress.Percent = tmp.Percent;
                    IsolatedStorageSettings.ApplicationSettings["current"] = progress;

                    Dispatcher.BeginInvoke(() =>
                    {
                        (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(new Uri("/View/Viewer.xaml", UriKind.Relative));
                    });
                };

                this.mlist.Items.Add(item);
            }
        }

        private Mark GetMark()
        {
            //todo: {WT}, change the way of marks, record marks in DB
            Mark result = null;

            IsolatedStorageSettings.ApplicationSettings.TryGetValue<Mark>("marks", out result);
            if (result == null)
            {
                result = new Mark();
            }

            return result;
        }

        private Book book;
        private Mark mark;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button border = sender as Button;
            string dataurl = border.Tag.ToString();           
            WebBrowserTask task = new WebBrowserTask();
            task.Uri = new Uri(dataurl, UriKind.RelativeOrAbsolute);
            task.Show();
        }


    }
}