using System;
using System.Collections.Generic;
using MatApp;
using StaticClasses;
using System.Runtime.Remoting.Messaging;
using Android.OS;

namespace MatappAI
{
	public class InputIntelligence
	{
		public List<string> constants;
		public List<string> variables;
		public List<string> prefix;
		public List<string> function;
		public List<string> matfunctions;
	    string theExpression, toBeAdded;
		string Result;
		public string getResult() => Result;
		public InputIntelligence (string exp, string tobeAdded)
		{
			theExpression = exp.Trim ();
			toBeAdded = tobeAdded.Trim ();
		}

		public void Process () => Observe ();
		void Observe()
		{
			if (constants.Contains (toBeAdded) || variables.Contains (toBeAdded) || prefix.Contains (toBeAdded) || function.Contains (toBeAdded) || matfunctions.Contains (toBeAdded)) {
				if (string.IsNullOrWhiteSpace (theExpression)) {
					if (function.Contains (toBeAdded)) {
						Result = "" + toBeAdded + "("; 
					}else if (matfunctions.Contains (toBeAdded)) {
						Result = "" + toBeAdded + "("; 
					} else {
						Result = "" + toBeAdded;
					}
				} else if (!(Checker.isOperation (theExpression [theExpression.Length - 1])) && !(theExpression [theExpression.Length - 1] == '=') && !function.Contains (toBeAdded) && !matfunctions.Contains (toBeAdded)) {
					Result = "*" + toBeAdded;
				} else if (!(Checker.isOperation (theExpression [theExpression.Length - 1])) && !(theExpression [theExpression.Length - 1] == '=') && function.Contains (toBeAdded)) {
					Result =  "*" + toBeAdded + "(";
				} else if ((Checker.isOperation (theExpression [theExpression.Length - 1]) || theExpression [theExpression.Length - 1] == '=') && function.Contains (toBeAdded)) {
					Result = toBeAdded + "(";
				}else if (!(Checker.isOperation (theExpression [theExpression.Length - 1])) && !(theExpression [theExpression.Length - 1] == '=') && matfunctions.Contains (toBeAdded)) {
					Result = "*" + toBeAdded + "(";
				} else if ((Checker.isOperation (theExpression [theExpression.Length - 1]) || theExpression [theExpression.Length - 1] == '=') && matfunctions.Contains (toBeAdded)) {
					Result =  toBeAdded + "(";
				}
				else {
					Result =  toBeAdded;
				}
				if (toBeAdded == "^(2)") {
					Result = toBeAdded;
				}
			}
		}		
     }
}
