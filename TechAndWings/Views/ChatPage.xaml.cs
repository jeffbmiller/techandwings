using System;
using System.Collections.Generic;
using TechAndWings.ViewModels;
using Xamarin.Forms;

namespace TechAndWings.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel();
        }
    }
}
