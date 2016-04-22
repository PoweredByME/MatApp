using System;

/// <summary>
/// Android interface.
/// This file deals with the 
/// android displat system for matrices and 
/// other things
/// </summary>

namespace theAndroidInterface
{
	public static class AndroidInterface
	{
		static Android.Widget.TextView theOutputFeild;

		public static void setAndroidTextView(Android.Widget.TextView theFeild)
		{
			theOutputFeild = theFeild;
		}

		public static void androidNumberPrinter(string exp)
		{
			theOutputFeild.Text = exp;
		}

		public static void androidMessagePrinter(string exp)
		{
			theOutputFeild.Text = exp;
		}
	}
}

