using System;
using System.Collections.Generic;

namespace PasswordChecker
{
	public class PasswordChecker
	{
		public PasswordChecker ()
		{
			this._rules = new List<IRuleInterface> ();
		}

		private List<IRuleInterface> _rules;

		public List<IRuleInterface> Rules {
			get { return this._rules; }
		}

		public bool Check(string text)
		{
			if (String.IsNullOrWhiteSpace (text)) {
				return false;
			}
			foreach (IRuleInterface rule in this._rules) {
				if (null != rule && !rule.Check (text)) {
					return false;
				}
			}
			return true;
		}


	}
}

