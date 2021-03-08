using NUnit.Framework;
using RomanMath.Impl;
using System;

namespace RomanMath.Tests
{
	[TestFixture]
	public class Tests
	{
		[SetUp]
		public void Setup() { }

		[Test]
		public void RomanMathServiceTest()	
		{
			Func<string, int> _serviceEvaluate = Service.Evaluate;

			Assert.AreEqual(0, _serviceEvaluate(""));
			Assert.AreEqual(0, _serviceEvaluate(null));
			Assert.AreEqual(0, _serviceEvaluate("A"));
			Assert.AreEqual(0, _serviceEvaluate("1"));
			Assert.AreEqual(0, _serviceEvaluate("A+B"));
			Assert.AreEqual(0, _serviceEvaluate("1+2"));
			Assert.AreEqual(0, _serviceEvaluate("I+A"));
			Assert.AreEqual(0, _serviceEvaluate("V + II/2"));
			Assert.AreEqual(0, _serviceEvaluate("1.2"));

			Assert.AreEqual(12, _serviceEvaluate("VIIIII + II"));
			Assert.AreEqual(12, _serviceEvaluate("XII - I + I"));
			Assert.AreEqual(100, _serviceEvaluate("XX * V"));
			Assert.AreEqual(2, _serviceEvaluate("I+II-I"));
			Assert.AreEqual(2, _serviceEvaluate("I   +   II    -   I"));
			Assert.AreEqual(5, _serviceEvaluate("X - V"));
			Assert.AreEqual(0, _serviceEvaluate("Ì - D * II"));
			Assert.AreEqual(-50, _serviceEvaluate("L - X * X"));
		}
	}
}