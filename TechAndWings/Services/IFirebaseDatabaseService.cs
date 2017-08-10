using System;
using TechAndWings.Models;

namespace TechAndWings.Services
{
    public interface IFirebaseDatabaseService
    {
        void StartStreamingChatMessage(Action<Message> callback);
        void Add(Message message);
    }
}
