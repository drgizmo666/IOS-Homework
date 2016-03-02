using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ElementSelection2
{
	partial class DetailViewController : UIViewController
	{
		public string ElementInfo { get; set; }

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewWillAppear (bool animated)
		{
			elementInfoLabel.Text = ElementInfo;
			base.ViewWillAppear (animated);
		}


	}
}
