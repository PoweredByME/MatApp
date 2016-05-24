using System;
using DataTypeSpace;
using allSolverInterface;
using EquationSolver;
using Java.Security;
using Android.OS;

namespace CommandUnderstander
{
	public class binCUnderstander: Solver
	{
		string lhs, rhs , theOperator, rLHS, rRHS;
		Expression lexp , rexp, theSolution;
		bool Processed  = true;
		public bool isProcessed() => Processed;
		public Expression getSolution () => theSolution;
		public binCUnderstander (string lhs, string theOperator, string rhs, Expression lExp, Expression rExp)
		{
			rLHS = lhs;
			rRHS = rhs;
			this.lhs = lhs.TrimStart ("-".ToCharArray ()); 
			this.rhs = rhs.TrimStart ("-".ToCharArray ());
			this.theOperator = theOperator;
			lexp = new Expression (lExp);
			rexp = new Expression (rExp);
			Observe ();
		}

		void Observe()
		{
			if (theOperator == "P") {
				if (rexp.getExpType () == 1 || lexp.getExpType () == 1) {
					TheMessageHandler.MessagePrinter.Print ("Invalid operation.");
					Processed = false;
				} else {
					Number ans = new Number ();
					ans.setNumber (Permutation (lexp.getNumber ().getNumber (), rexp.getNumber ().getNumber ()));
					ans.setTag (autoNamer ());
					theSolution = new Expression (ans);
				}

				if (processError) {
					TheMessageHandler.MessagePrinter.Print ("Math Error");
					Processed = false;
				}
			}

			if (theOperator == "C") {
				if (rexp.getExpType () == 1 || lexp.getExpType () == 1) {
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
					Processed = false;
				} else {
					Number ans = new Number ();
					ans.setNumber (Combination (lexp.getNumber ().getNumber (), rexp.getNumber ().getNumber ()));
					ans.setTag (autoNamer ());
					theSolution = new Expression (ans);
				}
				if (processError) {
					TheMessageHandler.MessagePrinter.Print ("Math Error");
					Processed = false;
				}
			}

			if (theOperator == "•") {
				if (rexp.getExpType () == 2 || rexp.getExpType () == 2) {
					TheMessageHandler.MessagePrinter.Print ("Invalid Operator");
					Processed = false;
				} else {
					if (lexp.getMatrix ().getRows () == 1 && rexp.getMatrix ().getRows () == 1 && rexp.getMatrix ().getColumns () == 3 && lexp.getMatrix ().getColumns () == 3) {
						Number ans = new Number ();
						ans.setNumber (lexp.getMatrix ().dotproduct (lexp.getMatrix (), rexp.getMatrix ()));
						ans.setTag (autoNamer ());
						theSolution = new Expression (ans);
					} else {
						TheMessageHandler.MessagePrinter.Print ("Vector should be in formate : \n[ i j k ]");
						Processed = false;
					}
				}
			}
		}




		bool processError = false;
		//Operations

		double Permutation(double n, double r)
		{
			double ans = 0;
			double divide = n - r;
			if (!(divide <= 0)) {
				ans = DMASSolver.Factorial (n) / DMASSolver.Factorial (divide);
			} else if (divide == 0) {
				ans = DMASSolver.Factorial (n) / 1;
			} else {
				processError = true;
				ans = 0;
			}
			return ans;
		}


		double Combination(double n , double r)
		{
			double ans = 0;
			double divide = n - r;
			if (!(divide < 0)) {
				ans = (DMASSolver.Factorial (n) / (DMASSolver.Factorial (r) * DMASSolver.Factorial (n - r)));
			} else {
				processError = true;
				ans = 0;
			}
			return ans;
		}

		//Operations
		static int snaCount = 0;
		string autoNamer()
		{
			snaCount++;
			return ("mylIF__maRulrSaaad_ISthenameeme" + snaCount);
		}

	}
}

