using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		
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
				return null;
				//throw new Exception("Invalid point cases");
			}

			return rectangle;
		}
	}
}
