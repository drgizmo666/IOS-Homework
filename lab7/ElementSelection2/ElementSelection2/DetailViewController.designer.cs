// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ElementSelection2
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView detailView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel elementInfoLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (detailView != null) {
				detailView.Dispose ();
				detailView = null;
			}
			if (elementInfoLabel != null) {
				elementInfoLabel.Dispose ();
				elementInfoLabel = null;
			}
		}
	}
}
