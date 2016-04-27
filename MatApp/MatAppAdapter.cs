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
			theItem.RemoveAllViews ();
			Expression CurrentExpression = theExpressionList [position];
			if (CurrentExpression.getExpType () == 2) {
				var text = new TextView (theContext);
				text.Text = $"{CurrentExpression.getTag()} = {CurrentExpression.getNumber().getNumber()}";
				theItem.AddView (text);
			}

			if (CurrentExpression.getExpType () == 1) {
				Matrix theMatrix = CurrentExpression.getMatrix ();
				var theMatrixTag = new TextView (theContext);
				theMatrixTag.Text = $"{theMatrix.getTag()} = ";
				theItem.AddView (theMatrixTag);
				for (int c = 1; c <= theMatrix.getRows (); c++) { 
					var theText = new TextView (theContext); 
					theText.TextAlignment = TextAlignment.Center;
					theText.Text = "";
					for (int c1 = 1; c1 <= theMatrix.getColumns (); c1++) {
						theText.Text += "      " + theMatrix.getElement (c, c1); 
					}
					theItem.AddView (theText);
				}
			}
			return row;
		}

	}   //end class
}    // end namespace

