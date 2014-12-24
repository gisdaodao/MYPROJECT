using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using System.IO;

namespace 股票新闻
{
    public partial class AddPage : PhoneApplicationPage
    {
        public AddPage()
        {
            InitializeComponent();
            wb.Navigated += wb_Navigated;
            wb.NavigationFailed += wb_NavigationFailed;
            //mylist = sitesttings["myurl"] as List<Info>;
        }
        IsolatedStorageFile solatefile;
        void wb_Navigated(object sender, NavigationEventArgs e)
        {
            btnrun.Content = "测试成功";
        }

        void wb_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            btnrun.Content = "测试失败";
        }
        //IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();
        IsolatedStorageSettings sitesttings = IsolatedStorageSettings.ApplicationSettings;
        //List<Info> mylist =null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info one = new Info() { picurl=string.Empty,info=string.Empty};
            if (string.IsNullOrEmpty(namebox.Text)) return;
            one.text = namebox.Text;
            one.dataurl = nameurlbox.Text;
            //mylist.Add(one);
            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {


                if (!iso.FileExists("a.txt"))
                {
                    using (IsolatedStorageFileStream fs = iso.CreateFile("a.txt"))
                    {
                        using (StreamWriter reader = new StreamWriter(fs))
                        {
                            reader.WriteLine(namebox.Text + "," + nameurlbox.Text);
                            reader.Close();
                        }

                    }
                }
                else
                {
                    using (IsolatedStorageFileStream fs = iso.OpenFile("a.txt",FileMode.Open))
                    {
                        using (StreamWriter reader = new StreamWriter(fs))
                        {
                           
                            reader.WriteLine(namebox.Text + "," + nameurlbox.Text);
                            reader.Close();
                        }

                    }
                }
            }
           // sitesttings.
            btnrun.Content = "添加成功";
        }

        private void btnrun_Click(object sender, RoutedEventArgs e)
        {
            wb.Navigate(new Uri(nameurlbox.Text, UriKind.RelativeOrAbsolute));
        }
    }
}