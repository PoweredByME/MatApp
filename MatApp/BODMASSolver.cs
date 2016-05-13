using System;
using System.Collections.Generic;
using DataTypeSpace;
using allSolverInterface;

/// <summary>
/// BODMAS solver.
/// This code deals with the brakets and their precidence in BODMAS
/// It extracts the priority string and then 
/// sends ot to DMASSolver for further calculation.
/// </summary>
using Org.Apache.Http;
using Android.Util;
using Android.Provider;
using StaticClasses;
using Java.Security;
using Android.Nfc.CardEmulators;
using Java.Awt.Font;


namespace EquationSolver
{
	public class BODMASSolver : Solver
	{

		private bool Processed = true;
		public bool isProcessed() => Processed;
		Expression solution;
		public Expression getSolution() => solution;


		List <string> theBatch;
		List <Expression> theExpressionList;
		public BODMASSolver (List<Expression> theiExpressionList, List<string> theBatch)
		{
			Processed = true;
			this.theBatch = theBatch;
			CommandDealer ();
			theExpressionList = theiExpressionList;
			Observe();
		}

		void Observe()
		{
				if (theBatch.Contains ("(") || theBatch.Contains ("-(") ) {
					BracketSolver ();
				}
				if (Processed) {
					DMASSolver SOL = new DMASSolver (theExpressionList, theBatch);
					if (SOL.isProcessed ()) {
						solution = SOL.getSolution ();
					} else {
						Processed = false;
					}
				}
			
		}

		// this function deals with the brakkets.

		void BracketSolver()
		{
			List<string> theKeep = new List<string> ();
			int counter = 0;
			bool insert = false;
			int startPos = 0;
			while (counter < theBatch.Count) {
				if (!theBatch.Contains ("(") && !theBatch.Contains ("-("))
					break;
				string x = theBatch [counter];
				if (x == ")") {
					insert = false;
					int range = theKeep.Count;
					List<Expression> theNewExpressionList = new List<Expression> ();
					foreach (Expression exp in theExpressionList) {
						Expression e = new Expression (exp);
						theNewExpressionList.Add(e);
					}
					DMASSolver sol = new DMASSolver (theNewExpressionList, theKeep);
					if (sol.isProcessed ()) {
						Expression newOne = new Expression (sol.getSolution ());
						if (theBatch [startPos].Contains ("-")) {
							if (newOne.getExpType () == 1) {
								Matrix theMat = new Matrix (newOne.getMatrix ());
								theMat = theMat * -1;
								newOne = new Expression (theMat);
							} else if (newOne.getExpType () == 2){
								Number theNum = new Number ();
								theNum.setNumber (newOne.getNumber ().getNumber () * -1);
								newOne = new Expression (theNum);
							}
						}
						newOne.setEntireTag (autoNamer ());
						theExpressionList.Add (newOne);
						theBatch [startPos] = newOne.getTag ();
						theBatch.RemoveRange (startPos + 1, range+1);
					} else {
						Processed = false;
						break;
					}
					counter = 0;
					continue;
				}
				if (insert) {
					theKeep.Add (x);
				}
				if (x.TrimStart ("-".ToCharArray ()) == "(") {
					theKeep = new List<string> ();
					startPos = counter;
					insert = true;
				}

				counter++;

			}
		}


		/// command dealer///

		bool CommandDealer()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (Checker.ifCommandExists (x)) {
					if (!(theBatch [counter + 1] == "--->>>") && (theBatch [counter + 1] == "*") && !Checker.isBasicOperator (theBatch[counter+2])) {
						theBatch [counter + 1] = "--->>>";
					} else {
						solved = false;
						Processed = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator");
						break;
					}
				}
				counter++;
			}
			return solved;
		}

		////////////HELPER FUNCTIONS //////////////

	    int SNACount = 0;
		string autoNamer()
		{
			SNACount++;
			return ("BODMASSSOLUTION>>><<<<<!!!!!" + SNACount + "__" + SNACount); 
		}
		void PrintExpressionListDebug()
		{
			foreach (Expression x in theExpressionList) {
				ExpressionPrinter x1 = new ExpressionPrinter (x);
				x1.Print ();
			}
		}

		void PrintBatchDebug()
		{
			foreach (string x in theBatch) {
				Console.WriteLine (x);
			}
		}

		void morePrintBatchDebug(List<string>theBatch)
		{
			foreach (string x in theBatch) {
				Console.WriteLine (x);
			}
		}


	}    //end class BODMASSolver
}    //end namespace equation Solver

