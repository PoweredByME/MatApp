using Android.App;
using Android.Widget;
using Android.OS;
using StringWatch;
using System;
using System.Collections.Generic;
using Android.Views;
using theAndroidInterface;
using virtualUnderstander;
using Android.InputMethodServices;
using Android.Graphics.Drawables;
using System.Runtime.Serialization.Formatters;
using Android.Graphics;
using Android.Util;
using Android.Content.Res;
using System.Runtime.InteropServices;
using Android.Views.InputMethods;
using Android.Content;
using CommandUnderstander;
using Javax.Microedition.Khronos.Opengles;
using System.Text;

namespace MatApp
{
	[Activity (Label = "MatApp",ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true, Icon = "@mipmap/ic_launcher")]
	public class MainActivity : Activity
	{

		Button enterSolve, enterClear, ShowVariable, ShowPrefix, ShowConstants, ShowFunctions, ShowMatrixFunctions, ShowVectorFunction;
		EditText theStringInput;
		TextView theReportMessageView;
		ListView theSolutionOutput, theVariableList;
		Button plus, minus, divide, multiply, smallBraketStart, smallBraketEnd, cleanInput, power;
		Button squareBraketStart, squareBraketEnd, semiColon, factorial;
		StringObserver sol;
		string theInput;
		VariableListAdapter theVariableAdapter;
		bool variable, prefix, constants, functions, matfunctions;
		List<string>thePrefixList = pUnderstander.getPrefixList ();
		List<string>theConstantList = MatApp.theConstantList.getConstantList ();
		List<string>theSimpleFunctionList = cUnderstander.getFunctionList ();
		List<string>theMatrixFunctions = cUnderstander.getMatrixFunctionList ();
		List<string>theMatrixFunctionListForIntelligence = cUnderstander.IntelligenceMatricFunctionList ();
		LinearLayout theSolutionListLayout;


		void androidSetup()
		{
			enterSolve = FindViewById<Button> (Resource.Id.Solve);
			enterClear = FindViewById<Button> (Resource.Id.Clear);
			plus = FindViewById<Button> (Resource.Id.plus);
			minus = FindViewById<Button> (Resource.Id.minus);
			multiply = FindViewById<Button> (Resource.Id.multiply);
			divide = FindViewById<Button> (Resource.Id.divide);
			semiColon = FindViewById<Button> (Resource.Id.SemiColon);
			smallBraketEnd = FindViewById<Button> (Resource.Id.smallBraketEnd);
			smallBraketStart = FindViewById<Button> (Resource.Id.smallBrakettStart);
			squareBraketEnd = FindViewById<Button> (Resource.Id.squareBraketEnd);
			squareBraketStart = FindViewById<Button> (Resource.Id.squareBraketStart);
			cleanInput = FindViewById<Button> (Resource.Id.CleanInput);
			theVariableList = FindViewById<ListView> (Resource.Id.theVariableList);
			ShowVariable = FindViewById<Button> (Resource.Id.ShowVariables);
			ShowConstants = FindViewById<Button> (Resource.Id.ShowConstant);
			ShowPrefix = FindViewById<Button> (Resource.Id.ShowPrefix);
			ShowFunctions = FindViewById<Button> (Resource.Id.ShowFunctions);
			ShowMatrixFunctions = FindViewById<Button> (Resource.Id.ShowMatrixFunction);
			theReportMessageView = FindViewById<TextView> (Resource.Id.ReportMessageView);
			theSolutionListLayout = FindViewById<LinearLayout> (Resource.Id.ListLayout);
			power = FindViewById<Button> (Resource.Id.Power);
			factorial = FindViewById<Button> (Resource.Id.Factorial);
			theStringInput = FindViewById<EditText> (Resource.Id.theInput);
			theSolutionOutput = FindViewById<ListView> (Resource.Id.theOutputList);
			ShowVectorFunction = FindViewById<Button> (Resource.Id.ShowVectorFunction);
			theSolutionOutput.Alpha = 0;

			theStringInput.ClearFocus ();
			AndroidInterface.theListLayout = theSolutionListLayout;
			AndroidInterface.theMessageOutputFeild = theReportMessageView;
			AndroidInterface.OutputListView = theSolutionOutput;
			AndroidInterface.theContext = this;


			sol = new StringObserver ();
			theVariableAdapter = new VariableListAdapter(this, theSimpleFunctionList);
			theVariableList.Adapter = theVariableAdapter;

			theInput = string.Empty;
			theVariableList.Clickable = true;
			theVariableList.Divider = null;

			variable = false ; prefix = false; constants = false; functions = true;
			matfunctions = false;

			androidSideBarButtonAction ();


			ShowVectorFunction.Visibility = Android.Views.ViewStates.Gone;

		}



	    protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			ActionBar.Hide ();
			this.Window.ClearFlags(WindowManagerFlags.Fullscreen); //to hide
			SetContentView (Resource.Layout.Main);
		    androidSetup ();


			enterSolve.Click += (object sender, EventArgs e) => 
			{
				androidMatAppProcess ();
			};

			enterClear.Click += (object sender, EventArgs e) => 
			{
				sol.resetExpressionList ();
				sol = new StringObserver();
				AndroidInterface.resetTheDisplayList ();
				sol.theVariableList = new List<string>();
				theStringInput.Text = "";
				theVariableAdapter = new VariableListAdapter(this, sol.theVariableList);
				theVariableList.Adapter = theVariableAdapter;
				if(prefix)
				{
					theVariableAdapter = new VariableListAdapter(this, thePrefixList);
					theVariableList.Adapter = theVariableAdapter;
				}
				if(constants)
				{
					theVariableAdapter = new VariableListAdapter(this, theConstantList);
					theVariableList.Adapter = theVariableAdapter;
				}
				if(functions)
				{
					theVariableAdapter = new VariableListAdapter(this, theSimpleFunctionList);
					theVariableList.Adapter = theVariableAdapter;
				}
				if(matfunctions)
				{
					theVariableAdapter = new VariableListAdapter(this, theMatrixFunctions);
					theVariableList.Adapter = theVariableAdapter;
				}

			};

			plus.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"+");
                theStringInput.SetSelection (pos+1);              
			};

			minus.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"-");
				theStringInput.SetSelection (pos+1);
			};

			multiply.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"*");
				theStringInput.SetSelection (pos+1);
			};

			divide.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"/");
				theStringInput.SetSelection (pos+1);
			};

			power.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"^(");
				theStringInput.SetSelection (pos+2);
			};
			semiColon.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,";");
				theStringInput.SetSelection (pos+1);
			};

			smallBraketEnd.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,")");
				theStringInput.SetSelection (pos+1);
			};

			factorial.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"!");
				theStringInput.SetSelection (pos+1);
			};

			smallBraketStart.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"(");
				theStringInput.SetSelection (pos+1);
			};

			squareBraketEnd.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"]");
				theStringInput.SetSelection (pos+1);
			};

			squareBraketStart.Click += (object sender, EventArgs e) => 
			{
				int pos = theStringInput.SelectionStart;
				theStringInput.Text = theStringInput.Text.Insert (theStringInput.SelectionStart,"[");
				theStringInput.SetSelection (pos+1);
			};

			cleanInput.Click += (object sender, EventArgs e) => 
			{
				theStringInput.Text = "";
			};

			theVariableList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => 
			{
				string toBeAdded = string.Empty;
				if(variable){
				toBeAdded =  (sol.theVariableList[e.Position]);
				}else if (prefix){
				toBeAdded = (thePrefixList[e.Position]);
			    }else if(constants){
				toBeAdded = (theConstantList[e.Position]);
			    toBeAdded = MatApp.theConstantList.constantInputManager (toBeAdded); 
			    }else if(functions){
					toBeAdded = theSimpleFunctionList[e.Position];	
				}else if(matfunctions){
					toBeAdded = theMatrixFunctions[e.Position];
					toBeAdded = cUnderstander.matrixFunctionInputManager (toBeAdded);
				}
				int pos = theStringInput.SelectionStart;

				string theIn = theStringInput.Text;
				if(!string.IsNullOrWhiteSpace (theIn) && theIn.Length != theStringInput.SelectionStart){
					theIn = theIn.Remove (theStringInput.SelectionStart);
				}
				MatappAI.InputIntelligence intel = new MatappAI.InputIntelligence(theIn, toBeAdded);
				intel.constants = MatApp.theConstantList.getConstantListForIntelligence ();
				intel.variables = sol.theVariableList;
				intel.prefix = thePrefixList;
				intel.function = theSimpleFunctionList;
				intel.matfunctions = theMatrixFunctionListForIntelligence;
				intel.Process ();
				string r = intel.getResult ();
				theStringInput.Text = theStringInput.Text.Insert (pos, r);
				theStringInput.SetSelection (pos+r.Length);
			};


			ShowVariable.Click += (object sender, EventArgs e) => 
			{
				variable = true; constants = false; prefix = false; functions = false;
				matfunctions = false;  //
				if(theStringInput.Text == ""){
					theStringInput.Hint = "ƒ(x)";
				}
				androidSideBarButtonAction ();
				theVariableAdapter = new VariableListAdapter(this, sol.theVariableList);
				theVariableList.Adapter = theVariableAdapter;
			};

			ShowPrefix.Click += (object sender, EventArgs e) => 
			{
				variable = false; constants = false; prefix = true; functions = false;
				matfunctions = false;
				if(theStringInput.Text == ""){
					theStringInput.Hint = "ƒ(x)";
				}
				androidSideBarButtonAction ();
				theVariableAdapter = new VariableListAdapter(this, thePrefixList);
				theVariableList.Adapter = theVariableAdapter;
			};

			ShowConstants.Click += (object sender, EventArgs e) => 
			{
				variable = false; constants = true; prefix = false; functions = false;
				matfunctions = false;
				if(theStringInput.Text == ""){
					theStringInput.Hint = "ƒ(x)";
				}
				androidSideBarButtonAction ();
				theVariableAdapter = new VariableListAdapter(this, theConstantList);
				theVariableList.Adapter = theVariableAdapter;
			};

		    ShowFunctions.Click += (object sender, EventArgs e) => 
			{
				variable = false; constants = false; prefix = false; functions = true;
				matfunctions = false;
				if(theStringInput.Text == ""){
					theStringInput.Hint = "ƒ(x)";
				}
				androidSideBarButtonAction ();
				theVariableAdapter = new VariableListAdapter(this, theSimpleFunctionList);
				theVariableList.Adapter = theVariableAdapter;
			};

			ShowMatrixFunctions.Click += (object sender, EventArgs e) => 
			{
				variable = false; constants = false; prefix = false; functions = false;
				matfunctions = true;
				if(theStringInput.Text == ""){
					theStringInput.Hint = "[ 3 3 ; 3 3] a 2x2 matrix";
				}
				androidSideBarButtonAction ();
				theVariableAdapter = new VariableListAdapter(this, theMatrixFunctions);
				theVariableList.Adapter = theVariableAdapter;
			};


			theStringInput.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => 
			{
				if(theSolutionOutput.Alpha == 0 && theReportMessageView.Alpha == 1){
				theSolutionOutput.Animate ().AlphaBy (1.0f).SetDuration (500).Start ();
				theReportMessageView.Animate ().AlphaBy (-1.0f).SetDuration (500).Start ();
				}
		
			};

		}// end method on create

		void androidSideBarButtonAction()
		{
			if (variable) {
				ShowVariable.SetTextColor (new Color (106, 106, 106, 255));
				ShowVariable.SetBackgroundColor (new Color (203, 203, 203, 255));
			} else if(!variable){
				ShowVariable.SetBackgroundColor (Android.Graphics.Color.Transparent);//new Color (126, 126, 126, 255));
				ShowVariable.SetTextColor (new Color (213, 213, 213, 255));
			}
			if (prefix) {
				ShowPrefix.SetTextColor (new Color (106, 106, 106, 255));
				ShowPrefix.SetBackgroundColor (new Color (203, 203, 203, 255));
			} else if(!prefix){
				ShowPrefix.SetBackgroundColor (Android.Graphics.Color.Transparent);//new Color (106, 106, 106, 255));
				ShowPrefix.SetTextColor (new Color (213, 213, 213, 255));
			}
			if (constants) {
				ShowConstants.SetTextColor (new Color (106, 106, 106, 255));
				ShowConstants.SetBackgroundColor (new Color (193, 193, 193, 255));
			} else if(!constants){
				ShowConstants.SetBackgroundColor (Android.Graphics.Color.Transparent);//new Color (126, 126, 126, 255));
				ShowConstants.SetTextColor (new Color (213, 213, 213, 255));
			}if (functions) {
				ShowFunctions.SetTextColor (new Color (106, 106, 106, 255));
				ShowFunctions.SetBackgroundColor (new Color (203, 203, 203, 255));
			} else if(!functions){
				ShowFunctions.SetBackgroundColor (Android.Graphics.Color.Transparent);//new Color (126, 126, 126, 255));
				ShowFunctions.SetTextColor (new Color (213, 213, 213, 255));
			}
			if (matfunctions) {
				ShowMatrixFunctions.SetTextColor (new Color (106, 106, 106, 255));
				ShowMatrixFunctions.SetBackgroundColor (new Color (203, 203, 203, 255));
			} else if(!matfunctions){
				ShowMatrixFunctions.SetBackgroundColor (Android.Graphics.Color.Transparent);//new Color (126, 126, 126, 255));
				ShowMatrixFunctions.SetTextColor (new Color (213, 213, 213, 255));
			}

		}


		void androidMatAppProcess()
		{
			theInput = theStringInput.Text;
			sol.setString(theInput);
			ProcessStringObserverAndPrintExpression (sol);
		}



		void ProcessStringObserverAndPrintExpression(StringObserver sol)
		{
			try{
			sol.Process();
			}catch {
			TheMessageHandler.MessagePrinter.Print("Invalid Formate");
			}
			try
			{
			sol.Printer();
				if(sol.isExpressionPrinted ()){
				if(variable){
				    theVariableAdapter = new VariableListAdapter (this, sol.theVariableList);
					theVariableList.Adapter = theVariableAdapter;
				}
				if(theSolutionOutput.Alpha == 0 && theReportMessageView.Alpha == 1){
					theSolutionOutput.Animate ().AlphaBy (1.0f).SetDuration (500).Start ();
					theReportMessageView.Animate ().AlphaBy (-1.0f).SetDuration (500).Start ();
					}
				}
			}catch{}
		}	


	}  // end class MainActivity.
}