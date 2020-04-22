using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


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
        {
            public static string FilePath = "";
            public static string Global2 = "";
        }
        public partial class ImagePost
        {
            [JsonProperty("version")]
            public long Version { get; set; }

            [JsonProperty("run_date")]
            public DateTimeOffset RunDate { get; set; }

            [JsonProperty("user")]
            public long User { get; set; }

            [JsonProperty("results")]
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
