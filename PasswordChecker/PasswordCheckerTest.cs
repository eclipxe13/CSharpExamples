using NUnit.Framework;
// using PasswordChecker;

namespace PasswordChecker
{
	[TestFixture]
	public class PasswordCheckerTest
	{
		[Test]
		public void CheckWithNoRules ()
		{
			PasswordChecker pc = new PasswordChecker ();
			Assert.False(pc.Check(null), "No null values");
			Assert.False(pc.Check(""), "No empty values");
			Assert.False(pc.Check(" "), "No white space values");
			Assert.True(pc.Check("abc"), "abc is ok");
		}

		[Test]
		public void CheckWithOneRule()
		{
			PasswordChecker pc = new PasswordChecker ();
			Assert.True(pc.Check("123"), "3 chars is ok");
			pc.Rules.Add (new Rules.Length (4, 10));
			Assert.False(pc.Check("123"), "No less than 3 chars");
			Assert.False(pc.Check("12345678901"), "No more than 10 chars");
			Assert.True(pc.Check("1234"), "4 is ok");
			Assert.True(pc.Check("1234567890"), "10 is ok");
			Assert.True(pc.Check("1234567"), "7 is ok");
		}

		[Test]
		public void CheckRuleNull()
		{
			PasswordChecker pc = new PasswordChecker ();
			pc.Rules.Add (null);
			Assert.AreEqual (1, pc.Rules.Count);
			pc.Check ("bazinga");
		}
	}
}
