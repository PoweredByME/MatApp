using System;
using System.Collections.Generic;
using DataTypeSpace;
using StaticClasses;
using Java.Nio.Channels;
using Android.Text;
using Javax.Xml.Xpath;
using System.Text;
using Android.OS;
using MatApp;
using System.Runtime.InteropServices;

namespace EquationSolvingHead 
{
	public class MathematicalEquationSolvingHead
	{
		List<Expression> theExpressionList;
		List<string> theBatch;
		List<string> theNewBatch;
		public bool Processed{ private set; get;} = true;
		Expression Solution;
		List<Expression> theNewExpressionList;
		public Expression getSolution () => Solution;

		public MathematicalEquationSolvingHead (List<Expression> theExpressionList, List<string>theBatch)
		{
			this.theBatch = theBatch;
			this.theExpressionList = theExpressionList;
			Observe ();
		}

		void Observe()
		{
			if (!(theBatch [theBatch.Count - 1] == ")") && Checker.isBasicOperator (theBatch [theBatch.Count - 1])) {
				TheMessageHandler.MessagePrinter.Print ("Invalid operator sequence");
				Processed = false;
			} else {
				OperatorManager ();
				if (Processed) {
					bool brakets = BrakettsExistsAndThereNumber (theBatch).exist;
					TheListMaker ();
					if (!brakets) {
						EquationSolver.DMASSolver dmasSolver = new EquationSolver.DMASSolver (theNewExpressionList, theNewBatch);
						if (!dmasSolver.isProcessed ()) {
							Processed = false;
						} else {
							Solution = dmasSolver.getSolution ();	
						}
					} else if (brakets && CommandDealer ()) {
						EquationSolver.BODMASSolver bodmasSolver = new EquationSolver.BODMASSolver (theNewExpressionList, theNewBatch);
						if (bodmasSolver.isProcessed ()) {
							Solution = bodmasSolver.getSolution ();
						} else
							Processed = false;
					}
				} else {
				}
			}
		}

		bool CommandDealer()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (Checker.ifCommandExists (x)) {
					if (!(theBatch [counter + 1] == "--->>>") && (theBatch [counter + 1] == "*") ) {
						if(!Checker.isBasicOperator (theBatch[counter+2]))
						theBatch [counter + 1] = "--->>>";
					 else {
						solved = false;
						Processed = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator");
						break;
						}
					}
				}
				counter++;
			}
			return solved;
		}

		/// <summary>
		/// This function deals with the task to manage the operators in correct formate like nothing like -- can come in the 
		/// string if it happens an error will be thrown out and finish.
		/// </summary>

		void OperatorManager()
		{

			int counter = 0; 
			bool proceed = true;
			if (theBatch [0] == "+") {
				theBatch.RemoveAt (0);
			} else if (theBatch[0] == "-"){
				if (!Checker.isBasicOperator (theBatch [1])) {
					theBatch [1] = "-" + theBatch [1];
					theBatch.RemoveAt (0);
				} else {
					TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
					proceed = false;
					Processed = false;
				}
			}else if (theBatch [0] == "*" || theBatch [0] == "/") {
				TheMessageHandler.MessagePrinter.Print("Invalid Operator Sequence");
				proceed = false;
				Processed = false;
			}
			if(proceed){
			while (counter < theBatch.Count) {   // while start for minus management
				string x = theBatch [counter];  //get the respective string for the list
					if (x == "-") {               //if the string is "-" operator 
						string next = theBatch [counter + 1];    // stores the next string next ot the x string (current string)
						if (!(next == "+") && Checker.isBasicOperator (next)) {    //if the next string is not "+" and anyother operator
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;   
							break;
						} else if (next == "+") {   // if next is a "+" operator
							if (Checker.isBasicOperator (theBatch [counter + 2])) {   // if there is an operator next to the next string
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else
								theBatch.RemoveAt (counter + 1);	  //else the "+" is removed from theBatch List
						} else {        //else if there the no operator in the next then 
							theBatch [counter] = "+";     // the x string (current string) is converted to plus and 
							theBatch [counter + 1] = "-" + theBatch [counter + 1];   // then the minus operator becomes part of the vry next command.
							if (theBatch [counter - 1].TrimStart ("-".ToCharArray ()) == "(") {
								theBatch.RemoveAt (counter);
							}
						}
					} else if (x == "/") {      // if the current string is "/" operator.
						string next = theBatch [counter + 1];   // next string
						if (!(next == "-") && !(next == "+") && Checker.isBasicOperator (next)) {  // if the next is not "-" and "+" and it is an other operator
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;
							break;
						} else if (next == "+") {    // if the next is "+"
							if (Checker.isBasicOperator (theBatch [counter + 2])) {  // if next to next is operator like ++
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else
								theBatch.RemoveAt (counter + 1);   // otherwise
						} else if (next == "-") {      // if the next is "-" operator
							if (Checker.isBasicOperator (theBatch [counter + 2])) {    // there is no operator next to next like --
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch [counter + 2] = "-" + theBatch [counter + 2];   // minus sign becomes part of the string
								theBatch.RemoveAt (counter + 1);    //minus sign removed at next.
							}
						} 
					} else if (x == "*") {    // the x is the "*" operator.
						string next = theBatch [counter + 1];
						if (!(next == "-") && !(next == "+") && Checker.isBasicOperator (next)) {  // the same as with "/" case
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;
							break;
						} else if (next == "+") {    // next is "+"
							if (Checker.isBasicOperator (theBatch [counter + 2])) {
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch.RemoveAt (counter + 1);
							}
						} else if (next == "-") {    // next is "-"
							if (Checker.isBasicOperator (theBatch [counter + 2])) {
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch [counter + 2] = "-" + theBatch [counter + 2];
								theBatch.RemoveAt (counter + 1);
							}
						}
					} else if (x == "+") {       // if x is "+"
						string next = theBatch [counter + 1];
						if (!(next == "-") && Checker.isBasicOperator (next)) {  // neglect only if the next one is "-"
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;
							break;
						} else if (next == "-") {   // if the next one is "-"
							if (Checker.isBasicOperator (theBatch [counter + 2])) {
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch [counter + 2] = "-" + theBatch [counter + 2];  // modification logic 
								theBatch.RemoveAt (counter + 1);
							}
						}
					} else if (x.TrimStart ("-".ToCharArray ()) == "(") {    // if x is "(" operator
						string next = theBatch [counter + 1];
						if (!(next == "-") && !(next == "+") && Checker.isBasicOperator (next)) {  // if the next is "-" or "+"
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;
							break;
						} else if (next == "-") {  // if next is "-"
							if (Checker.isBasicOperator (theBatch [counter + 2])) {
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch [counter + 2] = "-" + theBatch [counter + 2];
								theBatch.RemoveAt (counter + 1);
							}
						} else if (next == "+") {  //if next is "+"
							if (Checker.isBasicOperator (theBatch [counter + 2])) {
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch.RemoveAt (counter + 1);
							}
						} 
					} else if (x == "^") {  //if there comes a rais to the power operator.
						string next = theBatch [counter + 1];
						if (!(next == "+") && !(next == "-") && !(next == "(") && Checker.isBasicOperator (next)) {
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;
							break;
						} else if (next == "+") {
							theBatch.RemoveAt (counter + 1);
						} else if (next == "-") {
							if (Checker.isBasicOperator (theBatch [counter + 2])) {
								TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
								Processed = false;
								break;
							} else {
								theBatch [counter + 2] = "-" + theBatch [counter + 2];
								theBatch.RemoveAt (counter + 1);
							}
						}
					} else if (x == ")") {       // logic if there is no operator after ")" operator
						if (counter + 1 != theBatch.Count && !Checker.isBasicOperator (theBatch [counter + 1]) && theBatch[counter+1] != "!") {
							theBatch.Insert (counter + 1, "*");
						}
					} else if (x == "!") {
						if (Checker.ifContainOperations (theBatch [counter - 1]) && theBatch [counter - 1] != ")") {
							TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
							Processed = false;
							break;
						} else {
							if (!(theBatch.Count <= counter + 1)) {
								string next = theBatch [counter + 1];
								if (!Checker.ifContainOperations (next) || next == "(") {
									theBatch.Insert (counter + 1, "*");	
								} else if (next == "!") {
									TheMessageHandler.MessagePrinter.Print ("Invalid Operator Sequence");
									Processed = false;
									break;
								}
							}
						}
					}
					else {     //else if the situtation like a(a) occurs it does this a*(a)
					if(counter + 1 != theBatch.Count && theBatch [counter + 1] == "(") {
						theBatch.Insert (counter + 1, "*");
					}
				}
				counter++;
			}     //while ends
		 }  //end if case for proceed.
		}    // minus manager

		bool TheListMaker()
		{
			bool solved = true;
			theNewExpressionList = new List<Expression> ();
			int counter = 0;
			theNewBatch = new List<string> ();
			foreach (string x in theBatch) {
				if (!Checker.ifCommandExists (x) && !Checker.ifContainOperations (x.TrimStart ("-".ToCharArray ()))) {
					if (x.TrimStart ("-".ToCharArray ()) == "e" && !(theBatch[theBatch.Count-1].TrimStart ("-".ToCharArray ()) == "e") && theBatch [counter + 1] == "^") {
						theNewBatch.Add (x);
						theNewExpressionList.Add (theConstantList.getConstant ("e"));
					} else if (!Checker.ifCommandExists (x) && !Checker.ifContainOperations (x.TrimStart ("-".ToCharArray ()))) {
						Expression exp = new Expression (getExpression (x.TrimStart ("-".ToCharArray ())));
						exp.setEntireTag (AutoNamer ());
						theNewExpressionList.Add (exp);
						if (x.Contains ("-"))
							theNewBatch.Add ("-" + exp.getTag ());
						else
							theNewBatch.Add (exp.getTag ());
					} else {
						theNewBatch.Add (x);
					}
				} else {
					theNewBatch.Add (x);
				}
				counter++;
			}
			return solved;
		}

		int NameCount = 0 ;

		string AutoNamer()
		{
			return ("ISAthe__Equation_Heades___SwagmaRuleScrewwitMJ" + (NameCount++) + (NameCount++) + (NameCount++));
		}
		//////////////////////////////////////////HELPER FUNCTIONS ////////////////////////////////////////

		struct BrakettCheck
		{
			public bool exist;
			public int numberOfStartBrakets;
			public int numberOfEndBrakets;
		}

		BrakettCheck BrakettsExistsAndThereNumber(List<string> TheBatch)
		{
			BrakettCheck x = new BrakettCheck ();
			x.numberOfEndBrakets = 0;
			x.numberOfStartBrakets = 0;
			x.exist = (theBatch.Contains ("(") || theBatch.Contains ("-("));
			if (x.exist) {
				foreach (string s in TheBatch) {
					if (s.TrimStart ("-".ToCharArray ()) == "(") {
						x.numberOfStartBrakets++;	
					} else if (s == ")") {
						x.numberOfEndBrakets++;
					}
				}
			} 
			if (x.numberOfEndBrakets != x.numberOfStartBrakets) {
				int d = x.numberOfStartBrakets - x.numberOfEndBrakets;
				for (int c = 0; c < d; c++) {
					theBatch.Add (")");
					x.numberOfEndBrakets++;
				}
			}
			return x;
		}


		////////////////////////Helper functions

		Expression getExpression(string tag)
		{
			Expression found = new Expression();
			foreach (Expression x in theExpressionList) {
				if (x.getTag () == tag) {
					found = x;
					break;
				}
			}
			return found;
		} 


	}  //end EquationSolvingHead 
}    //end EquationSolver

