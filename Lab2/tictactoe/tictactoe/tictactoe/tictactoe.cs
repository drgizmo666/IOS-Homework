using System;
using UIKit;
using Foundation;

namespace tictactoe
{
	public class tictactoe
	{
		public string[,] board = new string[3,3];

		public tictactoe ()
		{
		}
			
		public static bool IsValid(string input)
		{
			string validInput = input.ToUpper ();
			if (validInput == "X") 
			{
				return true;
			} else 
			{
				return false;
			}
		}

		public static string FormatInput(string input)
		{
			return input.ToUpper ();
		}

		public static int ComputerMove()
		{
			Random r = new Random ();
			int num;
			num = r.Next (9);
			return num;
		}
			
	}
}

