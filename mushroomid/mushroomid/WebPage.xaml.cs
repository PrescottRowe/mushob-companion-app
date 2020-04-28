using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mushroomid
{//web view was used to show the community wall
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            InitializeComponent();//ended up being super simple to make a web view, shit wrote itself, nothing but a xaml tag with a url
        }
    }
}