using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using paizhao.Resources;
using 股票新闻;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;

namespace paizhao
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            file.Add(new Info() { text = "920拍照实用教程_想学的慢慢看吧", dataurl = "3.docx" });
            file.Add(new Info() { text = "Lumia_1020享拍手册", dataurl = "1.pdf" });
            file.Add(new Info() { text = "Lumia手机拍摄烟花的步骤", dataurl = "2.docx" });
            file.Add(new Info() { text = "教你用手机拍照的几个技巧", dataurl = "5.doc" });
            file.Add(new Info() { text = "诺基亚1520拍照", dataurl = "6.doc" });
            file.Add(new Info() { text = "诺基亚920对比诺基亚900拍照能力", dataurl = "8.docx" });

            file.Add(new Info() { text = "诺基亚拍摄技巧", dataurl = "9.docx" });
            file.Add(new Info() { text = "诺基亚专业拍摄：人人都是专业摄影师", dataurl = "10.doc" });
            file.Add(new Info() { text = "手机拍照内存大学问：摄像头参数解读", dataurl = "11.doc" });

            file.Add(new Info() { text = "手机相机基本知识", dataurl = "12.docx" });
            file.Add(new Info() { text = "数码相机各种参数详解", dataurl = "15.txt" });
            file.Add(new Info() { text = "相机参数指导书", dataurl = "19.doc" });
            //file.Add("920拍照实用教程_想学的慢慢看吧.docx");
            //file.Add("Lumia_1020享拍手册.pdf");
            //file.Add("Lumia手机拍摄烟花的步骤.docx");
            //file.Add("教你用手机拍照的几个技巧.doc");
            //file.Add("诺基亚1520拍照.doc");
            //file.Add("诺基亚920对比诺基亚900拍照能力.docx");
            //file.Add("诺基亚拍摄技巧.docx");
            //file.Add("诺基亚专业拍摄：人人都是专业摄影师.doc");
            //file.Add("手机拍照内存大学问：摄像头参数解读.doc");
            //file.Add("手机相机基本知识.docx");
            //file.Add("数码相机各种参数详解.txt");
            //file.Add("相机参数指导书.doc");
            // 将 listbox 控件的数据上下文设置为示例数据
            listboxview.ItemsSource = file;
            webvideo.Add(new Info() { text = "视频: 2000万像素手机终极PK Lumia 1520 Xperia Z1拍照对比(原创)", dataurl = "http://v.youku.com/v_show/id_XNjc2MzMxMDcy.html" });
            webvideo.Add(new Info() { text = "Windows Phone官方快速使用教程演示低光拍照", dataurl = "http://v.youku.com/v_show/id_XNzQ0NDA4MzEy.html?f=22554207" });
            webvideo.Add(new Info() { text = "Windows Phone官方快速使用教程演示问问Cortana", dataurl = "http://v.youku.com/v_show/id_XNzQ0OTI3NTI0.html" });
            webvideo.Add(new Info() { text = "视频: 诺基亚 Lumia 1020拍照演示", dataurl = "http://v.youku.com/v_show/id_XNTgxOTU0ODMy.html" });
            webvideo.Add(new Info() { text = "【分享】诺基亚专业拍照 - 实在是太真了-Nokia1020", dataurl = "http://v.youku.com/v_show/id_XNTgxODYxNjQw.html?from=y1.2-1-105.3.1-2.1-1-1-0" });
            webvideo.Add(new Info() { text = "诺基亚影像专家演示Lumia 920 新奇拍照功能（诺记吧转载）", dataurl = "http://v.youku.com/v_show/id_XNDUzNTk3MjM2.html" });
            webvideo.Add(new Info() { text = "视频: 拍照技巧图解 取景、姿势、虚实", dataurl = "http://v.youku.com/v_show/id_XMjUwNTA3MTg4.html" });
            webvideo.Add(new Info() { text = "视频: 50个快速上手的摄影技巧", dataurl = "http://v.youku.com/v_show/id_XNDA1ODk1OTY0.html" });
            webvideo.Add(new Info() { text = "20个风景摄影技巧", dataurl = "http://v.youku.com/v_show/id_XNDY1OTg4NjQ4.html" });
            webvideo.Add(new Info() { text = "视频: 诺基亚Lumia1020超级说明书3-拍照篇", dataurl = "http://v.youku.com/v_show/id_XNTk2Mzk2MzA0.html" });
            webvideo.Add(new Info() { text = "诺基亚 Lumia 1020 测评", dataurl = "http://v.youku.com/v_show/id_XNjE3NDk3NTMy.html" });
            //webvideo.Add(new Info() { text = "过节方法真不少 出游宅家献法宝", dataurl = "http://v.youku.com/v_show/id_XNzk1MDU0OTMy.html" });
            webvideo.Add(new Info() { text = "视频: Windows Phone8.1操作技巧小汇总", dataurl = "http://v.youku.com/v_show/id_XNzAwNTMyNDQ4.html" });
            webvideo.Add(new Info() { text = "视频: Windows Phone 8 延长电池使用时间几个小技巧", dataurl = "http://v.youku.com/v_show/id_XNTAxMDU0NjEy.html" });
            //webvideo.Add(new Info() { text = "视频: Windows Phone 8 延长电池使用时间几个小技巧", dataurl = "http://v.youku.com/v_show/id_XNTAxMDU0NjEy.html" });
            listboxview2.ItemsSource = webvideo;
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        List<Info> file = new List<Info>();
        List<Info> webvideo = new List<Info>();

        private async void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel stpanel = sender as StackPanel;
            Info info = stpanel.DataContext as Info;
            // First, get the word file from the package's doc directory.  
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(info.dataurl);
            // Next, launch the file.  
            bool success = await Windows.System.Launcher.LaunchFileAsync(file);
            if (success)
            {

            }
            else
            {

            }  
        }

        private void StackPanel_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StackPanel stpanel = sender as StackPanel;
            Info info = stpanel.DataContext as Info;
            WebBrowserTask ptask = new WebBrowserTask();
            ptask.Uri = new Uri(info.dataurl, UriKind.RelativeOrAbsolute);
            ptask.Show();
        }

        private void Grid_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //WebBrowserTask ptask = new WebBrowserTask();
            //ptask.Uri = new Uri("http://www.windowsphone.com/zh-cn/store/app/%E9%A6%96%E5%BA%A6/b0a1e824-e495-46d0-b0d7-f01a6461c0ea", UriKind.RelativeOrAbsolute);
            //ptask.Show();
            MarketplaceDetailTask detail = new MarketplaceDetailTask();
            detail.ContentIdentifier = "b0a1e824-e495-46d0-b0d7-f01a6461c0ea";//设置所要显示的应用程序的标识符。
            detail.ContentType = MarketplaceContentType.Applications;

            detail.Show();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask(); marketplaceReviewTask.Show();      
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
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
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
                        if (k >= 2)
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
        private void sethide()
        {
            adpanel.Visibility = Visibility.Collapsed;
        }
        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            MarketplaceReviewTask p = new MarketplaceReviewTask(); p.Show();
        }
    }
}