using System;
using DataTypeSpace;
using allSolverInterface;

namespace CommandUnderstander
{
	public class binCUnderstander: Solver
	{
		string lhs, rhs , theOperator;
		Expression lexp , rexp, theSolution;
		bool Processed  = true;
		public bool isProcessed() => Processed;
		public Expression getSolution () => theSolution;
		public binCUnderstander (string lhs, string theOperator, string rhs, Expression lExp, Expression rExp)
		{
			this.lhs = lhs; 
			this.rhs = rhs;
			this.theOperator = theOperator;
			lexp = new Expression (lExp);
			rexp = new Expression (rExp);
			Observe ();
		}

		void Observe()
		{
			if (theOperator == "cross") {
				if (lexp.getExpType () == 1 && rexp.getExpType () == lexp.getExpType ()) {
					Matrix lmat = new Matrix (lexp.getMatrix ());
					Matrix rmat = new Matrix (rexp.getMatrix ());
					if (lmat.getRows () == 1 && rmat.getRows () == lmat.getRows ()) {
						if (lmat.getColumns () <= 3 && rmat.getColumns () <= 3) {
							Matrix Ans = null;
							Ans = Ans.crossproduct (lmat, rmat);
							Ans.setTag (autoNamer ());
							theSolution = new Expression (Ans);
						} else {
							TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
							Processed = false;
						}
					} else {
						TheMessageHandler.MessagePrinter.Print ("Invalid Operator");
						Processed = false;
					}
				} else {
					TheMessageHandler.MessagePrinter.Print ("Invalid Operation");
					Processed = false;
				}
			}
		}

		static int snaCount = 0;
		string autoNamer()
		{
			snaCount++;
			return ("mylIF__maRulrSaaad_ISthenameeme" + snaCount);
		}

	}
}

