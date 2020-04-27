using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mushroomid
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void GoToWebPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WebPage());
        }
        async void GoToPage2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }
        async void GoToMapPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
        async void GoToHelpPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Help());
        }
    }

}

