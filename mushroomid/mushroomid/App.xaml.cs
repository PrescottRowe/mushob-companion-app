using System;
using Xamarin.Forms;
using Newtonsoft.Json;



namespace mushroomid
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public static class GlobalVariables
        {//several diffrent pages needed to look up this image data so the Image object and path variable were put into this file for easy and consistant use. 
            public static string FilePath = "";
            public static string Global2 = "";//temp testing slot
        }
        public partial class ImagePost
        {
            [JsonProperty("version")]
            public long Version { get; set; }

            [JsonProperty("run_date")]
            public DateTimeOffset RunDate { get; set; }

            [JsonProperty("user")]//can be used for get requests instead of api key along with specifying users to grab data from
            public long User { get; set; }

            [JsonProperty("results")]//Pretty much all the good stuff is the the results array and is the body of the json return. In this case we only weanted meta data but the rest fo the objects populate this field.
            public long[] Results { get; set; }

            [JsonProperty("run_time")]
            public double RunTime { get; set; }
        }
    protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
