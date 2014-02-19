using System;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace PasswordChecker.Rules
{
	[TestFixture]
	public class RegularExpTest
	{
		[Test]
		public void ConstructorTest()
		{
			RegularExp e;
			// default constructor
			e = new RegularExp ();
			Assert.IsNull (e.Expression);
			Assert.AreEqual (0, e.MinCount);
			Assert.AreEqual (0, e.MaxCount);
			// full properties
			Regex r = new Regex ("[a-z]");
			e = new RegularExp (r, 2, 40);
			Assert.AreSame(r, e.Expression);
			Assert.AreEqual (2, e.MinCount);
			Assert.AreEqual (40, e.MaxCount);
		}

		[Test]
		public void CheckLowers()
		{
			// alpha lower case, no less than 2, no more than 4
			RegularExp e = new RegularExp (new Regex ("[a-z]"), 2, 4);
			Assert.IsFalse(e.Check("12345667123"), "only numbers");
			Assert.IsTrue(e.Check("123qwe123"), "3 chars");
			Assert.IsTrue(e.Check("123qweAAA123"), "3 chars + 3 upper");
			Assert.IsFalse(e.Check("0a10"), "1 chars");
			Assert.IsTrue(e.Check("0ax0"), "2 chars");
			Assert.IsTrue(e.Check("0abcx0"), "4 chars");
			Assert.IsFalse(e.Check("0a1b2c3d4e50"), "5 chars");
		}
	}
}

