using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Console
{
	public sealed class Rectangle
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}

	public sealed class Point
	{
		public Point(int x, int y) 
		{
			X = x;
			Y = y;
		}

		public int X { get; set; }
		public int Y { get; set; }
	}

	class Program
	{

		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in Rectangle.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Random rnd = new Random();
			var rectangle = FindRectangle(new[] {
				new Point(10,10),
				new Point(10,10)
			}.ToList());
            System.Console.WriteLine(rectangle);


		}

		public static Rectangle FindRectangle(List<Point> points)
		{
			if (points == null || !points.Any()) 
			{
				return null;
				//throw new Exception("Empty points list");
			}

			if (points.Count < 2) 
			{
				return null;
				//throw new Exception("Should contain at least two points");
			}

			bool isUniquePoints = points.Count() == points.GroupBy(p => new { p.X, p.Y })
				.Select(g => g.First())
				.Distinct()
				.Count();

			if (!isUniquePoints) 
			{
				return null;
				//throw new Exception("Non-unique points");
			}

			Rectangle rectangle = new Rectangle();
			try
			{
				rectangle.X = points.Min(d => d.X);
				rectangle.Y = points.Max(d => d.Y);
				rectangle.Width = Math.Abs(rectangle.X) + Math.Abs(points.Max(d => d.X - 1));
				rectangle.Height = Math.Abs(rectangle.Y) + Math.Abs(points.Min(d => d.Y));
			}
			catch (Exception) 
			{
				throw new Exception("Invalid point cases");
			}

			return rectangle;		
		}
	}
}
