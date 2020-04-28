using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()// this page is used to take photos or select old photos, shores all photos to MushID album
        {
            InitializeComponent();

            takePhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {//this holds photo capture and storage options
                    Directory = "MushID",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 2000,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                    return;
                App.GlobalVariables.FilePath = file.Path;//sets file path for reference by other pages
                DisplayAlert("File Location", file.Path, "OK");
                next.IsEnabled = true;//force a photo selection or capture before continueing
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                Console.WriteLine(image.Source);

            };

            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

                });


                if (file == null)
                    return;
                App.GlobalVariables.FilePath = file.Path;//used to set file path for other pages to quickly refernece
                next.IsEnabled = true;//force a photo selection or capture before continueing
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }
        async void GoToNextPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());//flipped page order
        }
        async void GoToPreviousPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
