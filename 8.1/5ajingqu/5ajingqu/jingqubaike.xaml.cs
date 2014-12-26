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

namespace _5ajingqu
{
    public partial class jingqubaike : PhoneApplicationPage
    {
        public jingqubaike()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string str = this.NavigationContext.QueryString.Values.First();
             string strurl = "http://baike.baidu.com/search/word?word=" + str ;
     
           
            HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(strurl));

            //设置请求方式GET POST
            request.Method = "GET";

            //返回应答请求异步操作的状态
            request.BeginGetResponse(responseCallback, request);
            base.OnNavigatedTo(e);
        }
        private void responseCallback(IAsyncResult result)
        {
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
                //解析应答头
                //parseRecvHeader(response.Headers);
                //获取请求体信息长度
                long contentLength = response.ContentLength;

                //获取应答码
                int statusCode = (int)response.StatusCode;
                string statusText = response.StatusDescription;

                //应答头信息验证
                using (Stream stream = response.GetResponseStream())
                {
                    //获取请求信息
                    StreamReader read = new StreamReader(stream);
                    string msg = read.ReadToEnd();
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        // textBlock1.Text = msg;
                        wb.Navigate(response.ResponseUri);
                    });
                }

            }
            catch (WebException e)
            {
                //连接失败
            
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // textBlock1.Text = msg;
                    MessageBox.Show("请连网");
                });

            }
            catch (Exception e)
            {
                //异常处理

            }

        }
    }
}