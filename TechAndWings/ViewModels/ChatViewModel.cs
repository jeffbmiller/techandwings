using System;
using System.Collections.ObjectModel;
using TechAndWings.Models;
using Xamarin.Forms;

namespace TechAndWings.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        private string user = "Jeff";

        public ChatViewModel()
        {
            Messages = new ObservableCollection<MessageViewModel>();

            Messages.Add(new MessageViewModel(new Message(){Text="Welcome To Chat", User="Admin"}, user));
            Messages.Add(new MessageViewModel(new Message() { Text = "Where do we want to meet this month?", User = "Jeff" }, user));
            Messages.Add(new MessageViewModel(new Message() { Text = "How about The Decker?", User = "James" }, user));
            Messages.Add(new MessageViewModel(new Message() { Text = "Sounds good to me.", User = "Jeff" }, user));

            SendMessageCommand = new Command(() => OnSendMessage(), () => Message != null);
        }

        public ObservableCollection<MessageViewModel> Messages { get; set; }

		string message = string.Empty;
		public string Message
		{
			get { return message; }
			set { message = value; OnPropertyChanged(); }
		}

        public Command SendMessageCommand { get; set; }

        private void OnSendMessage(){
            Messages.Add(new MessageViewModel(new Models.Message(){Text = Message, User=user},user));
            Message = null;
			MessagingCenter.Send(this,"scollToLastMessage");
		
        }
    }
}
