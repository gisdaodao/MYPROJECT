using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using 股票新闻;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
namespace PanoramaApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        // 构造函数
        public MainPage()
        {
            InitializeComponent();

            file.Add(new Info() { text = "淘宝网", dataurl = "http://h5.m.taobao.com/" });
            file.Add(new Info() { text = "京东", dataurl = "http://m.jd.com/" });
            file.Add(new Info() { text = "苏宁易购", dataurl = "http://m.suning.com/" });
            file.Add(new Info() { text = "拍拍网", dataurl = "http://www.paipai.com/m2/index.html" });
            file.Add(new Info() { text = "当当网", dataurl = "http://m.dangdang.com/" });
            file.Add(new Info() { text = "国美在线", dataurl = "http://m.gome.com.cn/" });
            file.Add(new Info() { text = "1号店", dataurl = "http://m.yhd.com/" });
            file.Add(new Info() { text = "亚马逊", dataurl = "http://www.amazon.cn/" });
            file.Add(new Info() { text = "唯品会", dataurl = "http://m.vip.com/" });
            file.Add(new Info() { text = "聚划算", dataurl = "http://jhs.m.taobao.com/m/index.htm" });
            file.Add(new Info() { text = "易迅网", dataurl = "http://m.51buy.com/t" });
            file.Add(new Info() { text = "蘑菇街", dataurl = "http://m.mogujie.com/" });         
          
           
            //file.Add(new Info() { text = "e龙旅行", dataurl = "http://m.elong.com/" });
            // file.Add(new Info() { text = "酒仙网", dataurl = "http://m.jiuxian.com/" });
            //   file.Add(new Info() { text = "美丽说", dataurl = "http://m.meilishuo.com" });
            file.Add(new Info() { text = "糯米网", dataurl = "http://m.nuomi.com/" });
            file.Add(new Info() { text = "天猫网", dataurl = "http://wap.tmall.com/" });
          
          
            //file.Add(new Info() { text = "唯品会", dataurl = "http://m.vip.com/" });
            //file.Add(new Info() { text = "小荷特卖", dataurl = "http://m.xiaoher.com/" });
            //file.Add(new Info() { text = "聚美优品", dataurl = "http://m.jumei.com/" });
            //file.Add(new Info() { text = "当当网", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "折800", dataurl = "http://m.zhe800.com/" });
            //file.Add(new Info() { text = "蘑菇街", dataurl = "http://m.mogujie.com/" });
            //file.Add(new Info() { text = "珍品网", dataurl = "http://m.zhenpin.com/" });
            //file.Add(new Info() { text = "优购时尚商城", dataurl = "http://m.yougou.com/" });
            //file.Add(new Info() { text = "玛萨玛索", dataurl = "http://www.masamaso.com/" });
            //file.Add(new Info() { text = "易迅网", dataurl = "http://m.51buy.com/t" });
            //file.Add(new Info() { text = "蜜桃全球购", dataurl = "http://m.metao.com/" });
            //file.Add(new Info() { text = "我爱购物网", dataurl = "http://m.55bbs.com/" });
            //file.Add(new Info() { text = "聚尚网", dataurl = "http://fclub.cn/" });
            //file.Add(new Info() { text = "银泰网", dataurl = "http://m.yintai.com/" });
            //file.Add(new Info() { text = "走秀网", dataurl = "http://m.xiu.com/cx/index.html" });
            //file.Add(new Info() { text = "我买网", dataurl = "http://m.womai.com/" });
            //file.Add(new Info() { text = "顺丰优选", dataurl = "http://m.sfbest.com/" });
            //file.Add(new Info() { text = "1折网", dataurl = "http://m.1zw.com/" });
            //file.Add(new Info() { text = "乐蜂网", dataurl = "http://m.lefeng.com/" });
            //file.Add(new Info() { text = "天天网", dataurl = "http://m.tiantian.com/" });
            //file.Add(new Info() { text = "草莓网", dataurl = "http://cn.strawberrynet.com/m/mmain.aspx" });
            //file.Add(new Info() { text = "No5化妆品网", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "好乐买", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "乐淘", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "拍鞋网", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "今日特价", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "红蜻蜓旗舰店", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "花花公子旗舰店", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "韩都衣舍旗舰店", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "七匹狼旗舰店", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "金利来旗舰店", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "美特斯邦威旗舰店", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "今日特价", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "今日特价", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "今日特价", dataurl = "http://m.dangdang.com/" });
            //file.Add(new Info() { text = "今日特价", dataurl = "http://m.dangdang.com/" });
            par.ItemsSource = file;
            // 将 listbox 控件的数据上下文设置为示例数据
         
        }
        List<Info> file = new List<Info>();
        // 为 ViewModel 项加载数据
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    //if (!App.ViewModel.IsDataLoaded)
        //    //{
        //    //    App.ViewModel.LoadData();
        //    //}
        //}

        private void TextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
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
                        if (k >=2)
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

    }
}