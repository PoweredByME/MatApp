using System;
using DataTypeSpace;
using System.Collections.Generic;

namespace MatApp
{
	static public class theConstantList
	{
		static public Expression getConstant(string exp)
		{
			Expression e = new Expression();
			if (exp == "π") {
				Number x = new Number ();
				x.setNumber (Math.PI);
				x.setTag ("π");
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
				x.setNumber (6.67 * Math.Pow (10, -11));
				x.setTag ("G");
				e = new Expression (x);
			} else if (exp == "g") {
				Number x = new Number ();
				x.setNumber (9.8);
				x.setTag ("g");
				e = new Expression (x);
			} else if (exp == "mp") {
				Number x = new Number ();
				x.setNumber (1.6726219 * Math.Pow (10, -27));
				x.setTag ("mp");
				e = new Expression (x); 
			} else if (exp == "mn") {
				Number x = new Number ();
				x.setNumber (1.674929 * Math.Pow (10, -27));
				x.setTag ("mn");
				e = new Expression (x);
			} else if (exp == "me") {
				Number x = new Number ();
				x.setNumber (9.10938356 * Math.Pow (10, -31));
				x.setTag ("me");
				e = new Expression (x);
			} else if (exp == "h") {
				Number x = new Number ();
				x.setNumber (6.62607004 * Math.Pow (10, -34));
				x.setTag ("h");
				e = new Expression (x);
			} else if (exp == "Na") {
				Number x = new Number ();
				x.setNumber (6.022 * Math.Pow (10, 23));
				x.setTag ("Na");
				e = new Expression (x);
			}
				
			return e;
		}

		static public List<string> getConstantList()
		{
			List<string> theList = new List<string> ();

			theList.Add ("π");
			theList.Add ("e");
			theList.Add ("amu");
			theList.Add ("eV");
			theList.Add ("au");
			theList.Add ("g");
			theList.Add ("G"); 
			theList.Add ("h");
			theList.Add ("mass-\n  Proton");
			theList.Add ("mass-\n  Electron"); 
			theList.Add ("mass-\n  Neutron"); 
			theList.Add ("Avogadro's\n  Number"); 
			return theList;
		}

		static public List<string> getConstantListForIntelligence()
		{
			List<string> theList = new List<string> ();

			theList.Add ("π");
			theList.Add ("e");
			theList.Add ("amu");
			theList.Add ("eV");
			theList.Add ("au");
			theList.Add ("g");
			theList.Add ("G"); 
			theList.Add ("h");
			theList.Add ("mp");
			theList.Add ("me"); 
			theList.Add ("mn"); 
			theList.Add ("Na"); 
			return theList;
		}


		static public string constantInputManager(string exp)
		{
			string result = "";
			if (exp == "π") {
				result = "π";
			} else if (exp == "e") {
				result = "e";
			} else if (exp == "amu") {
				result = "amu";
			} else if (exp == "eV") {
				result = "eV";
			} else if (exp == "au") {
				result = "au";
			} else if (exp == "g") {
				result = "g";
			} else if (exp == "G") {
				result = "G";
			} else if (exp == "mass-\n  Proton") {
				result = "mp";
			} else if (exp == "mass-\n  Electron") {
				result = "me";
			} else if (exp == "mass-\n  Neutron") {
				result = "mn";
			} else if (exp == "h") {
				result = "h";
			} else if (exp == "Avogadro's\n  Number") {
				result = "Na";
			}
			return result;
		}

	}
}

