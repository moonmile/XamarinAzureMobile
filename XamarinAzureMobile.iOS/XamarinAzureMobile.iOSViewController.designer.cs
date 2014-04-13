// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace XamarinAzureMobile.iOS
{
	[Register ("XamarinAzureMobile_iOSViewController")]
	partial class XamarinAzureMobile_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField textHighScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textUpdated { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField textUserName { get; set; }

		[Action ("clickkUpdate:")]
		partial void clickkUpdate (MonoTouch.Foundation.NSObject sender);

		[Action ("clickRead:")]
		partial void clickRead (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (textUserName != null) {
				textUserName.Dispose ();
				textUserName = null;
			}

			if (textHighScore != null) {
				textHighScore.Dispose ();
				textHighScore = null;
			}

			if (textUpdated != null) {
				textUpdated.Dispose ();
				textUpdated = null;
			}
		}
	}
}
