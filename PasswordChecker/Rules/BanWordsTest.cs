using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PasswordChecker.Rules
{
	[TestFixture]
	public class BanWordsTest
	{
		[Test]
		public void TestConstructor()
		{
			BanWords o;
			// nothing
			o = new BanWords ();
			Assert.AreEqual (0, o.Words.Count);
			Assert.AreEqual (false, o.IgnoreCase);
			Assert.AreEqual (false, o.PartialMatch);
			// list<string>
			List<string> l = new List<string> ();
			l.Add ("foo");
			l.Add ("bar");
			l.Add ("baz");
			o = new BanWords (l);
			Assert.AreEqual (l.Count, o.Words.Count);
			// array
			o = new BanWords (new string[] {"abc", "def"});
			Assert.AreEqual (2, o.Words.Count);
		}

		[Test]
		public void CheckTestSimple()
		{
			BanWords o = new BanWords(new string[] {"foo", "BAR", "baz"});
			Assert.IsTrue (o.Check ("qwerty"));
			Assert.IsTrue (o.Check ("bar"));
			Assert.IsFalse (o.Check ("foo"));
			Assert.IsFalse (o.Check ("BAR"));
			Assert.IsTrue (o.Check ("foobazbar"));
			Assert.IsTrue (o.Check ("bAr"));
			Assert.IsTrue (o.Check ("ABAZA"));
		}

		[Test]
		public void CheckNullWord()
		{
			BanWords o = new BanWords ();
			o.Words.Add ("foo");
			o.Words.Add (null);
			o.Words.Add ("bar");
			Assert.AreEqual (3, o.Words.Count);
			Assert.IsTrue(o.Check ("some"), "This should not give any exception");
		}

		[Test]
		public void CheckTestIgnoreCase()
		{
			BanWords o = new BanWords(new string[] {"foo", "BAR", "baz"});
			o.IgnoreCase = true;
			Assert.IsTrue (o.Check ("qwerty"));
			Assert.IsFalse (o.Check ("bar"));
			Assert.IsFalse (o.Check ("FOO"));
			Assert.IsFalse (o.Check ("BAR"));
			Assert.IsTrue (o.Check ("ABAZA"));
			Assert.IsTrue (o.Check ("foobazbar"));
		}

		[Test]
		public void CheckTestPartial()
		{
			BanWords o = new BanWords(new string[] {"foo", "BAR", "baz"});
			o.PartialMatch = true;
			Assert.IsTrue (o.Check ("qwerty"));
			Assert.IsFalse (o.Check ("baz"));
			Assert.IsTrue (o.Check ("BAZ"));
			Assert.IsFalse (o.Check ("BARXX"));
			Assert.IsFalse (o.Check ("XXBAR"));
			Assert.IsFalse (o.Check ("XXBARXX"));
			Assert.IsTrue (o.Check ("XXbarXX"));
			Assert.IsTrue (o.Check ("XXB ARXX"));
		}

		[Test]
		public void CheckTestPartialIgnoreCase()
		{
			BanWords o = new BanWords(new string[] {"foo", "BAR", "baz"});
			o.PartialMatch = true;
			o.IgnoreCase = true;
			Assert.IsTrue (o.Check ("qwerty"));
			Assert.IsFalse (o.Check ("baz"));
			Assert.IsFalse (o.Check ("BAZ"));
			Assert.IsFalse (o.Check ("BARXX"));
			Assert.IsFalse (o.Check ("XXBAR"));
			Assert.IsFalse (o.Check ("XXBARXX"));
			Assert.IsFalse (o.Check ("XXbarXX"));
			Assert.IsTrue (o.Check ("XXB ARXX"));
		}

	}
}

