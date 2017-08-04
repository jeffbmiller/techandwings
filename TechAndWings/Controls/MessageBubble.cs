using System;
using Xamarin.Forms;

namespace TechAndWings
{
    public class MessageBubble : Label
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

        public static readonly BindableProperty MessagePositionProperty = BindableProperty.Create(
    propertyName: "MessagePosition",
    returnType: typeof(String),
    declaringType: typeof(String),
    defaultValue: "");

        public string MessagePosition
        {
            get { return (string)GetValue(MessagePositionProperty); }
            set { SetValue(MessagePositionProperty, value); }
        }


        public static readonly BindableProperty MyMessageProperty = BindableProperty.Create(
        propertyName: "MyMessage",
        returnType: typeof(bool),
        declaringType: typeof(bool),
        defaultValue: false);

        public bool MyMessage
        {
            get { return (bool)GetValue(MyMessageProperty); }
            set { SetValue(MyMessageProperty, value); }
        }
    }
}
