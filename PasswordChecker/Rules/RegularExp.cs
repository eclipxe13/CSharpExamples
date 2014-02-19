using System;
using System.Text.RegularExpressions;
using PasswordChecker;

namespace PasswordChecker.Rules
{
	public class RegularExp : IRuleInterface
	{
		private Regex expression;

		public int MinCount;
		public int MaxCount;

		public RegularExp (Regex expression, int mincount, int maxcount)
		{
			this.expression = expression;
			this.MinCount = mincount;
			this.MaxCount = maxcount;
		}

		public RegularExp (Regex expression, int mincount) : this(expression, mincount, 0) { }

		public RegularExp (Regex expression) : this(expression, 0, 0) { }

		public RegularExp () : this(null, 0) { }

		public Regex Expression 
		{
			get { return this.expression; }
		}

		public bool Check(string password)
		{
			if (null == expression || (MinCount < 1 && MaxCount < 1)) {
				return true;
			}
			int count = expression.Matches (password).Count;
			return ((MinCount < 1 || count >= MinCount)
			        && (MaxCount < 1 || count <= MaxCount));
		}
	}
}

