using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Shapes;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using System.Windows.Media;
using Microsoft.Phone.Maps.Toolkit;
using Newtonsoft.Json; 


namespace HttpResponse
{
    public partial class Location : PhoneApplicationPage

    {
       // GetUser _iuser = new GetUser();
        Geolocator geolocator = null;
        GeoCoordinate usrcoord;
        bool tracking = false;
        MapLayer myLocationLayer = new MapLayer();
        public string cusername;
        public string ulat;
        public string ulng;
        public double  usergps;
        System.Windows.Threading.DispatcherTimer dt;

        // Constructor
         public Location()
        {
            InitializeComponent();
           // string username = userlocation(cusername);

           // MainPage mp = new MainPage();
           
            dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 1000 Milliseconds
            dt.Tick += new EventHandler(TrackLocation_Click);
           
          


        }

        
        /*private  void TrackLocation_Click(object sender, RoutedEventArgs e)
         {
             WebClient webclient = new WebClient();
             webclient.DownloadStringCompleted += webclient_DownloadStringCompleted;
             webclient.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getuserlocation.php")));
             
         }
         public async void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
         {
             if (!tracking)
             {
                 if (!string.IsNullOrEmpty(e.Result))
                 {
                     LocationData ld = JsonConvert.DeserializeObject<LocationData>(e.Result);

                     geolocator = new Geolocator();
                     geolocator.DesiredAccuracyInMeters = 50;
                     geolocator.MovementThreshold = 1; // The units are meters.
                     Geolocator myGeolocator = new Geolocator();
                     geolocator.StatusChanged += geolocator_StatusChanged;
                     geolocator.PositionChanged += geolocator_PositionChanged;

                     Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(30));
                     Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
                     GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

                     this.mapWithMyLocation.Center = myGeoCoordinate;
                     this.mapWithMyLocation.ZoomLevel = 13;
                     var gpsCoorCenter = new GeoCoordinate(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude);

                     mapWithMyLocation.SetView(gpsCoorCenter, 14);

                     // Create a small circle to mark the current location.
                     Ellipse myCircle = new Ellipse();

                     myCircle.Fill = new SolidColorBrush(Colors.Blue);
                     myCircle.Height = 20;
                     myCircle.Width = 20;
                     myCircle.Opacity = 1;



                     // Create a MapOverlay to contain the circle.
                     MapOverlay myLocationOverlay = new MapOverlay();
                     myLocationOverlay.Content = myCircle;
                     myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
                     myLocationOverlay.GeoCoordinate = myGeoCoordinate;

                     // Create a MapLayer to contain the MapOverlay.
                     MapLayer myLocationLayer = new MapLayer();

                     myLocationLayer.Add(myLocationOverlay);

                     UserLocation ul = new UserLocation();
                     // Add the MapLayer to the Map.

                     mapWithMyLocation.Layers.Add(myLocationLayer);

                     ////gpsCoorCenter = new GeoCoordinate(latitude, longitude);
                     double longitude = double.Parse(ul.Lng);
                     double latitude = double.Parse(ul.Lat);
                     // MessageBox.Show(js.lat);

                     var gpsCoorCenter1 = new GeoCoordinate(latitude, longitude);
                     //mapWithMyLocation.SetView(gpsCoorCenter1, 14);

                     Ellipse myCircle1 = new Ellipse();

                     myCircle1.Fill = new SolidColorBrush(Colors.Red);
                     myCircle1.Height = 20;
                     myCircle1.Width = 20;
                     myCircle1.Opacity = 1;
                     // Create a MapOverlay to contain the circle.
                     MapOverlay myLocationOverlay1 = new MapOverlay();
                     myLocationOverlay1.Content = myCircle1;
                     myLocationOverlay1.PositionOrigin = new Point(0.5, 0.5);
                     //  myLocationOverlay1.GeoCoordinate = gpsCoorCenter1;

                     // Create a MapLayer to contain the MapOverlay.
                     MapLayer myLocationLayer1 = new MapLayer();

                     myLocationLayer1.Add(myLocationOverlay1);

                     // Add the MapLayer to the Map.

                     mapWithMyLocation.Layers.Add(myLocationLayer1);

                     // drawFriendslocation(0.00, 0.00);
                     tracking = true;
                     Polygon pl = new Polygon();

                     TrackLocationButton.Content = "stop tracking";

                 }
                 else
                 {
                     geolocator.PositionChanged -= geolocator_PositionChanged;
                     geolocator.StatusChanged -= geolocator_StatusChanged;
                     geolocator = null;

                     tracking = false;
                     mapWithMyLocation.Layers.Remove(myLocationLayer);
                     TrackLocationButton.Content = "track location";
                     StatusTextBlock.Text = "stopped";
                 }
             }
         }*/
         //  MapLayer myLocationLayer = new MapLayer();
         public async void TrackLocation_Click(object sender, EventArgs e)
         {
            // DrawFriendLocation();

             if (!tracking)
             {

                 geolocator = new Geolocator();
                 geolocator.DesiredAccuracyInMeters=1;
                 geolocator.MovementThreshold = 30; // The units are meters.
                 Geolocator myGeolocator = new Geolocator();
                 geolocator.StatusChanged += geolocator_StatusChanged;
                 geolocator.PositionChanged += geolocator_PositionChanged;

                 Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync(TimeSpan.FromMinutes(5), TimeSpan.FromSeconds(30));
                 Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
                 GeoCoordinate myGeoCoordinate =
                 CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);

                 this.mapWithMyLocation.Center = myGeoCoordinate;
                 this.mapWithMyLocation.ZoomLevel = 13;
                 var gpsCoorCenter = new GeoCoordinate(myGeoposition.Coordinate.Latitude, myGeoposition.Coordinate.Longitude);
                  usrcoord = gpsCoorCenter;
                 mapWithMyLocation.SetView(gpsCoorCenter, 16);

                 // Create a small circle to mark the current location.
                 Ellipse myCircle = new Ellipse();

                 myCircle.Fill = new SolidColorBrush(Colors.Green);
                 myCircle.Height = 20;
                 myCircle.Width = 20;
                 myCircle.Opacity = 1;


                 // Create a MapOverlay to contain the circle.
                 MapOverlay myLocationOverlay = new MapOverlay();
                 myLocationOverlay.Content = myCircle;
                 myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
                 myLocationOverlay.GeoCoordinate = myGeoCoordinate;

                 // Create a MapLayer to contain the MapOverlay.
                 MapLayer myLocationLayer = new MapLayer();

                 myLocationLayer.Add(myLocationOverlay);

                 // Add the MapLayer to the Map.

                 mapWithMyLocation.Layers.Add(myLocationLayer);
                 DrawFriendLocation();

                 tracking = true;
                 Polygon pl = new Polygon();

                 mapWithMyLocation.UpdateLayout();
                 TrackLocationButton.Content = "Stop Tracking";

             }
             else
             {
                 geolocator.PositionChanged -= geolocator_PositionChanged;
                 geolocator.StatusChanged -= geolocator_StatusChanged;
                 geolocator = null;

                 tracking = false;
                 mapWithMyLocation.Layers.Remove(myLocationLayer);
                 TrackLocationButton.Content = "My Location";
                 StatusTextBlock.Text = "Stopped";
             }
         }

        void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {

                LatitudeTextBlock.Text = "Latitude= " + args.Position.Coordinate.Latitude.ToString("0.0000000");
                LongitudeTextBlock.Text = "Longidude= " + args.Position.Coordinate.Longitude.ToString("0.0000000");

                 ulat = args.Position.Coordinate.Latitude.ToString("0.0000000");
                 ulng = args.Position.Coordinate.Longitude.ToString("0.0000000");
               
                sendUserLocation(ulat, ulng);

                mapWithMyLocation.UpdateLayout();
                MessageBox.Show(ulat);
                MessageBox.Show(ulng);
                
                

            });
        }
        private Geolocator _locator;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _locator = new Geolocator()
            {
                ReportInterval = 5000,

                DesiredAccuracyInMeters = 1
            };
            _locator.PositionChanged += _locator_PositionChanged;

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _locator.PositionChanged -= _locator_PositionChanged;
            _locator = null;
            base.OnNavigatedFrom(e);
        }
        void _locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                var geoCoordinate = args.Position.Coordinate.ToGeoCoordinate();
                var locationMarker = this.FindName("locationMarker") as UserLocationMarker;
                if (locationMarker != null)
                {
                    locationMarker.Visibility = System.Windows.Visibility.Visible;
                    locationMarker.GeoCoordinate = geoCoordinate;
                    mapWithMyLocation.SetView(geoCoordinate, 15);
                }
            });
        }



        //public bool sendUserLocation(string name)
        //{

        //    username = name;
        //}
      
       
        public void DrawFriendLocation()
        {
            WebClient webclient = new WebClient();
            webclient.DownloadStringCompleted += webclient_DownloadStringCompleted;
            webclient.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getuserlocation.php")));
             
        }
         public async void webclient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
         {
             List<UserLocation> ld = JsonConvert.DeserializeObject<List<UserLocation>>(e.Result);

            // UserLocation ul = new UserLocation();
             foreach(var item  in ld)
             {
                 try
                 {
                    double longitude = double.Parse(item.Lng);
                    double latitude = double.Parse(item.Lat);
                    double userlat =Convert.ToDouble(ulat);
                    double userlng = Convert.ToDouble(ulng);

                    var frncoord = new GeoCoordinate(latitude, longitude);
                    var distanceinmeter = usrcoord.GetDistanceTo(frncoord);
                    if (usrcoord.GetDistanceTo(frncoord) < 500.0000)
                    {

                        var gpsCoorCenter1 = new GeoCoordinate(latitude, longitude);

                        Ellipse myCircle1 = new Ellipse();

                        myCircle1.Fill = new SolidColorBrush(Colors.Red);
                        myCircle1.Height = 20;
                        myCircle1.Width = 20;
                        myCircle1.Opacity = 1;
                        // Create a MapOverlay to contain the circle.
                        MapOverlay myLocationOverlay1 = new MapOverlay();
                        myLocationOverlay1.Content = myCircle1;
                        myLocationOverlay1.PositionOrigin = new Point(0.5, 0.5);
                        myLocationOverlay1.GeoCoordinate = gpsCoorCenter1;


                        MapLayer myLocationLayer1 = new MapLayer();

                        myLocationLayer1.Add(myLocationOverlay1);

                        mapWithMyLocation.Layers.Add(myLocationLayer1);
                    }
                 }
                 catch(Exception ex)
                 {
                    MessageBox.Show("Can not draw friend location");
                 }
             
             }
             

             
         }


        //}
         public string userlocation(string user)
         {
             return user;
         }
         public string cuser;
         public void sendUserLocation(string ulat, string ulng)
         {
             
             try
             {
                
                 WebClient wc = new WebClient();

                 string username = NavigationContext.QueryString["passname"];
                 string latitude = ulat;
                 string longitude = ulng;
                 MessageBox.Show(username);
                 MessageBox.Show(ulat);
                 MessageBox.Show(ulng);
                 wc.DownloadStringCompleted += wc_LocationSendingCompleted;
                 wc.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getuserlatlng.php?lat=" + latitude + "&lng=" + longitude + "&username=" + username)));
                 //wc.UploadStringAsync(new Uri(url), "POST", prms.FormPostData());
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error Sending Data");
             }



             //WebClient webclient = new WebClient();
             //webclient.DownloadStringCompleted += webclient_DownloadStringCompleted;
             //webclient.DownloadStringAsync(new Uri(string.Format("http://neuroitech.com/friendsfinder/getuserlocation.php")));
             //return true;


         }
         private void wc_LocationSendingCompleted(object sender, DownloadStringCompletedEventArgs e)
         {
             Console.WriteLine(e.Result);
             MessageBox.Show(e.Result);
         }

        void geolocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            string status = "";

            switch (args.Status)
            {
                case PositionStatus.Disabled:
                    // the application does not have the right capability or the location master switch is off
                    status = "Location is disabled in phone settings";
                    break;
                case PositionStatus.Initializing:
                    // the geolocator started the tracking operation
                    status = "Initializing";
                    break;
                case PositionStatus.NoData:
                    // the location service was not able to acquire the location
                    status = "No data";
                    break;
                case PositionStatus.Ready:
                    // the location service is generating geopositions as specified by the tracking parameters
                    status = "ready";
                    break;
                case PositionStatus.NotAvailable:
                    status = "Not available";
                    // not used in WindowsPhone, Windows desktop uses this value to signal that there is no hardware capable to acquire location information
                    break;
                case PositionStatus.NotInitialized:
                    // the initial state of the geolocator, once the tracking operation is stopped by the user the geolocator moves back to this state

                    break;
            }

            Dispatcher.BeginInvoke(() =>
            {
                StatusTextBlock.Text = status;
            });
        }
       

    }
 

}
