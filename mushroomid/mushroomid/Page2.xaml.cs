using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Essentials;

namespace mushroomid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
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
                {
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
                App.GlobalVariables.FilePath = file.Path;
                DisplayAlert("File Location", file.Path, "OK");
                Console.WriteLine(file.AlbumPath);
                Console.WriteLine(file.Path);
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                Console.WriteLine(image.Source);

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
        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}
