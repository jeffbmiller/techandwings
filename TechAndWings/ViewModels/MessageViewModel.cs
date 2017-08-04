using System;
using TechAndWings.Models;

namespace TechAndWings.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        private Message message;
        private string currentUser;

        public MessageViewModel(Message message, string currentUser)
        {
            this.message = message;
            this.currentUser = currentUser;
        }

        public string Text => message.Text;

        public bool MyMessage => message.User == currentUser;

        public string Position => "End";
    }
}
