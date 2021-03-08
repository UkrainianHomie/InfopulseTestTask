using System;
using RomanMath.Impl;

namespace expressionMath
{
	class Program
	{
		/// <summary>
		/// Use this method for local debugging only. The implementation should remain in expressionMath.Impl project.
		/// See TODO.txt file for task details.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
	
			var result = Service.Evaluate("I - VIII");
            Console.WriteLine(result);
			Console.ReadLine();
		}

		
	}
}

