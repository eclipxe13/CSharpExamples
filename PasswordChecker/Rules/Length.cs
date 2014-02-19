using System;
using PasswordChecker;

namespace PasswordChecker.Rules
{
	public class Length : IRuleInterface
	{
		public int MinLength;
		public int MaxLength;

		public Length (int minlength, int maxlength)
		{
			this.MinLength = minlength;
			this.MaxLength = maxlength;
		}

		public Length (int minlength) : this(minlength, 0) { }

		public Length () : this(0, 0) { }

		public bool Check(string password)
		{
			return (this.MinLength <= 0 || password.Length >= this.MinLength)
				&& (this.MaxLength <= this.MinLength || password.Length <= this.MaxLength);
		}


	}
}

