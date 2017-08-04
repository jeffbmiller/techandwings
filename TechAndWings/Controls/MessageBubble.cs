using System;
using Xamarin.Forms;

namespace TechAndWings
{
    public class MessageBubble : View
    {
		public static readonly BindableProperty MessageProperty = BindableProperty.Create(
	propertyName: "Message",
    returnType: typeof(String),
	declaringType: typeof(String),
	defaultValue: "");

		public string Message
		{
			get { return (string)GetValue(MessageProperty); }
			set { SetValue(MessageProperty, value); }
		}
    }
}
