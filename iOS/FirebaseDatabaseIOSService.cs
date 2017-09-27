using System;
using Firebase.Database;
using Foundation;
using TechAndWings.Models;
using TechAndWings.Services;

namespace TechAndWings.iOS
{
    public class FirebaseDatabaseIOSService : IFirebaseDatabaseService
    {

        public IFirebaseDatabaseReference StartStreamingChatMessage(Action<ChatMessage> callback)
        {
            var chatMessagesListRef = Firebase.Database.Database.DefaultInstance.GetRootReference().GetChild("messages");
            var dbRef = new FirebaseDatabaseReferenceIOS(chatMessagesListRef);

            chatMessagesListRef.ObserveEvent(DataEventType.ChildAdded, (DataSnapshot snapshot) =>
            {
                var data = snapshot.GetValue<NSDictionary>();
                var message = new ChatMessage() { Message = data["Message"].ToString(), User = data["User"].ToString(), Timestamp = DateTime.Parse(data["Timestamp"].ToString()) };
                callback(message);
            });

            return dbRef;
        }

        public async void Add(ChatMessage message)
        {
            var firebase = new Firebase.Xamarin.Database.FirebaseClient("https://techandwings-272dc.firebaseio.com");
            var result = await firebase.Child("messages")
                                            .PostAsync(message);
        }
    }

    public class FirebaseDatabaseReferenceIOS : IFirebaseDatabaseReference
    {
        public DatabaseReference dbRef { get; private set; }

        public FirebaseDatabaseReferenceIOS(DatabaseReference dbRef)
        {
            this.dbRef = dbRef;
        }
        public void StopObserving()
        {
            dbRef.RemoveAllObservers();
        }
    }
}
