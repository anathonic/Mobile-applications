using PeopleAccountApp.DataContracts;
using System;
using System.IO;
using Xamarin.Forms;


namespace PeopleAccountApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IpeopleClient client;
        private Person person = new Person();
        public MainPage(IpeopleClient client)
        {
            InitializeComponent();

            TakePhoto.Clicked += TakePhoto_Clicked;
            SaveProfile.Clicked += SaveProfile_Clicked;
            Firstname.TextChanged += Firstname_text;
            Lastname.TextChanged += Lastname_text;
            Phonenumber.TextChanged += Phonenumber_text;

            this.client = client;
        }

        private async void SaveProfile_Clicked(object sender, EventArgs e)
        {
            if (!Validate())
            {
                await DisplayAlert("Validation Error", "First name, last name, phone number and picture are required.", "Ok");
                return;
            }
            try
            {
                await client.AddPersonAsync(person);
                await DisplayAlert("Success", "Data has been saved.", "Ok");
                Clear();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void Clear()
        {
            Firstname.Text = string.Empty;
            Phonenumber.Text = string.Empty;
            Lastname.Text = string.Empty;
            imgPhoto.Source = null;
            person = new Person();
        }

        private void Lastname_text(object sender, TextChangedEventArgs e)
        {
            person.LastName = e.NewTextValue;
        }

        private void Phonenumber_text(object sender, TextChangedEventArgs e)
        {
            person.PhoneNumber = e.NewTextValue;
        }

        private void Firstname_text(object sender, TextChangedEventArgs e)
        {
            person.FirstName = e.NewTextValue;
        }



        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

            });

            if (photo != null)
            {
                imgPhoto.Source = ImageSource.FromStream(() => photo.GetStream());
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    photo.GetStream().CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }

                string base64 = Convert.ToBase64String(bytes);
                person.Photo = base64;
            }
        }

        private bool Validate()
        {
            return !(string.IsNullOrWhiteSpace(person.FirstName) ||
                    string.IsNullOrWhiteSpace(person.LastName) ||
                    string.IsNullOrWhiteSpace(person.PhoneNumber) ||
                    string.IsNullOrWhiteSpace(person.Photo)
                );
        }
    }
}
