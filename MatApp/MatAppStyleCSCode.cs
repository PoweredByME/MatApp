using System;
using Android.Widget;
using Android.Content;
using MatApp;
using Android.Graphics;
using Android.Util;
using Android.Text;
using Android.Text.Style;
using System.Text;
using Android.Graphics.Drawables;

namespace StyleCSCode
{
	public static class MatAppStyleCSCode
	{
		static public TextView StyledTextView(Context context)
		{
			TextView theText = new TextView (context);
			theText.SetTextSize (ComplexUnitType.Dip, 17);
			theText.SetPadding (10,10,10,10);
			theText.SetTypeface (Typeface.Serif,TypefaceStyle.Normal);
			theText.SetBackgroundColor(Android.Graphics.Color.Transparent);
			theText.SetTextColor (new Color (82, 82 , 82 , 255));
			theText.SetMinHeight (16);
			theText.Focusable = false;
			theText.FocusableInTouchMode = false;
			theText.Clickable = true;
			return theText;	
        }
	}
}

