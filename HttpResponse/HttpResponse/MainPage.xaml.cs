using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HttpResponse.Resources;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HttpResponse
{
    public partial class MainPage : PhoneApplicationPage
    {
   
        // Constructor
        //public string User { get; set;}
        public  MainPage()
        {
            
            InitializeComponent();
            username.Text = "";
            password.Text = "";
           
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (username.Text == "" && password.Text == "")
                {
                    MessageBox.Show("Insert your Username and Password");
                }
                else
                {
                    //NavigationService.Navigate(new Uri("/Location.xaml", UriKind.Relative));
                    WebClient webclient = new WebClient();
                    webclient.DownloadStringCompleted += webclient_DownloadStringCompleted;
                    webclient.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getuserinfo.php")));

                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("Can not connect to the Server Check Internet connection");

            }
            ////webclient.DownloadStringAsync(new Uri(string.Format("http://localhost/PostToPhp/PostToPhp.php?name=username.text&password.text")));
            
            
            
        }
      
        public void  webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
             //string response=string.Empty;
            Location loc = new Location();
             try
             {
                 if (!string.IsNullOrEmpty(e.Result))
                 {
                     
                      List<User> js =  JsonConvert.DeserializeObject<List<User>>(e.Result);
                      User us = new User();  
                     foreach (var item in js)
                     {
                         if ((item.UserName == username.Text) && (item.Password == password.Text))
                              {
                                  try
                                  {
                                      string user = item.UserName;
                                      MessageBox.Show(user);
                                      //GetUser gu = new GetUser();
                                      //gu.getUser(user);
                                     // loc.userlocation(user);
                                      //WebClient wc = new WebClient();
                                      string uri = string.Format("/Location.xaml?passname={0}",user);


                                      //wc.DownloadStringCompleted += wc_sendUserCompleted;
                                      //wc.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getcurrentusername.php?username=" + user)));
                                     NavigationService.Navigate(new Uri(uri, UriKind.Relative));
                                     break;
                                      //wc.UploadStringAsync(new Uri(url), "POST", prms.FormPostData());
                                  }
                                  catch (Exception ex)
                                  {
                                      MessageBox.Show("Can not connect to the database");
                                  }
                    
                                 
                              }
                              else
                              {
                                  MessageBox.Show("UserName or Password Is not Currect");
                              }
                         
                      }
                          //foreach (var item in js)
                          //{
                          //    if ((item.UserName == username.Text) && (item.Password == password.Text))
                          //    {
                          //        string user = item.UserName;
                          //        loc.sendUserLocation(user);

                          //        NavigationService.Navigate(new Uri("/Location.xaml", UriKind.Relative));
                          //    }
                          //    else
                          //    {
                          //        MessageBox.Show("UserName or Password Is not Currect");
                          //    }


                          //}
                        
                     
                 }
             }

             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
            
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Registration.xaml", UriKind.Relative));
        }
        private void wc_sendUserCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //Console.WriteLine(e.Result);
            MessageBox.Show(e.Result);
        }
       
     
    }
}

