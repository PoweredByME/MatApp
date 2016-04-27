using Android.App;
using Android.Widget;
using Android.OS;
using StringWatch;
using System;
using System.Collections.Generic;
using Android.Views;
using theAndroidInterface;
using virtualUnderstander;

namespace MatApp
{
	[Activity (Label = "MatApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Button enterSolve;
		EditText theStringInput;
	 	TextView theErrorOutput;
		ListView theSolutionOutput;

		StringObserver sol;
		string theInput;

		void androidSetup()
		{
			enterSolve = FindViewById<Button> (Resource.Id.enterSolve);
			theStringInput = FindViewById<EditText> (Resource.Id.TheInput);
			theErrorOutput = FindViewById<TextView> (Resource.Id.theErrorOutput);
			theSolutionOutput = FindViewById<ListView> (Resource.Id.OutputListView);
			AndroidInterface.OutputListView = theSolutionOutput;
			AndroidInterface.theContext = this;
			theErrorOutput.Text = "Welcome!";
			sol = new StringObserver();
			sol.messageOnSolved = "Success";
			vUnderstander.messageOnFound = "Found";
			theInput = string.Empty;
		}



		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);
			androidSetup ();

			enterSolve.Click += (object sender, EventArgs e) =>  
			{
				androidMatAppProcess ();
			};

		}    // end method on create


		/// <summary>
		/// Androids the process. 
		/// the Process that happens on the 
		/// click of th buttom
		/// IT send the input to the control of the app
		/// </summary>
	
		void androidMatAppProcess()
		{
			AndroidInterface.theMessageOutputFeild = theErrorOutput;
			theInput = theStringInput.Text;
			theStringInput.Text = "";
			sol.setString(theInput);
			ProcessStringObserverAndPrintExpression (sol);
		}


		/// <summary>
		///   Process for solution code.
		/// </summary>

		void ProcessStringObserverAndPrintExpression(StringObserver sol)
		{
			//try{
				sol.Process();
			//}catch {
			//	TheMessageHandler.MessagePrinter.Print("Invalid Formate");
			//}
			//try
			//{
				sol.Printer();
			//}catch{}

			
		}

	}  // end class MainActivity.
}


