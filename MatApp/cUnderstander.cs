﻿using System;
using allSolverInterface;
using DataTypeSpace;
using StaticClasses;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Android.Animation;
using Android.Nfc.CardEmulators;
using Java.Security;
using Android.Graphics.Drawables;
using Android.Util;
using System.Runtime.InteropServices.ComTypes;
using Android.Drm;
using MatApp;
using Org.Apache.Http.Protocol;
using Javax.Crypto;
using System.Security.Cryptography;
using Android.Nfc.Tech;
using Android.OS;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CommandUnderstander
{
	public class cUnderstander : Solver
	{
		string LHS, RHS, rLHS, rRHS;
		bool Processed = true;
		Expression solution, rexp;
		public cUnderstander(string lhs , string rhs, Expression rexp)
		{
			rLHS = lhs;
			rRHS = rhs;
			LHS = lhs.TrimStart ("-".ToCharArray ());
			RHS = rhs.TrimStart ("-".ToCharArray ());
			this.rexp = rexp;
			Observe ();
		}

		public bool isProcessed() => Processed;
		public Expression getSolution() => solution;

		bool isMultiple(double basenum,double num )
		{
			bool x = false;
			if (basenum > num)
				x=  false;
			else {
				if (num % basenum == 0) {
					x= true;
				}
			}
			return x;
		}

		bool isCosMultiple(double basenum,double num )
		{
			bool x = false;
			if (basenum > num)
				x = false;
			else if (basenum != num &&(num % basenum) % 2 == 0) {
				x = false;
			}
			else {
				if (num % basenum == 0) {
					x= true;
				}
			}
			return x;
		}

		void Observe()
		{
			if (LHS == "sin") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
						double Ans = Math.Sin ((rexp.getNumber ().getNumber ()) * Math.PI / 180);
					if (isMultiple (180, rexp.getNumber ().getNumber ())) {
						ans.setNumber (0);
						ans.setTag (autoNamer ());
					} else {
						ans.setNumber (Ans);
						ans.setTag (autoNamer ());
					}
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for sin

			if (LHS == "cos") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
						double Ans = Math.Cos ((rexp.getNumber ().getNumber ()) * Math.PI / 180);
					if (isCosMultiple (90, rexp.getNumber ().getNumber ()))
						Ans = 0;
					    ans.setNumber (Ans);
						ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for cos

			if (LHS == "tan") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Tan((rexp.getNumber ().getNumber ())*Math.PI/180);
					if (isCosMultiple (90, rexp.getNumber ().getNumber ()))
						Ans = 46 * Math.Pow (45, 7986);
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for tan

			if (LHS == "arcÇos") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Acos((rexp.getNumber ().getNumber ()));
					ans.setNumber ( Ans * 180 / Math.PI);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
					}
			}    // end if for Acos


			if (LHS == "arcSin") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Asin((rexp.getNumber ().getNumber ()));
					ans.setNumber ( Ans* 180 / Math.PI);
					ans.setTag (autoNamer ());
					solution = new Expression(ans);
				}
			}    // end if for Asin


			if (LHS == "arctan") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Atan((rexp.getNumber ().getNumber ()));
					ans.setNumber ( Ans* 180 / Math.PI);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for atan

			if (LHS == "sinh") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Sinh ((rexp.getNumber ().getNumber ()));// * Math.PI / 180);
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for atan


			if (LHS == "cosh") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Cosh ((rexp.getNumber ().getNumber ()));// * Math.PI / 180);
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}solution = new Expression(ans);
				}
			}    // end if for atan


			if (LHS == "tanh") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Tanh ((rexp.getNumber ().getNumber ()));// * Math.PI / 180);
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for atan


			if (LHS == "sec") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = 1/(Math.Cos((rexp.getNumber ().getNumber ()) * Math.PI / 180));
					if (isCosMultiple (90, rexp.getNumber ().getNumber ()))
						Ans = 456*Math.Pow (256, 4456);
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for atan

			if (LHS == "cosec" || LHS == "csc") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = 1/(Math.Sin((rexp.getNumber ().getNumber ()) * Math.PI / 180));
					if (isMultiple (180, rexp.getNumber ().getNumber ())) 
						Ans = 234 * Math.Pow (345, 999);
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression(ans);
				}
			}    // end if for atan

			if (LHS == "cot") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = 1/(Math.Tan((rexp.getNumber ().getNumber ()) * Math.PI / 180));
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}solution = new Expression(ans);
				}
			}    // end if for atan

			if (LHS == "log") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Log10 (rexp.getNumber ().getNumber ());
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}solution = new Expression(ans);
				}
			}    // end if for atan

			if (LHS == "ln") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Log (rexp.getNumber ().getNumber ());
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}solution = new Expression(ans);
				}
			}    // end if for atan

			if (LHS == "rref") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if(rexp.getExpType () == 1){
					Matrix mat = new Matrix (rexp.getMatrix ());
					mat.GaussJordan ();
					mat.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						mat = mat * -1;
					}solution = new Expression (mat);
				}
			}

			if (LHS == "transp") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if(rexp.getExpType () == 1){
					Matrix mat = new Matrix (rexp.getMatrix ());
					mat = mat.getTranspose ();
					mat.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						mat = mat * -1;
					}solution = new Expression (mat);
				}
			}

			if (LHS == "inv") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if(rexp.getExpType () == 1){
					Matrix mat = new Matrix (rexp.getMatrix ());
					if (mat.getRows () == mat.getColumns ()) {
						double det = mat.getdetreminant(mat);
						if (det != 0) {
							mat = mat.Inverse1 (mat);
							mat.setTag (autoNamer ());

							if (rLHS.Contains ("-")) {
								mat = mat * -1;
							}
							solution = new Expression (mat);
						} else {
							TheMessageHandler.MessagePrinter.Print ("Determinant is zero. Inverse does not exist");
							Processed = false;
						}
					} else {
						TheMessageHandler.MessagePrinter.Print ("Invalid Matrix");
						Processed = false;
					}
				}
			}



			if (LHS == "ref") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 1) {
					Matrix mat = new Matrix (rexp.getMatrix ());
					mat.GaussElimination ();
					mat.setTag (autoNamer ());

					if (rLHS.Contains ("-")) {
						mat = mat * -1;
					}solution = new Expression (mat);
				}
			}

			if (LHS == "det") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 1) {
					Matrix mat = new Matrix (rexp.getMatrix ());
					if (mat.getColumns () == mat.getRows ()) {
						double ans = mat.getdetreminant(mat);
						Number Ans = new Number ();
						Ans.setNumber (ans);
						Ans.setTag (autoNamer ());
						if (rLHS.Contains ("-")) {
							Ans.setNumber (-1*Ans.getNumber ());
						}
						solution = new Expression (Ans);
					} else {
						Processed = false;
						TheMessageHandler.MessagePrinter.Print ("Not a square Matrix");
					}
				}
			}

			if (LHS == "adj") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 1) {
					Matrix mat = new Matrix (rexp.getMatrix ());
					if (mat.getColumns () == mat.getRows ()) {
						mat = mat.getAdjoint ();
						mat.setTag (autoNamer ());
						if (rLHS.Contains ("-")) {
							mat = -1 * mat;
						}
						solution = new Expression (mat);
					} else {
						Processed = false;
						TheMessageHandler.MessagePrinter.Print ("Matrix is not square");
					}
				}
			}

			if (LHS == "identity" || LHS == "matIdentity") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid arguments");
				} else if(rexp.getExpType() == 2){
					double size = rexp.getNumber ().getNumber ();
					Matrix iden = new Matrix ((int)size,(int)size);
					iden.Identity ();
					iden.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						iden = iden * -1;
					}
					solution = new Expression (iden);
				}
			}

			if (LHS == "round") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Argument");
				} else {
					double num = rexp.getNumber ().getNumber ();
					if (RHS.Contains ("-")) {
						num = -1 * num;
					}
					num = Math.Round (num);
					Number ans = new Number ();
					ans.setNumber (num);
					ans.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression (ans);
				}
			}

			if (LHS == "abs") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Argument");
				} else {
					double num = rexp.getNumber ().getNumber ();
					if (RHS.Contains ("-")) {
						num = -1 * num;
					}
					num = Math.Abs (num);
					Number ans = new Number ();
					ans.setNumber (num);
					ans.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression (ans);
				}
			}

			if (LHS == "ceil") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Argument");
				} else {
					double num = rexp.getNumber ().getNumber ();
					if (RHS.Contains ("-")) {
						num = -1 * num;
					}
					num = Math.Ceiling (num);
					Number ans = new Number ();
					ans.setNumber (num);
					ans.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression (ans);
				}
			}

			if (LHS == "floor") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Argument");
				}else {
					double num = rexp.getNumber ().getNumber ();
					if (RHS.Contains ("-")) {
						num = -1 * num;
					}
					num = Math.Floor (num);
					Number ans = new Number ();
					ans.setNumber (num);
					ans.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression (ans);
				}
			}

			if (LHS == "√") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Arguments");
				} else {
					double num = rexp.getNumber ().getNumber ();
					if (RHS.Contains ("-")) {
						num = -1 * num;
					}
					num = Math.Sqrt (num);
					Number ans = new Number ();
					ans.setNumber (num);
					ans.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						ans.setNumber (-1*ans.getNumber ());
					}
					solution = new Expression (ans);
				}
			}

			if (LHS == "rank") {
				if (rexp.getExpType () == 2) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Arguments");
				} else {
					Matrix mat = new Matrix (rexp.getMatrix ());
					double rank = mat.rank (mat);
					Number theRank = new Number ();
					theRank.setNumber (rank);
					theRank.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						theRank.setNumber (-1*theRank.getNumber ());
					}
					solution = new Expression (theRank);
  				}

			}

			if (LHS == "magic") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Arguments");
				} else {
					Matrix mat = new Matrix ();
					int size = (int)(rexp.getNumber ().getNumber ());
					mat = mat.magic (size);
					mat.setTag (autoNamer ());
					if (rLHS.Contains ("-")) {
						mat = mat * -1;
					}
					solution = new Expression (mat);
				}
			}

			}    //end observer
			


		public static List<string> getFunctionList()
		{
			List<string> theFunctionList = new List<string> ();
			theFunctionList.Add ("^(2)");
			theFunctionList.Add ("√"); 
			theFunctionList.Add ("sin");
			theFunctionList.Add ("cos");
			theFunctionList.Add ("tan");
			theFunctionList.Add ("arctan");
			theFunctionList.Add ("arcSin");
			theFunctionList.Add ("arcÇos");
			theFunctionList.Add ("sec");
			theFunctionList.Add ("cosec");
			theFunctionList.Add ("cot"); 
			theFunctionList.Add ("log");
			theFunctionList.Add ("ln");
			theFunctionList.Add ("abs");
			theFunctionList.Add ("sinh");
			theFunctionList.Add ("cosh");
			theFunctionList.Add ("tanh"); 
			theFunctionList.Add ("nCr");
			theFunctionList.Add ("nPr"); 
			theFunctionList.Add ("ceil");
			theFunctionList.Add ("floor");
			theFunctionList.Add ("round");
			return theFunctionList;
		}

		public static List<string> IntelligenceBinFunctionList()
		{
			List<string> theFunctionList = new List<string> ();
			theFunctionList.Add ("P");
			theFunctionList.Add ("C");
			return theFunctionList;
		}

		public static List<string> getMatrixFunctionList()
		{
			List<string> theFunctionList = new 	List<string> ();
			theFunctionList.Add ("Det");
			theFunctionList.Add ("Inverse");
			theFunctionList.Add ("Transpose");
			theFunctionList.Add ("Adjoint"); 
			theFunctionList.Add ("Identity"); 
			theFunctionList.Add ("Reduced\n  Row\n  Echelon");
			theFunctionList.Add ("Row\n  Echelon"); 
			theFunctionList.Add ("Rank"); 
			theFunctionList.Add ("Magic");
			return theFunctionList;
		}

		public static List<string> getVectorFunctionList()
		{
			List<string> theVectorList = new List<string> ();
			theVectorList.Add ("cross");
			theVectorList.Add ("dot");
			return theVectorList;
		}

		public static string matrixFunctionInputManager(string exp)
		{
			string result = "";
			if (exp == "Det") {
				result = "det";
			} else if (exp == "Inverse") {
				result = "inv";
			} else if (exp == "Transpose") {
				result = "transp";
			} else if (exp == "Adjoint") {
				result = "adj";
			} else if (exp == "Reduced\n  Row\n  Echelon") {
				result = "rref";
			} else if (exp == "Row\n  Echelon") {
				result = "ref";
			} else if (exp == "Identity") {
				result = "identity";
			} else if (exp == "Rank") {
				result = "rank";
			} else if (exp == "Magic") {
				result = "magic";
			}
			return result;
		}

		public static string binCommandInputManager(string exp)
		{
			string ans = "";
			if (exp == "nPr") {
				ans = "P";
			} else if (exp == "nCr") {
				ans = "C";
			} else {
				ans = exp; 
			}
			return ans;
		}
		public static List<string> IntelligenceMatricFunctionList ()
		{
			List<string> theFunctionList = new List<string>();
			theFunctionList.Add ("det");
			theFunctionList.Add ("inv");
			theFunctionList.Add ("transp");
			theFunctionList.Add ("adj"); 
			theFunctionList.Add ("rref");
			theFunctionList.Add ("ref"); 
			theFunctionList.Add ("identity"); 
			theFunctionList.Add ("rank"); 
			theFunctionList.Add ("magic"); 
			return theFunctionList;
		}

		static int snaCount = 0;
		string autoNamer()
		{
			snaCount++;
			return ("mylIF__maRulrSaaad_ISthenameeme" + snaCount);
		}
	}
}

