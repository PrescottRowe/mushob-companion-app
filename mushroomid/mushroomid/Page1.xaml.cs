using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public List<mushroom> Allmushrooms { get; set; }
        public Page1()
        {
            InitializeComponent();
        }
        public class mushroom
        {
            public string mushroomId { get; set; }
            public string mushroomName { get; set; }
            public string Url { get; set; }
        }
        public class mushrooms
        {
            public static IEnumerable<mushroom> Get()
            {
                return new List<mushroom>
                {
                  new mushroom() {mushroomId="58", mushroomName="Agarics", Url="Agarics.jpg"},
                  new mushroom() {mushroomId="658", mushroomName="Chanterelles", Url="Chanterelles.jpg" },
                  new mushroom() {mushroomId="488", mushroomName="Boletes", Url="Boletes.jpg" },
                  new mushroom() {mushroomId="878", mushroomName="Polypores & Bracket", Url="Pollypores_Bracket.jpg" },
                  new mushroom() {mushroomId="669", mushroomName="Jelly", Url="Jelly.jpg" },
                  new mushroom() {mushroomId="604", mushroomName="Crust & Parchment", Url="Crust_Parchment.jpg"},
                  new mushroom() {mushroomId="611", mushroomName="Teeth", Url="Teeth.jpg" },
                  new mushroom() {mushroomId="630", mushroomName="Coral", Url="Coral.jpg" },
                  new mushroom() {mushroomId="724", mushroomName="Gastroid Agarics", Url="Gastroid_Agarics.jpg" },
                  new mushroom() {mushroomId="677", mushroomName="Earthstars & Puffballs", Url="EarthStars_PuffBalls.jpg" },
                  new mushroom() {mushroomId="715", mushroomName="Stalked Puffballs", Url="StalkedPuffBalls.jpg" },
                  new mushroom() {mushroomId="778", mushroomName="Bird's Nest", Url="BirdsNests.jpg" },
                  new mushroom() {mushroomId="764", mushroomName="Stinkhorns", Url="StinkHorns.jpg" },
                  new mushroom() {mushroomId="739", mushroomName="False Truffles", Url="FalseTruffles.jpg" },
                  new mushroom() {mushroomId="841", mushroomName="Truffles", Url="Truffles.jpg" },
                  new mushroom() {mushroomId="878", mushroomName="Flask", Url="FlaskFungi.jpg" },
                  new mushroom() {mushroomId="783", mushroomName="Morels, Elfin, Cup", Url="Morel_elfin_saddle_cup.jpg" },
                  new mushroom() {mushroomId="865", mushroomName="Earth Tongues", Url="EarthTongues.jpg" }
                };
            }
        }
        public async void OnButtonClicked(object sender, System.EventArgs e)
        {
            mushroom tappedPost = (mushroom)((ListView)sender).SelectedItem;
            Console.WriteLine("---------------------");
            Console.WriteLine(tappedPost.mushroomId);
            //await Navigation.PushAsync(new Page2(tappedPost.mushroomId));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Allmushrooms = new List<mushroom>(mushrooms.Get());
            ListViewList.ItemsSource = Allmushrooms;
        }
    }
}