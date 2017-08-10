using System;
using TechAndWings;
using TechAndWings.Droid.CustomRenderers;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ChatListView), typeof(ChatListViewDroidRenderer))]
namespace TechAndWings.Droid.CustomRenderers
{
	public class ChatListViewDroidRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

        }
	}
}
