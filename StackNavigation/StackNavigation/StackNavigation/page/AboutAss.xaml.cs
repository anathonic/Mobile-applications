using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackNavigation.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutAss : ContentPage
    {
        public AboutAss()
        {
            InitializeComponent();
        }

        private void btnContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Contact(), animated: true); 
        }
    }
}