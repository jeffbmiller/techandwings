﻿using System;
using Xamarin.Forms;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using TechAndWings.CustomRenderer.iOS;
using TechAndWings;

[assembly: ExportRenderer(typeof(MessageBubble), typeof(MessageBubbleRenderer))]
namespace TechAndWings.CustomRenderer.iOS
{
	public class MessageBubbleRenderer : LabelRenderer
	{
		UILabel messageBubble;

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
                var messageBuble = (MessageBubble)e.NewElement;
                Element.Text = messageBuble.Message;
                Element.TextColor = UIColor.White.ToColor();
                Element.BackgroundColor = messageBuble.MyMessage ? UIColor.Blue.ToColor() : UIColor.Green.ToColor();
                Element.HorizontalOptions = messageBuble.MyMessage ? LayoutOptions.End : LayoutOptions.Start;
                // Radius for the curves
                this.Layer.CornerRadius = 10;
			}
		}
    }
}