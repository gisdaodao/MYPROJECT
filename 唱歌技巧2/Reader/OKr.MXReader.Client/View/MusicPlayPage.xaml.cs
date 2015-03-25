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
using System.IO.IsolatedStorage;

namespace OKr.MXReader.Client.View
{
    public partial class MusicPlayPage : PhoneApplicationPage
    {
        public MusicPlayPage()
        {
            InitializeComponent();
          
        }
        WebClient p = new WebClient();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //p.OpenReadAsync(new Uri(App.musicfilepath, UriKind.RelativeOrAbsolute));p.OpenReadCompleted+=p_OpenReadCompleted;

            mediaplay.Source = new Uri(App.musicfilepath, UriKind.RelativeOrAbsolute);
            mediaplay.Play();
            base.OnNavigatedTo(e);
        }
        string tem = "filerrecord.mp3";
        void p_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
           // throw new NotImplementedException();
            try
            {
                if (e.Error == null)
                {
                    Stream stream = e.Result;
                   
                     using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())  

 {  

     if (myIsolatedStorage.FileExists(tem))  

     {  

         myIsolatedStorage.DeleteFile(tem);  

     }  

 

     using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(tem, FileMode.Create, myIsolatedStorage))  

     {  

         using (BinaryWriter writer = new BinaryWriter(fileStream))  

         {  

             Stream resourceStream =stream;  

             long length = resourceStream.Length;  

             byte[] buffer = new byte[32];  

             int readCount = 0;  

             using (BinaryReader reader = new BinaryReader(stream))  

             {  

                 // read file in chunks in order to reduce memory consumption and increase performance  

                 while (readCount < length)  

                 {  

                     int actual = reader.Read(buffer, 0, buffer.Length);  

                     readCount += actual;  

                     writer.Write(buffer, 0, actual);  

                 }  

             }  

         }  

     }  

   }  
                    //var tStore = IsolatedStorageFile.GetUserStoreForApplication();
                    //var tFStream = new IsolatedStorageFileStream(tem, FileMode.Open, tStore);
                    //if (enbytes != null)
                    //{
                    //    enbytes = null;
                    //}
                    //enbytes = new byte[tFStream.Length];
                    //tFStream.Read(enbytes, 0, enbytes.Length);
                    //tFStream.Close();
                    //Debug.WriteLine(enbytes.Length);
                    mediaplay.SetSource(stream);
                    //XElement p = XElement.Load(stream);
                    //XName xitemname = XName.Get("item");
                    //IEnumerable<XElement> itemnodes = p.Descendants(xitemname).ToList<XElement>();
                    //foreach (var b in itemnodes)
                    //{
                    //    //XName xname = XName.Get("url");
                    //    XName xfromname = XName.Get("from");
                    //    XName xtitlenname = XName.Get("title");
                    //    XName xfilepathname = XName.Get("filepath");
                    //    //   XName ximghname = XName.Get("picurl");
                    //    //XName xtitlenname = XName.Get("title");
                    //    //XName xtitlenname = XName.Get("title");
                    //    //   XName xpicname = XName.Get("picurl");
                    //    //List<Info> groupmusicinfo = new List<Info>();
                    //    sharemusicinfolist.Add(new Info() { text = b.Descendants(xtitlenname).First().Value, info = b.Descendants(xfromname).First().Value, dataurl = b.Descendants(xfilepathname).First().Value });
                    //}
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {

                        indicator.IsVisible = false;
                        indicator.IsIndeterminate = false;
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
     mediaplay.Pause();

    //using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())  

    //{

    //    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(tem, FileMode.Open, FileAccess.Read))  

    //    {

    //        this.mediaplay.SetSource(fileStream);  

    //    }  

    //}  


        //}
    }
}