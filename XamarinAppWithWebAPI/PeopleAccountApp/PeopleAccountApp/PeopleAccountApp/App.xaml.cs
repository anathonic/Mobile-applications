using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestEase;
using PeopleAccountApp.DataContracts;

namespace PeopleAccountApp
{
    public partial class App : Application
    {
        private const string API_URL = "http://172.26.224.1:5000/api";
        public App()
        {
            InitializeComponent();
            var client = RestEase.RestClient.For<IpeopleClient>(API_URL);
            MainPage = new MainPage(client);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
