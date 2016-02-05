using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Web.Http;
//using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HttpResponse
{
    public partial class Registration : PhoneApplicationPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = UserName.Text;
                string pas = pass.Text;
                string phone = phoneno.Text;

                MessageBox.Show(name);
                MessageBox.Show(pas);
                MessageBox.Show(phone);

          

                //var url = "http://neuroitech.com/friendsfinder/getnewuser.php";
              
                WebClient wc = new WebClient();


                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getnewuser.php?username="+name+ "&password=" + pas+ "&phone=" + phone)));
                //wc.UploadStringAsync(new Uri(url), "POST", prms.FormPostData());
            }
           catch (Exception ex)
           {
               MessageBox.Show("Error Sending Data");
           }

        }
      
        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            Console.WriteLine(e.Result);
            MessageBox.Show(e.Result);
        }
    }
}