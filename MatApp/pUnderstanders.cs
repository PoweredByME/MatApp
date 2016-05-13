using System;
using DataTypeSpace;
using System.Xml.Serialization;
using Java.Security;
using Javax.Crypto;
using Android.Nfc.CardEmulators;
using System.Collections.Generic;

namespace MatApp
{
	public static class pUnderstander
	{
		public static Expression prefixList(string exp)
		{
			Number ans = new Number ();

			if (exp == "zepto") {
				ans.setNumber (Math.Pow (10, -21));
				ans.setTag ("zepto");
			} else if (exp == "yocto") {
				ans.setNumber (Math.Pow (10, -24));
				ans.setTag ("yocto");
			} else if (exp == "atto") {
				ans.setNumber (Math.Pow (10, -18));
				ans.setTag ("atto");
			} else if (exp == "femto") {
				ans.setNumber (Math.Pow (10, -15));
				ans.setTag ("femto");
			} else if (exp == "pico") {
				ans.setNumber (Math.Pow (10, -12));
				ans.setTag ("pico");
			} else if (exp == "nano") {
				ans.setNumber (Math.Pow (10, -9));
				ans.setTag ("nano");
			} else if (exp == "micro") {
				ans.setNumber (Math.Pow (10, -6));
				ans.setTag ("micro");
			} else if (exp == "milli") {
				ans.setNumber (Math.Pow (10, -3));
				ans.setTag ("milli");
			} else if (exp == "centi") {
				ans.setNumber (Math.Pow (10, -2));
				ans.setTag ("centi");
			} else if (exp == "deci") {
				ans.setNumber (Math.Pow (10, -1));
				ans.setTag ("deci");
			} else if (exp == "deca") {
				ans.setNumber (Math.Pow (10, 1));
				ans.setTag ("deca");
			} else if (exp == "hecto") {
				ans.setNumber (Math.Pow (10, 2));
				ans.setTag ("hecto");
			} else if (exp == "kilo") {
				ans.setNumber (1000);
				ans.setTag ("kilo");
			} else if (exp == "mega") {
				ans.setNumber (Math.Pow (10, 6));
				ans.setTag ("mega");
			} else if (exp == "giga") {
				ans.setNumber (Math.Pow (10, 9));
				ans.setTag ("giga");
			} else if (exp == "tera") {
				ans.setNumber (Math.Pow (10, 12));
				ans.setTag ("tera");
			} else if (exp == "peta") {
				ans.setNumber (Math.Pow (10, 15));
				ans.setTag ("peta");
			} else if (exp == "exa") {
				ans.setNumber (Math.Pow (10, 18));
				ans.setTag ("exa");
			} else if (exp == "zepta") {
				ans.setNumber (Math.Pow (10, 21));
				ans.setTag ("zepta");
			} else if (exp == "yotta") {
				ans.setNumber (Math.Pow (10, 24));
				ans.setTag ("yotta");
			} else if (exp == "eV") {
				ans.setNumber (1.60217733 * Math.Pow (10, -19));
				ans.setTag ("eV");
			} else if (exp == "amu") {
				ans.setNumber (1.6605402 * Math.Pow (10, -27));
				ans.setTag ("amu");
			} else if (exp == "au") {
				ans.setNumber (1.49597870 * Math.Pow (10, 11));
				ans.setTag ("au");
			} else if (exp == "angstrom") {
				ans.setNumber (Math.Pow (10,-10));
				ans.setTag ("angstrom");
			}


			Expression sol = new Expression (ans);
			return sol;
		}

		public static List<string> getPrefixList(){
			List<string> theList = new List<string> ();
			theList.Add ("10^(");
			theList.Add ("zepto");
			theList.Add ("yocto");
			theList.Add ("atto");
			theList.Add ("femto");
			theList.Add ("angstrom");
			theList.Add ("pico");
			theList.Add ("nano");
			theList.Add ("micro");
			theList.Add ("milli");
			theList.Add ("centi");
			theList.Add ("deci");
			theList.Add ("deca");
			theList.Add ("hecto");
			theList.Add ("kilo");
			theList.Add ("mega");
			theList.Add ("giga");
			theList.Add ("tera");
			theList.Add ("peta");
			theList.Add ("exa");
			theList.Add ("zepta");
			theList.Add ("yotta");
			return theList;
		}
	}
}

