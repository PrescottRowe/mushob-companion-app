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
    public partial class Help : ContentPage
    {
        public Help() //This is a very simple text page, HTML was not working so flipped back to all xaml labels for now. 
        {
            InitializeComponent();
        }
    }
}