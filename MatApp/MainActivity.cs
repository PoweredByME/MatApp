using Android.App;
using Android.Widget;
using Android.OS;
using StringWatch;
using System;
using System.Collections.Generic;

namespace MatApp
{
	[Activity (Label = "MatApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		EditText input;
		TextView output;
		Button enterSolve;
		StringObserver sol;
		string theInput;

		void androidSetup()
		{
			input = FindViewById<EditText> (Resource.Id.editText2);
			output = FindViewById<TextView> (Resource.Id.textView1);
			enterSolve = FindViewById<Button> (Resource.Id.button1);
			enterSolve.Text = "Solve";
			sol = new StringObserver();
			theInput = string.Empty;
		}



		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);
			androidSetup ();

			enterSolve.Click += (object sender, EventArgs e) => 
			{
				androidProcess();
			};

		}    // end method on create


		/// <summary>
		/// Androids the process. 
		/// the Process that happens on the 
		/// click of th buttom
		/// </summary>
		void androidProcess()
		{
			theAndroidInterface.AndroidInterface.setAndroidTextView (output);
			theInput = input.Text;
			sol.setString(theInput);
			theInput = "";
			input.Text = "";
			ProcessStringObserverAndPrintExpression (sol);
		}


		/// <summary>
		///   Process for solution code.
		/// </summary>
		void ProcessStringObserverAndPrintExpression(StringObserver sol)
		{
			try
			{
				sol.Process();
			}
			catch 
			{
				TheMessageHandler.MessagePrinter.Print("Something went wrong");
			}
			try
			{
				sol.Printer();
			}
			catch
			{
				TheMessageHandler.MessagePrinter.Print("Something went wrong");
			}
		}

	}  // end class MainActivity.
}


