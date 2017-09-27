using System;
using TechAndWings.Models;
using TechAndWings.Services;

namespace TechAndWings.Droid
{
    public class FirebaseDatabaseDroidService : IFirebaseDatabaseService
    {
		public void StartStreamingChatMessage(Action<ChatMessage> callback)
		{
			var firebase = new Firebase.Xamarin.Database.FirebaseClient("https://techandwings-272dc.firebaseio.com");
			var observable = firebase
						.Child("messages")
						.AsObservable<ChatMessage>()
				.Subscribe(d =>
				{
					callback(d.Object);
				});
		}

		public async void Add(ChatMessage message)
		{
			var firebase = new Firebase.Xamarin.Database.FirebaseClient("https://techandwings-272dc.firebaseio.com");
			var result = await firebase.Child("messages")
											.PostAsync(message);
		}
    }
}
