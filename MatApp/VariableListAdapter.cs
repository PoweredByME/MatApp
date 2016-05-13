using System;
using Android.Widget;
using Android.Content;
using Java.IO;
using System.Collections.Generic;
using System.Security.Permissions;
using Android.Views;
using Java.Util.Zip;
using Org.Apache.Http.Util;

namespace MatApp
{
	public class VariableListAdapter: BaseAdapter<string>
	{
		private Context context;
		private List<string> theVariableList;
		public VariableListAdapter (Context context, List<string> theVariableList)
		{
			this.context = context;
			this.theVariableList = theVariableList;
		}
			

		public override string this[int index] {
			get {
				return (theVariableList [index]);
			}
		}

		public override int Count {
			get {
				return (theVariableList.Count);
			}
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			View row = convertView;
			if (row == null) {
				row = LayoutInflater.From (context).Inflate (Resource.Layout.theVariablelListAddapter,null, false);
			}
			var theText = row.FindViewById<TextView> (Resource.Id.theVariableItem);
		//	var Scoll = new Scroller(context);
			theText.SetBackgroundColor (Android.Graphics.Color.Transparent);
			theText.SetTextColor (Android.Graphics.Color.Black);
			//theText.SetSingleLine ();
			theText.SetHorizontallyScrolling (true);
			theText.SetTextSize (Android.Util.ComplexUnitType.Dip, 15);
			theText.Text = (theVariableList[position] == "angstrom"? " " : "  ") + theVariableList [position];
			return row;
		}
	}
}

