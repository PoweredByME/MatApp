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
using Android.Graphics;
using MatApp;
using Android.Hardware;
using Android.Media;


namespace theAndroidInterface
{
	public static class AndroidInterface
	{
	    public static Android.Widget.TextView theMessageOutputFeild;
		public static ListView OutputListView;
		public static Context theContext;
		public static LinearLayout theListLayout;
		public static bool isDown, isAnimating;
		public static List<Expression> theList = new List<Expression>();
		public static TextView theListEndTextViewLine; 
		public static MatAppAdapter adapter;
		public static void resetTheDisplayList()
		{
			theList = new List<Expression> ();
			MatApp.MatAppAdapter adapter = new MatApp.MatAppAdapter (theContext, theList);
			OutputListView.Adapter = adapter;
		}

		public static void AndroidExpressionPrinter(Expression theExpression)  //this prints the lists.
		{

			OutputListView.SetBackgroundColor (new Android.Graphics.Color(255,255,255, 0));
			OutputListView.Clickable = true;
			Expression x = new Expression (theExpression);
			theList.Insert (0, x);
			adapter = new MatApp.MatAppAdapter (theContext, theList);
			OutputListView.Adapter = adapter;


		}

		public static void AndroidAdapterRecaller()
		{
			adapter = new MatApp.MatAppAdapter (theContext, theList);
			OutputListView.Adapter = adapter;

		}

		public static void androidMessagePrinter(string exp)   // this function prints the messages.
		{
			theMessageOutputFeild.Text = exp;
			if (theMessageOutputFeild.Alpha == 0 && OutputListView.Alpha == 1) {
				theMessageOutputFeild.Animate ().AlphaBy (1.0f).SetDuration (500).Start ();
				OutputListView.Animate ().AlphaBy (-1.0f).SetDuration (500).Start ();
			}
		}


	}
}

