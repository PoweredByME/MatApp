﻿using System;
using DataTypeSpace;
using System.Collections.Generic;
using allSolverInterface;
using StaticClasses;
using CommandUnderstander;
/// <summary>
/// DMAS solver.
/// THis deals with the mathematical equations (arithematic) in 
/// DMAS.
/// </summary>
using Java.Security;
using System.Text;


namespace EquationSolver
{
	public class DMASSolver : Solver
	{
		List<Expression> theExpressionList;
		List<string> theBatch;
		private bool Processed = true;
		Expression Solution;

		public bool isProcessed () => Processed;
		public Expression getSolution()
		{
			theBatch.RemoveRange (0,theBatch.Count);
			theExpressionList.RemoveRange (0, theExpressionList.Count);
			return Solution;
		}
		public DMASSolver (List<Expression> theExpressionList, List<string>theBatch)
		{
			this.theExpressionList = theExpressionList;
			this.theBatch = theBatch;
			Solve ();
		}

		void Solve()
		{
			if (theBatch.Count == 1) {    // if case for the expression type of "-a"
				string s = theBatch [0].Trim ();
				Expression x = getExpression (theBatch [0].TrimStart ("-".ToCharArray ()));
				if (s [0] == '-') {
					if (x.getExpType () == 1) { // if the expression is a matrix.
						Solution = new Expression ((-1 * x.getMatrix ()));
					}
					if (x.getExpType () == 2) {
						Number num = x.getNumber ();
						num.setNumber (-1 * num.getNumber ());
						Solution = new Expression (num);
					}
				} else if (s [0] == '+') {
					if (x.getExpType () == 1) { // if the expression is a matrix.
						Solution = new Expression (x.getMatrix ());
					}
					if (x.getExpType () == 2) {
						Number num = x.getNumber ();
						num.setNumber (num.getNumber ());
						Solution = new Expression (num);
					}	
				}
				Solution = x;
			}  // end if case for expression of the type of "-a"

			else {     //if there is a mathematical expression like a+ a
				if(UnitaryOperators ()){
				if(CommandSolver ()){
			      if(binCommandOperator ()){
				   if(Power()){
					 if (Division ()) {
									if (Multiply ()) {
										if (Add ()) {
											Solution = theExpressionList [theExpressionList.IndexOf (getExpression (theBatch [0].TrimStart ("-".ToCharArray ())))];
										}
									}
								}
							}
						}
					}
				} else {}
			}

		}


		// this function deals with the addition of the variables.
		bool Add()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (x == "+") {
					string LHS = theBatch [counter - 1];
					string RHS = theBatch [counter + 1];
					if (Checker.ifCommandExists (LHS)) {
						Processed = false;
						solved = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator here");
						break;
					}
					Expression LEXP = new Expression (getExpression (LHS.TrimStart ("-".ToCharArray())));
					Expression REXP = new Expression (getExpression (RHS.TrimStart ("-".ToCharArray())));
					if (LEXP.getExpType () == REXP.getExpType ()) {
						if (LEXP.getExpType () == 1) {
							if (StaticClasses.Checker.MatrixEquivalent (LEXP.getMatrix(), REXP.getMatrix())) {
								Matrix lmat = new Matrix (LEXP.getMatrix());
								Matrix rmat = new Matrix (REXP.getMatrix());
								if (LHS.Contains ("-")) {
									lmat = -1 * lmat;
									theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
								}
								if (RHS.Contains ("-")) {
									rmat = -1 * rmat;
									theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
								}
								Matrix sum = lmat + rmat;
								sum.setTag (LHS.TrimStart ("-".ToCharArray ()));
								Expression result = new Expression (sum);
								theExpressionList [theExpressionList.IndexOf (getExpression (LHS.TrimStart ("-".ToCharArray ())))] = result; 
							} else {
								TheMessageHandler.MessagePrinter.Print ("Matrices are not similar");
								Processed = false;
								solved = false; 
								break;
							}
						} else if (LEXP.getExpType () == 2) {
							Number lnum = new Number(LEXP.getNumber ());
							Number rnum = new Number(REXP.getNumber ());
							if (LHS.Contains ("-")) {
								lnum.setNumber (-1 * lnum.getNumber ());
								theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
							}
							if (RHS.Contains ("-")) {
								rnum.setNumber (-1 * rnum.getNumber ()); 
								theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
							}
							Number sum = new Number ();
							sum.setNumber (lnum.getNumber () + rnum.getNumber ());
							sum.setTag (LHS.TrimStart ("-".ToCharArray ()));
							Expression result = new Expression (sum);
							theExpressionList [theExpressionList.IndexOf (getExpression (LHS.TrimStart ("-".ToCharArray ())))] = result;
						}
					} else {
						TheMessageHandler.MessagePrinter.Print ("Cannot add variable with different datatypes");
						Processed = false;
						solved = false;
						break;
					}
					theBatch.RemoveRange (counter, 2);
					counter = 0;
				}
				else
				counter++;
			}
			return  solved;
		}    //end function for addition.


		// this function deals with the multiplication
		bool Multiply()
		{
			bool solved =  true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (x == "*") {
					string LHS = theBatch [counter - 1];
					string RHS = theBatch [counter + 1];
					if (Checker.ifCommandExists (LHS)) {
						Processed = false;
						solved = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator here");
						break;
					}
					Expression LEXP = new Expression (getExpression (LHS.TrimStart ("-".ToCharArray ())));
					Expression REXP = new Expression (getExpression (RHS.TrimStart ("-".ToCharArray ())));
					if (LEXP.getExpType () == 1 && REXP.getExpType () == 1) {
						if (StaticClasses.Checker.MatrixLegalForMultiplication (LEXP.getMatrix (), REXP.getMatrix ())) {
							Matrix lmat = new Matrix (LEXP.getMatrix ());
							Matrix rmat = new Matrix (REXP.getMatrix ());
							if (LHS.Contains ("-")) {
								lmat = -1 * lmat;
								theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
							}
							if (RHS.Contains ("-")) {
								rmat = -1 * rmat;	
								theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
							}
							Matrix product = lmat * rmat;
							product.setTag (LHS.TrimStart ("-".ToCharArray ()));
							Expression result = new Expression (product);	
							theExpressionList [theExpressionList.IndexOf (getExpression (LHS.TrimStart ("-".ToCharArray ())))] = result; 
						} else {
							solved = false;
							Processed = false;
							TheMessageHandler.MessagePrinter.Print ("The order of the matrices is not correct");
							break;
						}
					} else if (LEXP.getExpType () == 2 && REXP.getExpType () == 2) {
						Number lnum = new Number (LEXP.getNumber ());
						Number rnum = new Number (REXP.getNumber ());
						if (LHS.Contains ("-")) {
							lnum.setNumber ((-1 * lnum.getNumber ()));
							theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						}
						if (RHS.Contains ("-")) {
							rnum.setNumber ((-1 * rnum.getNumber ()));
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
						}
						Number product = new Number ();
						product.setNumber (lnum.getNumber () * rnum.getNumber ());
						product.setTag (LHS.TrimStart ("-".ToCharArray ()));
						Expression result = new Expression (product);
						theExpressionList [theExpressionList.IndexOf (getExpression (LHS.TrimStart ("-".ToCharArray ())))] = result; 
					} else if ((LEXP.getExpType () == 1 && REXP.getExpType () == 2)) {
						Matrix lhs = new Matrix (LEXP.getMatrix ());
						Number rhs = new Number (REXP.getNumber ());
						if (LHS.Contains ("-")) {
							lhs = -1 * lhs;
							theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						}
						if (RHS.Contains ("-")) {
							rhs.setNumber (-1 * rhs.getNumber ());
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
							}
						Matrix product = lhs * (rhs.getNumber());
						product.setTag (LHS.TrimStart ("-".ToCharArray ()));
						Expression result = new Expression (product);
						theExpressionList [theExpressionList.IndexOf (getExpression (LHS.TrimStart ("-".ToCharArray ())))] = result; 
					}
					else if ((LEXP.getExpType () == 2 && REXP.getExpType () == 1)) {
						Matrix rhs = new Matrix (REXP.getMatrix ());
						Number lhs = new Number (LEXP.getNumber ());
						if (RHS.Contains ("-")) {
							rhs = -1 * rhs;
							theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						}
						if (LHS.Contains ("-")) {
							lhs.setNumber (-1 * lhs.getNumber ());
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
						}
						Matrix product = rhs * (lhs.getNumber());
						product.setTag (LHS.TrimStart ("-".ToCharArray ()));
						Expression result = new Expression (product);
						theExpressionList [theExpressionList.IndexOf (getExpression (LHS.TrimStart ("-".ToCharArray ())))] = result; 
					}

					theBatch.RemoveRange (counter,2);
					counter = 0;
				}
				else
				counter++;
			}
			return solved;
		}  //end multiplication

		bool Division()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (x == "/") {
					string lhs = theBatch [counter - 1];
					string rhs = theBatch [counter + 1];
					if (Checker.ifCommandExists (lhs)) {
						Processed = false;
						solved = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator here");
						break;
					}Expression lexp = new Expression (getExpression (lhs.TrimStart ("-".ToCharArray ())));
					Expression rexp = new Expression (getExpression (rhs.TrimStart ("-".ToCharArray ())));
					if (lexp.getExpType () == 1 && rexp.getExpType () == 2) {
						Number rnum = new Number (rexp.getNumber ());
						Matrix lmat = new Matrix (lexp.getMatrix ());
						if (lhs.Contains ("-")) {
							lmat = -1 * lmat;
							theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						}
						if (rhs.Contains ("-")) {
							rnum.setNumber (-1 * rnum.getNumber ());
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
						}
						Matrix ans = lmat / (rnum.getNumber ());
						ans.setTag (lhs.TrimStart ("-".ToCharArray ()));
						Expression result = new Expression (ans);
						theExpressionList [theExpressionList.IndexOf (getExpression (lhs.TrimStart ("-".ToCharArray ())))] = result; 
					} else if (lexp.getExpType () == 2 && rexp.getExpType () == 2) {
						Number lnum = new Number (lexp.getNumber ());
						Number rnum = new Number (rexp.getNumber ());
						if (lhs.Contains ("-")) {
							lnum.setNumber (-1 * lnum.getNumber ());
							theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						}
						if (rhs.Contains ("-")) {
							rnum.setNumber (-1 * rnum.getNumber ());
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
						}
						Number ans = new Number ();
						ans.setNumber (lnum.getNumber () / rnum.getNumber ());
						ans.setTag (lhs.TrimStart ("-".ToCharArray ()));
						Expression result = new Expression (ans);
						theExpressionList [theExpressionList.IndexOf (getExpression (lhs.TrimStart ("-".ToCharArray ())))] = result; 
					} else {
						TheMessageHandler.MessagePrinter.Print ("Invalid operation");
						Processed = false;
						solved = false;
						break;
					}
					theBatch.RemoveRange (counter, 2);
					counter = 0;
				}
				else
				counter++;
			}
			return solved;
		}  //end function for division.

	    static int eCount = 0;

		bool Power()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (x == "^") {
					string lhs = theBatch [counter - 1];
					string rhs = theBatch [counter + 1];
					if (Checker.ifCommandExists (lhs)) {
						Processed = false;
						solved = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator here");
						break;
					}
					Expression lexp = new Expression (getExpression (lhs.TrimStart ("-".ToCharArray ())));
					Expression rexp = new Expression (getExpression (rhs.TrimStart ("-".ToCharArray ())));
					if (Checker.isConstant (lhs.Trim ("-".ToCharArray ())) && lhs.Trim ("-".ToCharArray ()) =="e"  && rexp.getExpType () == 2) {
						Number sol = new Number();
						double num = rexp.getNumber ().getNumber ();
						if (rhs.Contains ("-")) {
							num = -1 * num;
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
						}
						double ans =  (Math.Exp (num));
						if (lhs.Contains ("-")) {
							ans = ans * -1;
							theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						}
						string ne = ("theThug????Saadetcmaxxjp" + (eCount++));
						sol.setNumber (ans);
						sol.setTag (ne);
						theBatch [counter - 1] =ne ;//theBatch [counter - 1].TrimStart ("-".ToCharArray ());
						Expression exp = new Expression(sol);
						theExpressionList [theExpressionList.IndexOf (getExpression (lhs.TrimStart ("-".ToCharArray ())))] = exp; 
					   }
					else if (lexp.getExpType () == 2 && lexp.getExpType () == 2) {
						Number lnum = new Number (lexp.getNumber ());
						Number rnum = new Number (rexp.getNumber ());
						if (lhs.Contains ("-")) {
							lnum.setNumber (-1 * lnum.getNumber ());
							if (rnum.getNumber () % 2 == 0)
								theBatch [counter - 1] = theBatch [counter - 1];//.TrimStart ("-".ToCharArray ());
							else
								theBatch [counter - 1] = theBatch [counter - 1].TrimStart ("-".ToCharArray ());
							}
						if (rhs.Contains ("-")) {
							rnum.setNumber (-1 * rnum.getNumber ());
							theBatch [counter + 1] = theBatch [counter + 1].TrimStart ("-".ToCharArray ());
						}
						Number ans = new Number ();
						ans.setNumber (Math.Pow (lnum.getNumber(), rnum.getNumber()));
						ans.setTag (lhs.TrimStart ("-".ToCharArray ()));
						Expression exp = new Expression (ans);
						theExpressionList [theExpressionList.IndexOf (getExpression (lhs.TrimStart ("-".ToCharArray ())))] = exp; 
						} else {
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator for matrices");
						solved = false;
						Processed = false;
						break;
					}
					theBatch.RemoveRange (counter, 2);
					counter = 0;
				}
				else
				counter++;
			}
			return solved;
		}

		bool CommandSolver()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (x == "--->>>" && counter != 0) {
					string lhs = new string (theBatch [counter - 1].ToCharArray ());
					string rhs = new string (theBatch [counter + 1].ToCharArray ());
					if (Checker.ifCommandExists (rhs)) {
						solved = false;
						Processed = false;
						TheMessageHandler.MessagePrinter.Print ("Invalid Sequence");
						break;
					} else if (Checker.ifCommandExists (lhs)) {
						cUnderstander command = new cUnderstander (lhs, rhs, new Expression (getExpression (rhs.TrimStart ("-".ToCharArray ()))));
						if (command.isProcessed ()) {
							Expression e = new Expression (command.getSolution ());
							theExpressionList.Add (e);
							theBatch [counter - 1] = e.getTag ();
							theBatch.RemoveRange (counter, 2);
							counter=0;
						} else {
							Processed = false;
							solved = false;
							break;
						}
					}
				}
				else
				counter++;
			}
			return solved; 
		}

		bool UnitaryOperators()    // to performing functinos like factorial;
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (x == "!") {
					string lhs = theBatch [counter - 1];
					Expression lexp = new Expression (getExpression (lhs.TrimStart ("-".ToCharArray ())));
					if(lexp.getExpType () == 2) {
						double theNumber = lexp.getNumber ().getNumber ();
						if (lhs.Contains ("-")) {
							theNumber = -1 * theNumber;
						}
						theNumber = Factorial (theNumber);
						Number ans = new Number ();
						ans.setNumber (theNumber);
						ans.setTag (lhs.TrimStart ("-".ToCharArray ()));
						Expression exp = new Expression (ans);
						theExpressionList [theExpressionList.IndexOf (getExpression (lhs.TrimStart ("-".ToCharArray ())))] = exp;
						theBatch [counter - 1] = exp.getTag ();
						theBatch.RemoveAt (counter);
					}
				} else {
					counter++;
				}
			}
			return solved;
            
		}


		// method for binary command solviong like nPr

		bool binCommandOperator()
		{
			bool solved = true;
			int counter = 0;
			while (counter < theBatch.Count) {
				string x = theBatch [counter];
				if (Checker.isBinCommand (x)) {
					if (counter == 0) {
						TheMessageHandler.MessagePrinter.Print ("Invalid operation");
						Processed = false;
						solved = false;
						break;
					}
					string lhs = theBatch [counter - 1];
					string rhs = theBatch [counter + 1];
					Expression lexp = new Expression (getExpression (lhs.TrimStart ("-".ToCharArray ())));
					Expression rexp = new Expression (getExpression (rhs.TrimStart ("-".ToCharArray ())));
					binCUnderstander sol = new binCUnderstander (lhs, x, rhs, lexp, rexp);
					if (sol.isProcessed ()) {
						Expression ans = new Expression (sol.getSolution ());
						theExpressionList.Add (ans);
						theBatch [counter - 1] = ans.getTag ();
						theBatch.RemoveRange (counter, 2);
						counter = 0;
					} else {
						Processed = false;
						solved = false;
						break;
					}
				}
				counter++;
			}
			return solved;
		}

		// method for binary command solviong like nPr





		public static double Factorial (double num){
			if (num == 0) {
				return (1);
			} else {
				return (num * Factorial (num - 1));
			}
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

	}   //end DMAS Solver Class

}     // end EquationSolvingHead namespace

