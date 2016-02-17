using System;

using UIKit;

namespace tictactoe
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void CompMove_TouchUpInside (UIButton sender)
		{
			if(box1.IsFirstResponder)
			{
				if(tictactoe.IsValid(box1.Text) == true){
					box1.Text = tictactoe.FormatInput(box1.Text);
					box1.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box2.IsFirstResponder)
			{
				if(tictactoe.IsValid(box2.Text) == true){
					box2.Text = tictactoe.FormatInput(box2.Text);
					box2.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box3.IsFirstResponder)
			{
				if(tictactoe.IsValid(box3.Text) == true){
					box3.Text = tictactoe.FormatInput(box3.Text);
					box3.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box4.IsFirstResponder)
			{
				if(tictactoe.IsValid(box4.Text) == true){
					box4.Text = tictactoe.FormatInput(box4.Text);
					box4.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box5.IsFirstResponder)
			{
				if(tictactoe.IsValid(box5.Text) == true){
					box5.Text = tictactoe.FormatInput(box5.Text);
					box5.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box6.IsFirstResponder)
			{
				if(tictactoe.IsValid(box6.Text) == true){
					box6.Text = tictactoe.FormatInput(box6.Text);
					box6.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box7.IsFirstResponder)
			{
				if(tictactoe.IsValid(box7.Text) == true){
					box7.Text = tictactoe.FormatInput(box7.Text);
					box7.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box8.IsFirstResponder)
			{
				if(tictactoe.IsValid(box8.Text) == true){
					box8.Text = tictactoe.FormatInput(box8.Text);
					box8.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
			else if(box9.IsFirstResponder)
			{
				if(tictactoe.IsValid(box9.Text) == true){
					box9.Text = tictactoe.FormatInput(box9.Text);
					box9.Enabled = false;
					PlaceComputer();
				}
				else
				{
					var alert = UIAlertController.Create ("Not supported", "Please Input an X", UIAlertControllerStyle.Alert);
					alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
					PresentViewController (alert, true, null);
				}
			}
		}

		public void PlaceComputer()
		{
			int Move = 1;
			while (Move == 1) {
				switch (tictactoe.ComputerMove ()) {
				case 1:
					if (box1.Text == "") {
						box1.Text = "O";
						box1.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove();
					}
					break;
				case 2:
					if (box2.Text == "") {
						box2.Text = "O";
						box2.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 3:
					if (box3.Text == "") {
						box3.Text = "O";
						box3.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 4:
					if (box4.Text == "") {
						box4.Text = "O";
						box4.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 5:
					if (box5.Text == "") {
						box5.Text = "O";
						box5.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 6:
					if (box6.Text == "") {
						box6.Text = "O";
						box6.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 7:
					if (box7.Text == "") {
						box7.Text = "O";
						box7.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 8:
					if (box8.Text == "") {
						box8.Text = "O";
						box8.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;
				case 9:
					if (box9.Text == "") {
						box9.Text = "O";
						box9.Enabled = false;
						Move = 0;
					} else {
						tictactoe.ComputerMove ();
					}
					break;

				}
			}
		}
	}
}