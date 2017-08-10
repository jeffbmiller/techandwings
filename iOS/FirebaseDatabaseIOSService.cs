using System;
using Firebase.Database;
using TechAndWings.Models;
using TechAndWings.Services;

namespace TechAndWings.iOS
{
    public class FirebaseDatabaseIOSService : IFirebaseDatabaseService
    {

        public void StartStreamingChatMessage(Action<Message> callback){
			var firebase = new Firebase.Xamarin.Database.FirebaseClient("https://techandwings-272dc.firebaseio.com");
			var observable = firebase
						.Child("messages")
						.AsObservable<Message>()
				.Subscribe(d =>
                {
                    callback(d.Object);
				});
        }

		public async void Add(Message message)
		{
			var firebase = new Firebase.Xamarin.Database.FirebaseClient("https://techandwings-272dc.firebaseio.com");
			var result = await firebase.Child("messages")
											.PostAsync(message);
		}
    }
}
