using System;
using System.Collections.ObjectModel;
using TechAndWings.Models;
using TechAndWings.Services;
using Xamarin.Forms;

namespace TechAndWings.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        private string user = "Peter";
        private IFirebaseDatabaseService db;

        private IFirebaseDatabaseReference dbRef;

        public ChatViewModel()
        {
            db = DependencyService.Get<IFirebaseDatabaseService>();
            Messages = new ObservableCollection<MessageViewModel>();


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

            db.Add(new Models.ChatMessage(){Message = message, User= user, Timestamp = DateTime.Now});
            Message = null;
        }

        public void SubscribeToChatMessages(){
            Messages.Clear();
			dbRef = db.StartStreamingChatMessage(x =>
			{
				Messages.Add(new MessageViewModel(x, user));
				MessagingCenter.Send(this, "scollToLastMessage");
			});
		}

        public void UnSubscribeToChatMessages(){
            dbRef.StopObserving();
        }
    }
}
