using System;
using System.Collections.Generic;
using System.Linq;
using TechAndWings.ViewModels;
using Xamarin.Forms;

namespace TechAndWings.Views
{
    public partial class ChatPage : ContentPage
    {
        private ChatViewModel viewModel;

        public ChatPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ChatViewModel();

            MessagingCenter.Subscribe<ChatViewModel>(this,"scollToLastMessage",(obj) => {
                listView.ScrollTo(viewModel.Messages.LastOrDefault(),ScrollToPosition.End,true);
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.SubscribeToChatMessages();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.UnSubscribeToChatMessages();
        }
    }
}
