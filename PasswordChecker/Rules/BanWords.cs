using System;
using System.Collections.Generic;

namespace PasswordChecker.Rules
{
	public class BanWords : IRuleInterface
	{
		SortedSet<string> words;

		public BanWords (IEnumerable<string> words)
		{
			this.words = (null == words) ? new SortedSet<string> () : new SortedSet<string> (words);
		}

		public BanWords () : this(null) { }

		public bool IgnoreCase = false;
		public bool PartialMatch = false;

		public SortedSet<string> Words
		{
			get { return this.words; }
		}

		public bool Check(string password)
		{
			return Check (password, IgnoreCase);
		}

		public bool Check(string password, bool ignorecase)
		{
			return Check (password, ignorecase, PartialMatch);
		}

		public bool Check(string password, bool ignorecase, bool partialmatch)
		{
			if (!partialmatch) {
				if (!ignorecase) {
					return CheckStrict (password);
				} else {
					return CheckCompleteIgnoringCase (password);
				}
			}
			return CheckPartial(password, ignorecase);
		}

		public bool CheckStrict(string password)
		{
			return !this.words.Contains (password);
		}

		public bool CheckCompleteIgnoringCase(string password)
		{
			foreach (string word in this.words) {
				if (password.Equals (word, StringComparison.OrdinalIgnoreCase)) {
					return false;
				}
			}
			return true;
		}

		public bool CheckPartial(string password, bool ignorecase)
		{
			foreach (string word in this.words) {
				if (password.IndexOf (word, (ignorecase) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0) {
					return false;
				}
			}
			return true;
		}

	}

}

