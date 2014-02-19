using System;

namespace PasswordChecker.Rules
{
	public class SecuentialChars : IRuleInterface
	{
		public int MaxSecuential;

		public SecuentialChars (int maxsecuential)
		{
			this.MaxSecuential = maxsecuential;
		}

		public SecuentialChars () : this(0) {}

		public bool Check(string password)
		{
			if (2 > MaxSecuential) {
				return true;
			}
			int count = 0;
			for (int i = 1 ; i < password.Length ; i++) {
				if (password [i] == password [i - 1]) {
					if (++count == this.MaxSecuential - 1) {
						return false;
					}
				} else {
					count = 0;
				}
			}
			return true;
		}

	}
}

