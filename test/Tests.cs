using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace test
{
	[TestFixture]
	public class Tests
	{
		iOSApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the iOS app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			//
			// The iOS project should have the Xamarin.TestCloud.Agent NuGet package
			// installed. To start the Test Cloud Agent the following code should be
			// added to the FinishedLaunching method of the AppDelegate:
			//
			//    #if ENABLE_TEST_CLOUD
			//    Xamarin.Calabash.Start();
			//    #endif
			app = ConfigureApp.iOS.InstalledApp("com.companyname.phonewordios").StartApp();

		}

		[Test]
		public void AppLaunches()
		{
			app.Tap(x => x.Marked("1-855-XAMARIN"));
			app.Screenshot("Tapped on view with class: UITextFieldLabel marked: 1-855-XAMARIN");
			app.ClearText(x => x.Class("UITextField").Text("1-855-XAMARIN"));
			app.EnterText(x => x.Class("UITextField"), "test recorder");
			app.Tap(x => x.Marked("Translate"));
			app.Screenshot("Tapped on view with class: UIButton marked: Translate");

		}
	}
}

