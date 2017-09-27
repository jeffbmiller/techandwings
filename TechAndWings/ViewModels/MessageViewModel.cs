using System;
using TechAndWings.Models;

namespace TechAndWings.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private ChatMessage message;
        private string currentUser;

        public MessageViewModel(ChatMessage message, string currentUser)
        {
            this.message = message;
            this.currentUser = currentUser;
        }

        public string Text => message.Message;
        public string User => currentUser;
        public bool ShowUser => currentUser != message.User;
        public bool MyMessage => message.User == currentUser;
    }
}
