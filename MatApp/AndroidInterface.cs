using System;

/// <summary>
/// Android interface.
/// This file deals with the 
/// android displat system for matrices and 
/// other things
/// </summary>
using Android.OS;
using Android.Views.InputMethods;
using Android.Widget;
using System.Collections.Generic;
using Android.Util;
using System.Runtime.InteropServices;
using Android.Content;
using Javax.Xml.Transform;

namespace theAndroidInterface
{
	public static class AndroidInterface
	{
	    public static Android.Widget.TextView theMessageOutputFeild;
		public static ListView OutputListView;
		public static Context theContext;
		static List<string> theList = new List<string>();

		public static void androidNumberPrinter(string exp)
		{
			theList.Insert (0, exp);
			ArrayAdapter<string> adapter = new ArrayAdapter<string> (theContext, Android.Resource.Layout.SimpleListItem1, theList);
			OutputListView.Adapter = adapter;
			if (theList.Count > 50) {
				theList.RemoveRange (35, 16);
			}
		}

		public static void androidMessagePrinter(string exp)
		{
			theMessageOutputFeild.Text = exp;
		}
	}
}

