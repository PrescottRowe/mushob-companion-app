using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;

namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        String mushroomName;
        public Page3(String s)
        {
            InitializeComponent();
            mushroomName = s;
            
        }
        async void Post_Clicked(object sender, EventArgs args)//first add image
        {

            //byte[] photo = File.ReadAllBytes(App.GlobalVariables.FilePath);
            //Console.WriteLine(photo);
            //HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("https://mushroomobserver.org/api/images?api_key=qrtv9psezrciw4sjhj9va38ja9h0vi6x&format=json");
            //myReq.Method = "POST";
            //myReq.ContentType = "image/jpeg";
            //myReq.ContentLength = photo.Length;

            //Stream newStream = myReq.GetRequestStream();
            //newStream.Write(photo, 0, photo.Length);
            //Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", myReq.ContentLength);
            //// Close the Stream object.
            //newStream.Close();
            //WebResponse response = myReq.GetResponse();
            //Stream dataStream;
            //Console.WriteLine("---------------------r2-----------------------");
            //string responseFromServer=null;
            //using (dataStream = response.GetResponseStream())
            //{
            //    // Open the stream using a StreamReader for easy access.
            //    StreamReader reader = new StreamReader(dataStream);
            //    // Read the content.
            //    responseFromServer = reader.ReadToEnd();
            //    // Display the content.
            //    Console.WriteLine(responseFromServer);
            //}

            //// Close the response.
            //response.Close();

            //App.ImagePost imageData = null;
            //imageData = JsonConvert.DeserializeObject<App.ImagePost>(responseFromServer);//converts to .net object                                                                                 //start writing data to xaml bindings
            //Create_Observation(imageData.Results[0].ToString());
            Create_Observation("1172859");
        }
        async void Create_Observation(String imageNum)
        {
            
            HttpClient client = new HttpClient();
            var uri = new Uri(
                    string.Format(//the format to call to the IP is the link below with the word wanted appeneded to the uri
                        $"https://mushroomobserver.org/api/observations?api_key=qrtv9psezrciw4sjhj9va38ja9h0vi6x&format=json&location=California&thumbnail="
                        + imageNum + $"&name=" + mushroomName + $"&notes=" +
                        $"\tCap_Shape:" + Cap_Shape.Text + $",\tCap_Width:" + Cap_Width.Text + $",\tCap_Stem_Coloring:" + Cap_Stem_Coloring.Text +
                        $",\tSpore_Color:" + Spore_Color.Text + $",\tGills:" + Gills.Text + $",\tStem_Base:" + Stem_Base.Text + $",\tVeil:" + Veils.Text
                        + $",\tOther_Markers:" + Markers.Text + $",\tTexture:" + Texture.Text));
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
            await Navigation.PopToRootAsync();
        }
    }
}