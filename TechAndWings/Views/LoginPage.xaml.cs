using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TechAndWings
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
