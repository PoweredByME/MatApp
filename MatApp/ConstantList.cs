using System;
using DataTypeSpace;
using Android.InputMethodServices;

namespace MatApp
{
	static public class theConstantList
	{
		static public Expression getConstant(string exp)
		{
			Expression e = new Expression();
			if (exp == "pi") {
				Number x = new Number ();
				x.setNumber (Math.PI);
				x.setTag ("pi");
			    e = new Expression (x);
			} else if (exp == "e") {
				Number x = new Number ();
				x.setNumber (Math.E);
				x.setTag ("e");
			    e = new Expression (x);
			}

			return e;
		}
	}
}

