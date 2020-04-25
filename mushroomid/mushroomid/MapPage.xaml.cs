using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Essentials;
using System.Globalization;


namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public IList<Observation> Observations { get; private set; }
        HttpResponseMessage response;
        public MapPage()
        {
            InitializeComponent();
            MapLocator();
        }
        public partial class Root
        {
            [JsonProperty("version")]
            public long Version { get; set; }

            [JsonProperty("run_date")]
            public DateTimeOffset RunDate { get; set; }

            [JsonProperty("query")]
            public string Query { get; set; }

            [JsonProperty("number_of_records")]
            public long NumberOfRecords { get; set; }

            [JsonProperty("number_of_pages")]
            public long NumberOfPages { get; set; }

            [JsonProperty("page_number")]
            public long PageNumber { get; set; }

            [JsonProperty("results")]
            public Result[] Results { get; set; }

            [JsonProperty("run_time")]
            public double RunTime { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("date")]
            public DateTimeOffset Date { get; set; }

            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }

            [JsonProperty("altitude")]
            public object Altitude { get; set; }

            [JsonProperty("specimen_available")]
            public bool SpecimenAvailable { get; set; }

            [JsonProperty("is_collection_location")]
            public bool IsCollectionLocation { get; set; }

            [JsonProperty("confidence")]
            public double Confidence { get; set; }

            [JsonProperty("notes_fields")]
            public NotesFields NotesFields { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("number_of_views")]
            public long NumberOfViews { get; set; }

            [JsonProperty("last_viewed")]
            public DateTimeOffset LastViewed { get; set; }

            [JsonProperty("owner")]
            public Owner Owner { get; set; }

            [JsonProperty("consensus")]
            public Consensus Consensus { get; set; }

            [JsonProperty("location_name")]
            public string LocationName { get; set; }

            [JsonProperty("collection_numbers")]
            public object[] CollectionNumbers { get; set; }

            [JsonProperty("herbarium_records")]
            public object[] HerbariumRecords { get; set; }

            [JsonProperty("sequences")]
            public object[] Sequences { get; set; }

            [JsonProperty("namings")]
            public Naming[] Namings { get; set; }

            [JsonProperty("primary_image", NullValueHandling = NullValueHandling.Ignore)]
            public PrimaryImage PrimaryImage { get; set; }

            [JsonProperty("images")]
            public object[] Images { get; set; }

            [JsonProperty("comments")]
            public object[] Comments { get; set; }
        }

        public partial class Consensus
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("rank")]
            public string Rank { get; set; }

            [JsonProperty("deprecated")]
            public bool Deprecated { get; set; }

            [JsonProperty("misspelled")]
            public bool Misspelled { get; set; }

            [JsonProperty("citation")]
            public string Citation { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("number_of_views")]
            public long NumberOfViews { get; set; }

            [JsonProperty("last_viewed")]
            public DateTimeOffset LastViewed { get; set; }

            [JsonProperty("ok_for_export")]
            public bool OkForExport { get; set; }

            [JsonProperty("synonym_id")]
            public long SynonymId { get; set; }
        }

        public partial class Naming
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("confidence")]
            public double Confidence { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("name")]
            public Consensus Name { get; set; }

            [JsonProperty("owner_id")]
            public long OwnerId { get; set; }

            [JsonProperty("observation_id")]
            public long ObservationId { get; set; }

            [JsonProperty("votes")]
            public Vote[] Votes { get; set; }

            [JsonProperty("reasons")]
            public object[] Reasons { get; set; }
        }

        public partial class Vote
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("confidence")]
            public long Confidence { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("naming_id")]
            public long NamingId { get; set; }

            [JsonProperty("observation_id")]
            public long ObservationId { get; set; }
        }

        public partial class NotesFields
        {
        }

        public partial class Owner
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("login_name")]
            public string LoginName { get; set; }

            [JsonProperty("legal_name")]
            public string LegalName { get; set; }

            [JsonProperty("joined")]
            public DateTimeOffset Joined { get; set; }

            [JsonProperty("verified")]
            public DateTimeOffset Verified { get; set; }

            [JsonProperty("last_login")]
            public DateTimeOffset LastLogin { get; set; }

            [JsonProperty("last_activity")]
            public DateTimeOffset LastActivity { get; set; }

            [JsonProperty("contribution")]
            public long Contribution { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("mailing_address")]
            public string MailingAddress { get; set; }

            [JsonProperty("location_id")]
            public object LocationId { get; set; }

            [JsonProperty("image_id")]
            public object ImageId { get; set; }
        }

        public partial class PrimaryImage
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("date")]
            public DateTimeOffset Date { get; set; }

            [JsonProperty("copyright_holder")]
            public string CopyrightHolder { get; set; }

            [JsonProperty("notes")]
            public string Notes { get; set; }

            [JsonProperty("quality")]
            public object Quality { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("number_of_views")]
            public long NumberOfViews { get; set; }

            [JsonProperty("last_viewed")]
            public DateTimeOffset LastViewed { get; set; }

            [JsonProperty("ok_for_export")]
            public bool OkForExport { get; set; }

            [JsonProperty("license_id")]
            public long LicenseId { get; set; }

            [JsonProperty("owner_id")]
            public long OwnerId { get; set; }
        }

        async void MapLocator()
        {
            var locator = CrossGeolocator.Current;
            TimeSpan ts = TimeSpan.FromTicks(100000);
            var position = await locator.GetPositionAsync(ts);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
        }
        public class Observation
        {
            public string mushroomName { get; set; }
            public string imageURL { get; set; }
            public string location { get; set; }
            public string date { get; set; }
            public string comments { get; set; }

        }
        async void get_myObservations()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format($"https://mushroomobserver.org/api/observations?user=35629&detail=high&format=json"));
            var request = new HttpRequestMessage();//generating the request
            request.Method = HttpMethod.Get; //get data
            request.RequestUri = uri; //add the uri we built earlier
            response = await client.SendAsync(request);//send the request and store the JSON response
            Console.WriteLine("--------------------------MAP1----------------------");
            Root rootData = null;
            if (response.IsSuccessStatusCode)//if 200
            {
                Console.WriteLine("--------------------------MAP2----------------------");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                rootData = JsonConvert.DeserializeObject<Root>(content);
                Observations = new List<Observation>();
                for (int i = 0; i < rootData.Results.Length; i++)
                {
                    Observations.Add(new Observation
                    {
                        mushroomName = rootData.Results[i].Consensus.Name,
                        imageURL = "https://images.mushroomobserver.org/orig/" + rootData.Results[i].PrimaryImage.Id.ToString() + ".jpg",
                        location = rootData.Results[i].LocationName,
                        date = rootData.Results[i].Date.ToString(),
                        comments = rootData.Results[i].Comments.Length.ToString()
                    });
                }

                //int numberOfObservations = rootData.Results.Length;
                //for(int i=0; i<5; i++)
                //    Console.WriteLine(rootData.Results[i].Id);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            get_myObservations();
            
            ListViewList.ItemsSource = Observations;
        }
    }
}