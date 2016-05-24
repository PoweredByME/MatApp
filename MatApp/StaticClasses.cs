using System;
using DataTypeSpace;

/// <summary>
/// this namespace have static functions that prints a matrix or that apply the checks for the code.
/// </summary>



namespace StaticClasses
{
	public static class Checker
	{// 
		//static string alphabets = "";
		static string numbers = "-0123456789.";
		static string operators = "()*+-/^!PC•";
	//	static string Alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMONPQRSTUVWXYZ_";
		public static bool isEquation (string exp) => exp.Contains("=");
		public static int getOccurance (string exp, char character)  // returns the occuracences of a specific character.
		{ 
			
			int occur = 0;
			foreach (char c in exp) {
				if (c == character)
					occur++;
			}
			return occur;
		}
		// tells if the stirng is a mathematical one.

		public static bool ifPrefixExist(string exp)
		{
			return (exp == "zepto" || exp == "yocto" || exp == "atto" || exp == "femto" || exp == "pico" || exp == "nano" || exp == "micro" || exp == "milli" || exp == "centi" || exp == "deci" || exp == "deca" || exp == "hecto" || exp == "kilo" || exp == "mega" || exp == "giga" || exp == "tera" || exp == "peta" || exp == "exa" || exp == "zepta" || exp == "yotta" || exp == "amu" || exp == "eV" || exp == "au" || exp == "angstrom");
		}


		public static bool ifContainOperations (string exp) => (exp.Contains("•") || exp.Contains("P") || exp.Contains("C")|| exp.Contains("(")||exp.Contains(")")||exp.Contains("+")||exp.Contains("-")||exp.Contains("*")||exp.Contains("/")||exp.Contains("^") || exp==("--->>>") || exp.Contains("!"));
		public static bool ifContainMatOperations (string exp) => (exp.Contains("•") || exp.Contains("P") || exp.Contains("C")|| exp.Contains("(")||exp.Contains(")")||exp.Contains("+")||exp.Contains("*")||exp.Contains("/")||exp.Contains("^") || exp==("--->>>") || exp.Contains("!"));

		public static bool ifCommandExists(string Rexp) { 
			string exp = Rexp.TrimStart ("-".ToCharArray ());
			return(exp == ("sin") || exp == ("cos") || exp == ("tan") || exp == "arctan" 
				|| exp == "arcÇos" || exp == "arcSin" || exp == "sinh" || exp == "cosh" || exp == "tanh" || exp == "sec" || exp == "cosec" || exp == "csc" || exp == "cot" || exp == "log" || exp == "ln" || exp == "rref" || exp == "ref" || exp == "det" || exp == "inv" || exp == "adj" || exp == "identity" ||
				exp == "matIdentity" || exp == "round" || exp == "abs" || exp == "floor" || exp == "ceil" || exp == "√" || 
				exp == "transp" || exp == "rank" || exp == "magic");
		}
		public static bool isContainOperations(string exp){
			return (exp== "•" || exp == "P" || exp == "C" || exp == "(" || exp == ")" || exp == "+" || exp == "-" || exp == "*" || exp == "/" || exp == "^" || exp == "--->>>" || exp == "!");
		}
		public static bool isOperation (char character)=> operators.Contains(character.ToString());
		public static bool isMatrixDeclaration (string exp) => (exp.Contains("[") || exp.Contains("]"));
		public static bool isBasicOperator (string exp) => (exp.Contains("+")||exp.Contains("-")||exp.Contains("*")||exp.Contains("/") || exp.Contains(")") || exp.Contains("^"));  // tells wehter the operator is a '+ - * /'  function made specifically for the Operator Manager function of the equation head
		public static bool isConstant(string exp){
			return (exp == "π" || exp == "e" || exp == "numAddIdentity" || exp == "numMultIdentity" || exp == "G" || exp == "g" || exp == "me" || exp == "mn" || exp == "mp" || exp == "h" || exp == "Na");
		}

		public static bool isNumberDeclaration (string exp)
		{ 
			bool numeric = true;
			foreach (char x in exp) {
				if (!isNumeric (x)) {
					numeric = false;
					break;
				}
			}
			return numeric;
		}
		public static bool OccurAtStart(string exp, char character) 
		{
			return (exp.IndexOf (character) == 0);
		}
		public static bool OccurAtEnd(string exp, char character)
		{
			return (exp.IndexOf (character) == (exp.Length - 1));
		}
		public static bool isNumeric(char character) => numbers.Contains(character.ToString());

		public static bool ifContainInput(string exp)
		{
			string newNumbers = "0123456789";
			bool nummeric = false;
			foreach (char c in exp) {
				if (newNumbers.Contains (c.ToString())) {
					nummeric = true;
					break;
				}
			}
			return nummeric;
		}

		public static bool isBinCommand(string exp)
		{
			return (exp == "P" || exp == "C" || exp == "•");
		}

		public static bool MatrixEquivalent (Matrix lhs, Matrix rhs) => (lhs.getRows()== rhs.getRows() && lhs.getColumns() == rhs.getColumns());
		public static bool MatrixLegalForMultiplication (Matrix lhs, Matrix rhs) => (lhs.getColumns() == rhs.getRows());

		public static bool isMinusIncludedInMatrix(string exp)
		{
			bool found = true;
			int counter = 0;
			string dumy = "";
			foreach (char x in exp) {
				if (x != ' ')
					dumy += x.ToString ();
			}
			foreach (char c in dumy) {
				if (c == '-' ) {
            	counter = dumy.IndexOf ('-');
					if (counter == 0) {
						if (dumy [counter + 1] == '[') {
							found = false; break;
						}
					} else if (dumy [counter - 1] == ']' || dumy [counter + 1] == '[') {
						found = false;break;
					}
				}
			}
			return found;
		}


		public static bool isComplexNumber (string exp) => exp.Contains("-");

	}    //end Checker class

	// This class is Responsible for matrix printing.
	public static class MatrixOutput
	{
		public static void Print(Matrix mat)
		{
			for (int c = 0; c < mat.getRows (); c++) {
				for (int c1 = 0; c1 < mat.getColumns (); c1++) {
					Console.Write ($"\t{mat.getElement(c+1,c1+1)}");
				}
				Console.WriteLine ("");
			}
		}
	}
}

