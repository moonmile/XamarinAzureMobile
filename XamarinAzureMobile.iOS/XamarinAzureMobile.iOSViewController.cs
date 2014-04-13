using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Threading.Tasks;
using XamarinAzureMobile.Core;


namespace XamarinAzureMobile.iOS
{
	public partial class XamarinAzureMobile_iOSViewController : UIViewController
	{
        Mobile _mobile;
        SampleAzureMobile _model = new SampleAzureMobile();

        public XamarinAzureMobile_iOSViewController(IntPtr handle)
            : base(handle)
		{
        }

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
            // CurrentPlatform.Init();
            _model = new SampleAzureMobile();
            _mobile = new Mobile();
            // initialize
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textUpdated.Text = _model.Updated.ToString();
        }

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
        async partial void clickkUpdate(MonoTouch.Foundation.NSObject sender)
        {
            _model.UserName = textUserName.Text;
            _model.HighScore = int.Parse(textHighScore.Text);
            _model.Updated = DateTime.Parse(textUpdated.Text);
            await _mobile.Update(_model);
            UIAlertView dlg = new UIAlertView();
            dlg.Message = "更新しました";
            dlg.AddButton("OK");
            dlg.Show();
        }
        async partial void clickRead(MonoTouch.Foundation.NSObject sender)
        {
            _model.UserName = textUserName.Text;
            var m = await _mobile.Read(_model.UserName);
            _model.FromCopy(m);
            textUserName.Text = _model.UserName;
            textHighScore.Text = _model.HighScore.ToString();
            textUpdated.Text = _model.Updated.ToString();
        }
	}
}

