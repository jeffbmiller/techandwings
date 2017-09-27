using System;
using TechAndWings;
using TechAndWings.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ChatListView), typeof(ChatListViewIOSRenderer))]
namespace TechAndWings.iOS.CustomRenderers
{
    public class ChatListViewIOSRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var tableView = Control as UITableView;
                tableView.AllowsSelection = false;
			}
        }
    }
}
