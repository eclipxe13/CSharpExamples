using NUnit.Framework;
using System;

namespace PasswordChecker.Rules
{
	[TestFixture]
	public class LengthTest
	{

		[Test]
		public void LengthProperties ()
		{
			// no properties constructor
			Length o;
			o = new Length ();
			Assert.AreEqual (0, o.MinLength);
			Assert.AreEqual (0, o.MaxLength);
			// construct with only min property
			o = new Length (5);
			Assert.AreEqual (5, o.MinLength);
			Assert.AreEqual (0, o.MaxLength);
			// construct with both properties
			o = new Length (10, 20);
			Assert.AreEqual (10, o.MinLength);
			Assert.AreEqual (20, o.MaxLength);
		}

		[Test]
		public void LengthCaseNochecks ()
		{
			Length o = new Length (0, 0);
			Assert.True(o.Check (""));
			Assert.True(o.Check ("1234567890"));
		}

		[Test]
		public void LengthCaseMin ()
		{
			Length o = new Length (5, 0);
			Assert.False(o.Check ("123"));
			Assert.True(o.Check ("1234567890"));
		}

		[Test]
		public void LengthCaseMax ()
		{
			Length o = new Length (0, 5);
			Assert.True(o.Check ("12345"), "Valid length");
			Assert.False(o.Check ("123456"), "Invalid Length");
		}

	}
}

