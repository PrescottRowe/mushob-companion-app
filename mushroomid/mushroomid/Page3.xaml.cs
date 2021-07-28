using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;
using System.IO;
using Plugin.Geolocator;

namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {//Page is used to post details about the mushroom found
        String mushroomName;

        public Page3(String s)
        {
            InitializeComponent();
            mushroomName = s;
            
        }
        
        async void Post_Clicked(object sender, EventArgs args)//POSTs an image then is followed by the POST for the observation. Currently the API is broken for named locations and Image post in the observation dir.
        {
            loadIndicator.IsRunning = true;//used to show the user clicked the button and now the post is working. Gets shut off at exit. 
            byte[] photo = File.ReadAllBytes(App.GlobalVariables.FilePath);//file path will have been writen on page 1 and now we are turning it into a data stream for the api POST
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://mushroomobserver.org/api/images?api_key=your_key&format=json" 
                    + $"&notes=" + $"Name: " + mushroomName + $",  Cap_Shape:" + Cap_Shape.Text + $",  Cap_Width:" + Cap_Width.Text + $",  Cap_Stem_Coloring:" + Cap_Stem_Coloring.Text +
                    $",  Spore_Color:" + Spore_Color.Text + $",  Gills:" + Gills.Text + $",  Stem_Base:" + Stem_Base.Text + $",  Veil:" + Veils.Text
                    + $",  Other_Markers:" + Markers.Text + $",  Texture:" + Texture.Text);//POST URI with the notes appened. Notes are pulled from entry fields. 
            myReq.Method = "POST";
            myReq.ContentType = "image/jpeg";//specified by api to add this to the header
            myReq.ContentLength = photo.Length;//need to add termination size to header

            Stream newStream = myReq.GetRequestStream();//we have to add the photo as raw data binary data to the body
            newStream.Write(photo, 0, photo.Length);//writes the stream
            // Close the Stream object.
            newStream.Close();
            WebResponse response = myReq.GetResponse();
            Stream dataStream;
            Console.WriteLine("---------------------r2-----------------------");
            string responseFromServer = null;
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }
            Console.WriteLine("---------------------r3-----------------------");
            // Close the response.
            response.Close();

            App.ImagePost imageData = null;//shows the user the image taken/selected
            imageData = JsonConvert.DeserializeObject<App.ImagePost>(responseFromServer);//converts to .net object, we now have the location of the posted image     
            //start writing data to xaml bindings
            Console.WriteLine("---------------------r4-----------------------");
            Create_Observation(imageData.Results[0].ToString());//call the next method to post with the image url and the new observation
            //Create_Observation("1172859");//testing
        }
        async void Create_Observation(String imageNum)//create a post on the database with the mushroom notes and photo
        {
            var locator = CrossGeolocator.Current;//get user current location for the post location
            TimeSpan ts = TimeSpan.FromTicks(10000);
            var position = await locator.GetPositionAsync(ts);
            var placemarks = await Geocoding.GetPlacemarksAsync(position.Latitude, position.Longitude);
            Console.WriteLine("---------------------r5-----------------------");
            var placemark = placemarks?.FirstOrDefault();// location nameing is broken in the api and needs to be suplimented with a geocoded lookup
            if (placemark != null)
            {
                var geocodeAddress =
                    $"AdminArea:       {placemark.AdminArea}\n" +
                    $"CountryCode:     {placemark.CountryCode}\n" +
                    $"CountryName:     {placemark.CountryName}\n" +
                    $"FeatureName:     {placemark.FeatureName}\n" +
                    $"Locality:        {placemark.Locality}\n" +
                    $"PostalCode:      {placemark.PostalCode}\n" +
                    $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                    $"SubLocality:     {placemark.SubLocality}\n" +
                    $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                    $"Thoroughfare:    {placemark.Thoroughfare}\n";
                Console.WriteLine(geocodeAddress);
            }
            Console.WriteLine("---------------------r6-----------------------");
            HttpClient client = new HttpClient();
            var uri = new Uri(
                    string.Format(//the format to call to the IP is the link below with the word wanted appeneded to the uri
                        $"https://mushroomobserver.org/api/observations?api_key=your_key&format=json&thumbnail="
                        + imageNum + $"&location=" + placemark.Locality + $"&name=" + mushroomName + $"&latitude=" + position.Latitude + $"&longitude=" + position.Longitude + $"&notes=" +
                        $"  Cap_Shape:" + Cap_Shape.Text + $",  Cap_Width:" + Cap_Width.Text + $",  Cap_Stem_Coloring:" + Cap_Stem_Coloring.Text +
                        $",  Spore_Color:" + Spore_Color.Text + $",  Gills:" + Gills.Text + $",  Stem_Base:" + Stem_Base.Text + $",  Veil:" + Veils.Text
                        + $",  Other_Markers:" + Markers.Text + $",  Texture:" + Texture.Text));
            var request = new HttpRequestMessage();//generating the request
            request.Method = HttpMethod.Post; //get data
            request.RequestUri = uri; //add the uri we built earlier
            HttpResponseMessage response = await client.SendAsync(request);//send the request and store the JSON response
            Console.WriteLine("--------------------------Start of API return 2 .net----------------------");
            if (response.IsSuccessStatusCode)//if 200
            {
                Console.WriteLine("--------------------------3 json----------------------");
                Console.WriteLine(response);//print json to console for debugging and development
            }
            await Navigation.PopToRootAsync();// post worked, lets dip
        }
    }
}
