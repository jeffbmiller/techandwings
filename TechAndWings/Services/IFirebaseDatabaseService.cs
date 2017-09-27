using System;
using TechAndWings.Models;

namespace TechAndWings.Services
{
    public interface IFirebaseDatabaseService
    {
        IFirebaseDatabaseReference StartStreamingChatMessage(Action<ChatMessage> callback);
        void Add(ChatMessage message);
    }

    public interface IFirebaseDatabaseReference
    {
        void StopObserving();
    }
}
