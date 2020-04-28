using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public List<mushroom> Allmushrooms { get; set; }//list view object
        public Page1()// page is used to help user figure out the major family of the mushroom
        {
            InitializeComponent();
        }
        public class mushroom //list view object
        {
            public string mushroomId { get; set; }
            public string mushroomName { get; set; }
            public string Url { get; set; }
        }
        public class mushrooms
        {
            public static IEnumerable<mushroom> Get()
            {
                return new List<mushroom>//currently mushroomID is not in use but i want to keep this here for when i add questions to help users figure out the family later. then the ids will be used as a sort of leaf node in final questioning. 
                {
                  new mushroom() {mushroomId="1", mushroomName="Agarics", Url="Agarics.jpg"},
                  new mushroom() {mushroomId="2", mushroomName="Chanterelle", Url="Chanterelles.jpg" },
                  new mushroom() {mushroomId="3", mushroomName="Bolete", Url="Boletes.jpg" },
                  new mushroom() {mushroomId="4", mushroomName="Polypore", Url="Pollypores_Bracket.jpg" },
                  new mushroom() {mushroomId="5", mushroomName="Jelly", Url="Jelly.jpg" },
                  new mushroom() {mushroomId="6", mushroomName="Crust", Url="Crust_Parchment.jpg"},
                  new mushroom() {mushroomId="7", mushroomName="Teeth", Url="Teeth.jpg" },
                  new mushroom() {mushroomId="8", mushroomName="Coral", Url="Coral.jpg" },
                  new mushroom() {mushroomId="9", mushroomName="Gastroid Agaric", Url="Gastroid_Agarics.jpg" },
                  new mushroom() {mushroomId="10", mushroomName="Earthstar", Url="EarthStars_PuffBalls.jpg" },
                  new mushroom() {mushroomId="11", mushroomName="Puffball", Url="StalkedPuffBalls.jpg" },
                  new mushroom() {mushroomId="12", mushroomName="Birds Nest", Url="BirdsNests.jpg" },
                  new mushroom() {mushroomId="13", mushroomName="Stinkhorn", Url="StinkHorns.jpg" },
                  new mushroom() {mushroomId="14", mushroomName="False Truffle", Url="FalseTruffles.jpg" },
                  new mushroom() {mushroomId="15", mushroomName="Truffle", Url="Truffles.jpg" },
                  new mushroom() {mushroomId="16", mushroomName="Ascomycete", Url="FlaskFungi.jpg" },
                  new mushroom() {mushroomId="17", mushroomName="Morel", Url="Morel_elfin_saddle_cup.jpg" },
                  new mushroom() {mushroomId="18", mushroomName="Earth Tongue", Url="EarthTongues.jpg" }
                };
            }
        }
        public async void OnButtonClicked(object sender, System.EventArgs e)
        {
            mushroom tappedPost = (mushroom)((ListView)sender).SelectedItem;
            Console.WriteLine("---------------------");
            Console.WriteLine(tappedPost.mushroomId);
            await Navigation.PushAsync(new Page3(tappedPost.mushroomName));//uses the display name to pass to the 
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Allmushrooms = new List<mushroom>(mushrooms.Get());
            ListViewList.ItemsSource = Allmushrooms;//populate list view
        }
    }
}