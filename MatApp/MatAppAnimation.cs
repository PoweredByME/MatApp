using System;
using Android.Views.Animations;
using Android.Views;

namespace MatApp
{
	public class MatAppAnimation : Animation
	{
		View view;
		int orignalHeight;
		int targetHeight;
		int growBy;

		public MatAppAnimation (View view, int targetHeight)
		{
			this.view = view;
			orignalHeight = this.view.Height;
			this.targetHeight = targetHeight;
			growBy = targetHeight - orignalHeight;
		}

		protected override void ApplyTransformation (float interpolatedTime, Transformation t)
		{
			view.LayoutParameters.Height = (int)(orignalHeight + (growBy * interpolatedTime));
			view.RequestLayout ();
		}
	}
}

