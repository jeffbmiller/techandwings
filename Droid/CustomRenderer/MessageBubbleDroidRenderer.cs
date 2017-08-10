using System;
using TechAndWings;
using TechAndWings.CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MessageBubble), typeof(MessageBubbleDroidRenderer))]
namespace TechAndWings.CustomRenderer.Droid
{
	public class MessageBubbleDroidRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var messageBuble = (MessageBubble)e.NewElement;
				Element.Text = messageBuble.Message;
                Element.TextColor = Color.White;
                Element.BackgroundColor = messageBuble.MyMessage ? Color.Blue : Color.Green;
				Element.HorizontalOptions = messageBuble.MyMessage ? LayoutOptions.End : LayoutOptions.Start;
			
			}
		}
	}
}
