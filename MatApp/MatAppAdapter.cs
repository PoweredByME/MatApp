using System;
using Android.Widget;
using System.Collections.Generic;
using DataTypeSpace;
using Android.Content;
using System.Security.Permissions;
using Android.Views;
using Android.Sax;
using Android.Media;
using Android;
using Android.Text;
using Org.Apache.Http;
using Android.Net;
using Android.App;
using Android.Util;
using Android.OS;

namespace MatApp
{
	public class MatAppAdapter : BaseAdapter<Expression>
	{
		Context theContext;
		List<Expression> theExpressionList;
		public MatAppAdapter (Context context , List<Expression> theExpressionList)
		{
			theContext = context;
			this.theExpressionList = theExpressionList;
		}

		public override int Count {
			get {
				return theExpressionList.Count;
			}
		}

		public override Expression this[int position]
		{
			get{ return theExpressionList [position];}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			View row = convertView;
		    
			if (row == null) {
				row = LayoutInflater.From (theContext).Inflate (Resource.Layout.theMatAppAdapter, null, false);
			} 


			TableLayout theItem = row.FindViewById<TableLayout> (Resource.Id.tableLayout1);
			theItem.Focusable = false;
			theItem.FocusableInTouchMode = false;
			theItem.RemoveAllViews ();
			/// UI code for the TableLayout , theItem.

			theItem.SetPadding (1,20,20,10);
			theItem.SetHorizontalGravity (GravityFlags.Center);
			theItem.Clickable = true;
			Expression CurrentExpression = theExpressionList [position];

			TextView theStatement = StyleCSCode.MatAppStyleCSCode.StyledTextView (theContext);//Text view to print the give Statement of the Expression.
			theStatement.Text = "Statement : \t\t\t" + CurrentExpression.getStatement () + "\t\t\t";
			theStatement.SetTextSize (ComplexUnitType.Dip, 12);
			theStatement.TextAlignment = TextAlignment.TextEnd;
			theItem.AddView (theStatement);

			if (CurrentExpression.getExpType () == 2) {
				var text = StyleCSCode.MatAppStyleCSCode.StyledTextView (theContext);//new TextView (theContext);
				text.Text = $"{CurrentExpression.getTag()} = {(CurrentExpression.getNumber().getNumber())}";
				theItem.AddView (text);

			}

			if (CurrentExpression.getExpType () == 1) {


				Matrix theMatrix = CurrentExpression.getMatrix ();
				var theMatrixTag = StyleCSCode.MatAppStyleCSCode.StyledTextView (theContext);//new TextView (theContext);
				theMatrixTag.SetTypeface (Android.Graphics.Typeface.Serif,Android.Graphics.TypefaceStyle.Normal);

				theMatrixTag.Text = $"{theMatrix.getTag()} = ";
				theItem.AddView (theMatrixTag);
				for (int c = 1; c <= theMatrix.getRows (); c++) { 
					var theText = StyleCSCode.MatAppStyleCSCode.StyledTextView (theContext);//new TextView (theContext); 
					theText.TextAlignment = TextAlignment.Center;
					theText.Text = "";
					string theString = "\t\t\t";
					for (int c1 = 1; c1 <= theMatrix.getColumns (); c1++) {
						theString += "\t\t\t" + Math.Round(theMatrix.getElement (c, c1), 6); 
					}
					theString += "\t\t\t\t\t\t";
					theText.Text = theString;
					theItem.AddView (theText);
				}
			}
			return row;
		}

	}   //end class
}    // end namespace

