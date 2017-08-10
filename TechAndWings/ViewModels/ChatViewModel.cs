using System;
using System.Collections.ObjectModel;
using TechAndWings.Models;
using TechAndWings.Services;
using Xamarin.Forms;

namespace TechAndWings.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        private string user = "Jeff";
        private IFirebaseDatabaseService db;
        public ChatViewModel()
        {
            db = DependencyService.Get<IFirebaseDatabaseService>();
            Messages = new ObservableCollection<MessageViewModel>();

            db.StartStreamingChatMessage(x =>
            {
                Messages.Add(new MessageViewModel(x,user));
            });
            //Messages.Add(new MessageViewModel(new Message(){Text="Welcome To Chat", User="Admin"}, user));
            //Messages.Add(new MessageViewModel(new Message() { Text = "Where do we want to meet this month?", User = "Jeff" }, user));
            //Messages.Add(new MessageViewModel(new Message() { Text = "How about The Decker?", User = "James" }, user));
            //Messages.Add(new MessageViewModel(new Message() { Text = "Sounds good to me.", User = "Jeff" }, user));

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

            db.Add(new Models.Message(){Text = message, User= user});
            Messages.Add(new MessageViewModel(new Models.Message(){Text = Message, User=user},user));
            Message = null;
			MessagingCenter.Send(this,"scollToLastMessage");
		
        }
    }
}
