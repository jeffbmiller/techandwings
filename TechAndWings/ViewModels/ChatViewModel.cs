using System;
using System.Collections.ObjectModel;
using TechAndWings.Models;

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
        }

        public ObservableCollection<MessageViewModel> Messages { get; set; }
    }
}
