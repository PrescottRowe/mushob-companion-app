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
        async void Post_Clicked(object sender, EventArgs args)
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(
                    string.Format(//the format to call to the IP is the link below with the word wanted appeneded to the uri
                        $"https://mushroomobserver.org/api/observations?api_key=qrtv9psezrciw4sjhj9va38ja9h0vi6x&location=California&name="
                        + mushroomName + $"&notes=" +
                        $" Cap_Shape:" + Cap_Shape.Text + $" Cap_Width:" + Cap_Width.Text + $" Cap_Stem_Coloring:" + Cap_Stem_Coloring.Text +
                        $" Spore_Color:" + Spore_Color.Text + $" Gills:" + Gills.Text + $" Stem_Base:" + Stem_Base.Text + $" Veil:" + Veils.Text
                        + $" Other_Markers:" + Markers.Text + $" Texture:" + Texture.Text));
            var request = new HttpRequestMessage();//generating the request
            request.Method = HttpMethod.Post; //get data
            request.RequestUri = uri; //add the uri we built earlier

            HttpResponseMessage response = await client.SendAsync(request);//send the request and store the JSON response
            Console.WriteLine("--------------------------Start of API return 2 .net----------------------");
            if (response.IsSuccessStatusCode)//if 200
            {
                BackgroundImageSource = "WP4.jpg";//default background (changes if error)
                var content = await response.Content.ReadAsStringAsync();//gets json
                Console.WriteLine("--------------------------3 json----------------------");
                Console.WriteLine(content);//print json to console for debugging and development
            }
        }
    }
}