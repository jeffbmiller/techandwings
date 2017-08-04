using System;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using TechAndWings.CustomRenderer.iOS;
using TechAndWings;

[assembly: ExportRenderer(typeof(MessageBubble), typeof(MessageBubbleRenderer))]
namespace TechAndWings.CustomRenderer.iOS
{
	public class MessageBubbleRenderer : ViewRenderer<MessageBubble, UILabel>
	{
		UILabel messageBubble;

        protected override void OnElementChanged(ElementChangedEventArgs<MessageBubble> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				messageBubble = new UILabel();
                messageBubble.Text = e.NewElement.Message;
                messageBubble.BackgroundColor = UIColor.Blue;
                messageBubble.TextColor = UIColor.White;
                messageBubble.Layer.CornerRadius = 5;
                messageBubble.Layer.MasksToBounds = true;
				SetNativeControl(messageBubble);
			}
			if (e.OldElement != null)
			{
				
			}
			if (e.NewElement != null)
			{
				
			}
		}

		
    }
}