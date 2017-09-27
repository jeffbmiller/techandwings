using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Analytics;
using Foundation;
using TechAndWings.Services;
using UIKit;

namespace TechAndWings.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.Forms.DependencyService.Register<IFirebaseDatabaseService, FirebaseDatabaseIOSService>();
            LoadApplication(new App());
            Firebase.Analytics.App.Configure();


            return base.FinishedLaunching(app, options);
        }
    }
}
