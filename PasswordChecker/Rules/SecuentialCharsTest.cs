using System;
using PasswordChecker;
using NUnit.Framework;

namespace PasswordChecker.Rules
{
	[TestFixture]
	public class SecuentialCharsTest
	{
		[Test]
		public void CheckConstructor ()
		{
			SecuentialChars s;
			// default creation
			s = new SecuentialChars();
			Assert.AreEqual (0, s.MaxSecuential);
			// with a value
			s = new SecuentialChars(3);
			Assert.AreEqual (3, s.MaxSecuential);
		}

		[Test]
		public void CheckValidations()
		{
			SecuentialChars s = new SecuentialChars (3);
			Assert.IsTrue(s.Check("qwerty"));
			Assert.IsFalse(s.Check("qweeeerty"));
			Assert.IsFalse(s.Check("qweeerty"));
			Assert.IsTrue(s.Check("qweerty"));
			Assert.IsFalse(s.Check("aaa123456"));
			Assert.IsFalse(s.Check("123456aaa"));
			s.MaxSecuential = 2;
			Assert.IsFalse(s.Check("qweerty"));
			s.MaxSecuential = 1;
			Assert.IsTrue(s.Check("qwerty"));
		}
	}
}

