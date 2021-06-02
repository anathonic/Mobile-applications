using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StackNavigation.page;

namespace StackNavigation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnAboutus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutAss());
        }
    }
}
