using System;
using System.Reflection;

namespace CSharpExamples
{

	class Foo
	{
		private string text;

		public Foo(string text)
		{
			this.text = text;
		}

		public string getLowerText()
		{
			return this.text.ToLower();
		}

	}

	class AccessingPrivates
	{
		public static void Main (string[] args)
		{
			Foo f = new Foo ("SaMpLe TeXt");
			Console.WriteLine (f.getLowerText ());
			FooOverridePrivateText (f, "text", "foo bar baz quz");
			Console.WriteLine (f.getLowerText ());
		}

		public static void FooOverridePrivateText(object f, string name, string value)
		{
			Type type = f.GetType();
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;
			FieldInfo field = type.GetField (name, flags);
			field.SetValue (f, value);
		}




	}
}
