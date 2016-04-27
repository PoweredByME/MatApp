using System;
using allSolverInterface;
using DataTypeSpace;
using StaticClasses;
using Java.Security;
using System.Reflection;
using Android.Util;


namespace CommandUnderstander
{
	public class cUnderstander : Solver
	{
		string LHS, RHS;
		bool Processed = true;
		Expression solution, rexp;
		public cUnderstander(string lhs , string rhs, Expression rexp)
		{
			LHS = lhs;
			RHS = rhs;
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
					solution = new Expression(ans);
				}
			}    // end if for tan

			if (LHS == "acos") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Acos((rexp.getNumber ().getNumber ()));
					ans.setNumber ( Ans * 180 / Math.PI);
					ans.setTag (autoNamer ());
					solution = new Expression(ans);
				}
			}    // end if for Acos


			if (LHS == "asin") {
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


			if (LHS == "atan") {
				if (rexp.getExpType () == 1) {
					Processed = false;
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
				} else if (rexp.getExpType () == 2) {
					Number ans = new Number ();
					double Ans = Math.Atan((rexp.getNumber ().getNumber ()));
					ans.setNumber ( Ans* 180 / Math.PI);
					ans.setTag (autoNamer ());
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
					solution = new Expression(ans);
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
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());
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
					ans.setNumber ( Ans);
					ans.setTag (autoNamer ());
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
					solution = new Expression(ans);
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
					solution = new Expression(ans);
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
					solution = new Expression(ans);
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
					solution = new Expression (mat);
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
					solution = new Expression (mat);
				}
			}

		}    //end observer

		static int snaCount = 0;
		string autoNamer()
		{
			snaCount++;
			return ("mylIF__maRulrSaaad_ISthenameeme" + snaCount);
		}
	}
}

