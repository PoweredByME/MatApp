﻿using System;
using System.Collections.Generic;
using DataTypeSpace;
using StaticClasses;
/// <summary>
/// Equation watch.
/// this is the main head were all equation solving is managed. 
/// here the string comes and is looked upon and the expression list here contains only those 
/// variables which are needed for the solving and the unnamed numbers and matrics 
/// are auto named and stored and are further sent for processing.
/// </summary>
using Java.Security;
using System.Runtime.InteropServices;
using MatApp;
using Android.Util;
using Android.Database;
using System.Text;
using Java.Text;
using allSolverInterface;



namespace EquationHead
{
	public class EquationWatch : Solver 
	{
		List<Expression>theExpressionList;
		List<Expression>theInputExpressionList;  
		List<string> theBatch;     // THIS CONTAINS THE EQUATION UNDERSTANDABLE FORMATE OF THE GIVEN EXPRESSION
		string givenExpression;
		bool Processed = true;
		Expression Solution;

		public Expression getSolution () => Solution;

		public bool isProcessed () => Processed;

		public EquationWatch(){}
		public EquationWatch (List<Expression>theExpList, string exp)
		{
			givenExpression = exp.Trim();
			theBatch = new List<string> ();
			theExpressionList = new List<DataTypeSpace.Expression> ();
			theInputExpressionList = theExpList;
			ProcessEquation ();
		}

		void ProcessEquation()
		{
			ProcessString ();    //string gets processed in to command like codes stored into the theBatch List
			EquationManager ();    // this function extracts and makes the requied variable and stores them into theExpressionList.
			if(Processed)
			EquationSolution();
		}


		/// <summary>
		/// This function processes the given String into understandable equation solving formatte.
		/// </summary>

		void  ProcessString()
		{
			bool matrix = false;
			string dumy = "";
			foreach (char c in givenExpression) {   //logic to make the theBatch list
				if (c == '[') {
					matrix = true;
				}

				if ( !matrix && Checker.isOperation (c)) {
					if (c == '[') {
						matrix = true;
					}

					if (!matrix && !string.IsNullOrWhiteSpace (dumy)) {
						dumy = dumy.Trim ();
						theBatch.Add (dumy);
						theBatch.Add (c.ToString ());
						if (c == '*' && StaticClasses.Checker.ifCommandExists (theBatch [theBatch.IndexOf (c.ToString ()) - 1])) {
							Processed = false;
							TheMessageHandler.MessagePrinter.Print ("Invalid operator sequence");
							break;
						}
						dumy = "";
					}

					else {
						theBatch.Add (c.ToString ());
						dumy = "";
					}


					if (c == ']') {
						matrix = false;
					}

				} else {
					dumy += c.ToString ();
				}

				if (c == ']') {
					matrix = false;
				}

			}    //end foreach for thebatch making.
			if (!string.IsNullOrWhiteSpace (dumy)) {
				dumy = dumy.Trim ();
				theBatch.Add (dumy);
			}
			dumy = "";
			//if (givenExpression [givenExpression.Length - 1] == '!') {
			//	theBatch.Add ("!"); 
			//}
				// end theBatach making logic.
		}  //end Process String function.

		/// <summary>
		/// EquationManager
		/// This function manages the equation after the ProcesString. 
		/// It takes the variable required for the equation solving.
		/// it also allcates the unnamed variable.
		/// It also sees wether the equation is solvable. I.E the required variable still exists or not.
		/// </summary>

		void EquationManager()
		{
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				bool alreadyExists = AlreadyExists (x);
				if ((!Checker.ifContainOperations (x) || !Checker.ifContainMatOperations (x)) && x != "-") {
					if (!alreadyExists && getExpression (x)) {
						theExpressionList.Add (theRequredExpression);
					} else if (Checker.isNumberDeclaration (x) && x != "-") {
						Number num = new Number ();
						num.setTag (autoNamer ());
						num.setNumber (double.Parse (x));
						theBatch [counter] = num.getTag ();
						Expression theNum = new Expression (num);
						theExpressionList.Add (theNum);
					} else if (Checker.isMatrixDeclaration (x) && x.Contains ("]") && Checker.getOccurance (x, ']') == 1 && Checker.getOccurance (x, '[') == 1 && x[x.Length - 1] == ']') {
						Matrix mat = new Matrix (HelperClasses.Processes.MatrixMaker (x));
						mat.setTag (autoNamer ());
						theBatch [counter] = mat.getTag ();
						Expression theMat = new Expression (mat);
						theExpressionList.Add (theMat);
					} else if (Checker.isConstant (x)) {
						if (!alreadyExists) {
							theExpressionList.Add (theConstantList.getConstant (x)); 
						}
					}
					else if(Checker.ifPrefixExist (x)){
						if (!alreadyExists) {
							theExpressionList.Add (pUnderstander.prefixList (x));
						}
					}
					else {
						if(!alreadyExists && !Checker.ifCommandExists (x)){
						TheMessageHandler.MessagePrinter.Print ($"Error! The variable {x} does not exist, currently. Or Wrong formate entered");
						Processed = false;
							break;
						}
					}
				} 
				counter++;
			}
		}

		void EquationSolution ()
		{
			EquationSolvingHead.MathematicalEquationSolvingHead solver = new EquationSolvingHead.MathematicalEquationSolvingHead (theExpressionList, theBatch);
			if (!solver.Processed) {
				Processed = false;
			} else {
				Solution = solver.getSolution ();
			}
		}



		/////////////Helper function to deal with theExpList gotten from the outside interface.

		bool AlreadyExists(string tag)
		{
			bool exists = false;
			foreach (Expression x in theExpressionList) {
				if (x.getTag () == tag) {
					exists = true;
					break;
				}
			}
			return exists; 
		}


		static int ANCount = 0;
		string autoNamer()
		{
			ANCount++;
			return ($"{ANCount}___|||NUMBER|||OR>>MATRIX_>{ANCount}");
		}

		Expression theRequredExpression;  //  A variable for the helper function getExpression.

		bool getExpression(string tag)
		{
			bool found = false;
			foreach (Expression x in theInputExpressionList) {
					if (x.getTag () == tag) {
						found = true;
						theRequredExpression = new Expression (x);
						break;
					}
				}

			return found;
		}

		/////////////Functions for debugging.

		void PrintDebug()
		{
			foreach (string x in theBatch) {
				TheMessageHandler.MessagePrinter.Print (x);
			}
		}

		void PrintExpressionListDebug()
		{
			foreach(Expression x in theExpressionList)
			{
				ExpressionPrinter x1 =  new ExpressionPrinter(x);
				x1.Print();
			}
		}

	}  //end class EquationWatch
}  // end namespace EquationHead


//