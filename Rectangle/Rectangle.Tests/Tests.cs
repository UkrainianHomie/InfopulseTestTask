using System;
using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	[TestFixture]
	public class Tests
	{
		private Impl.Rectangle _rectangle;

		[SetUp]
		public void Setup()
		{
			_rectangle = new Impl.Rectangle();
		}


		[Test]
		public void UniqueList()
		{
			Random rnd = new Random();
			var rectangle = Service.FindRectangle(new[] { 
				new Point(10,10),
				new Point(10,10)
			}.ToList());

			Assert.AreEqual(null, rectangle);

			
			rectangle = Service.FindRectangle(new[] {
				new Point(10,10),
				new Point(rnd.Next(),rnd.Next()),
				new Point(rnd.Next(),rnd.Next()),
				new Point(rnd.Next(),rnd.Next()),
				new Point(rnd.Next(),rnd.Next()),
				new Point(rnd.Next(),rnd.Next()),
				new Point(10,10)
			}.ToList());

			Assert.AreEqual(null, rectangle);
		}

		[Test]
		public void NullInput()
		{
			Random rnd = new Random();
			var rectangle = Service.FindRectangle(null);

			Assert.AreEqual(null, rectangle);
		}

		[Test]
		public void MinCountOPoints()
		{
			Random rnd = new Random();
			var rectangle = Service.FindRectangle(new[] {
				new Point(10,10),
			}.ToList());

			Assert.AreEqual(null, rectangle);

		}
	}
}