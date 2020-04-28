using System;
using System.ComponentModel;
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
            await Navigation.PushAsync(new Page2());//Page 1 and 2 got flipped to make flow a little nicer but im afraid to rename this last second since i borked my repo with the last rename. 
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

