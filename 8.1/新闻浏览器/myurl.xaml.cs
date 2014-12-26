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
    public partial class myurl : PhoneApplicationPage
    {
        List<Info> mylist = new List<Info>();
        public myurl()
        {
            InitializeComponent();
            using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
            {


                if (!iso.FileExists("a.txt"))
                {
                    //using (IsolatedStorageFileStream fs = iso.CreateFile("a.txt"))
                    //{
                    //    using (StreamReader reader = new StreamReader(fs))
                    //    {

                    //    }

                    //}
                }
                else
                {
                    using (IsolatedStorageFileStream fs = iso.OpenFile("a.txt", FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(fs))
                        {
                            while (!reader.EndOfStream)
                            {
                                string str = reader.ReadLine();
                                string[] result = str.Split(',');
                                Info one = new Info() { text = result[0], dataurl = result[1] };
                                mylist.Add(one);
                            }
                            longlistbox.ItemsSource = mylist;
                            reader.Close();
                        }

                    }
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string str = this.NavigationContext.QueryString["url"];
            wb.Navigate(new Uri(str, UriKind.RelativeOrAbsolute));
        }

        private void Border_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Info info = (sender as Border).DataContext as Info;
            wb.Navigate(new Uri(info.dataurl, UriKind.RelativeOrAbsolute));
            panorama.DefaultItem = PanoramaItem1;
        }
    }
}