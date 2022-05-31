using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Group2XamarinProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginClicked(object sender, EventArgs e)
        {
            if (username.Text != null && password.Text != null && username.Text != "" && password.Text != "")
            {
                // Check if username and password is in database and matches
                string correctUser = "user";
                string correctPass = "pass";
                if (username.Text.Equals(correctUser) && password.Text.Equals(correctPass))
                {
                    // Go to GameLibrary Page
                }
                else
                {
                    DisplayAlert("Error", "Wrong Username or Password", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Missing Information", "OK");
            }
        }

        async private void RegisterClicked(object sender, EventArgs e)
        {
            // Go to RegisterPage
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}
