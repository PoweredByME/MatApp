using System;
using DataTypeSpace;
using Android.InputMethodServices;
using System.Collections.Generic;
using Android.Nfc.Tech;
//using Java.Lang;
using Android.Util;

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
			} else if (exp == "numAddIdentity") {
				Number x = new Number ();
				x.setNumber (0);
				x.setTag ("numAddIdentity");
				e = new Expression (x);
			} else if (exp == "numMultIdentity") {
				Number x = new Number ();
				x.setNumber (1);
				x.setTag ("numMultIdentity");
				e = new Expression (x);
			} else if (exp == "G") {
				Number x = new Number ();
				x.setNumber (6.67*Math.Pow (10, -11));
				x.setTag ("G");
				e = new Expression (x);
			}else if(exp == "g"){
				Number x = new Number();
				x.setNumber (9.8);
				x.setTag ("g");
				e = new Expression (x);
			}
				
			return e;
		}

		static public List<string> getConstantList()
		{
			List<string> theList = new List<string> ();

			theList.Add ("pi");
			theList.Add ("e");
			theList.Add ("amu");
			theList.Add ("eV");
			theList.Add ("au");
			theList.Add ("g");
			theList.Add ("G"); 
			return theList;
		}
	}
}

