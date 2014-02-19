using System;

namespace PasswordChecker
{
	public interface IRuleInterface
	{
		bool Check(string text);
	}
}

