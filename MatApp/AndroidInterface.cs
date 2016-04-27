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
using DataTypeSpace;

namespace theAndroidInterface
{
	public static class AndroidInterface
	{
	    public static Android.Widget.TextView theMessageOutputFeild;
		public static ListView OutputListView;
		public static Context theContext;
		static List<Expression> theList = new List<Expression>();

		public static void AndroidExpressionPrinter(Expression theExpression)
		{
			Expression x = new Expression (theExpression);
			theList.Insert (0, x);
			MatApp.MatAppAdapter adapter = new MatApp.MatAppAdapter (theContext, theList);
			OutputListView.Adapter = adapter;

			if (theList.Count >= 70) {
				theList.RemoveRange (60, 11);
			}
		}
			

		public static void androidMessagePrinter(string exp)
		{
			theMessageOutputFeild.Text = exp;
		}
	}
}

