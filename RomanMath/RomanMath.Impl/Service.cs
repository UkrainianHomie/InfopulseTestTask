using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Linq;


namespace RomanMath.Impl
{
	public static class Service
	{
		/// <summary>
		/// See TODO.txt file for task details.
		/// Do not change contracts: input and output arguments, method name and access modifiers
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>

		private static readonly Dictionary<char, int> romanMap =
				new Dictionary<char, int> {
				{ 'I', 1 },
				{ 'V', 5 },
				{ 'X', 10 },
				{ 'L', 50 },
				{ 'C', 100 },
				{ 'D', 500 },
				{ 'M', 1000 }
				};

		public static int ToArabic(string expression) => expression.Length == 0 ? 0 : romanMap
		.Where(el => expression.StartsWith(el.Key))
		.Select(el => el.Value + ToArabic(expression.Substring(el.Key.ToString().Length)))
		.FirstOrDefault();


		public static int Evaluate(string expression)
		{
			if (string.IsNullOrEmpty(expression))
			{
				//throw new Exception("Expression must be not null or empty");
				return 0;
			}

			Regex isValidExpressionPattern =
				new Regex(@"^[\s\-\+\*IVXLCDM]+$",
				RegexOptions.Singleline);

			if (!isValidExpressionPattern.IsMatch(expression))
			{
				//throw new Exception("Invalid expression!");
				return 0;
			}

			expression = expression.Replace(" ", "");
			string romanCoupleDigits = null;
			string arabicExpr = "";

			for (int curr = 0; curr < expression.Length; curr++)
			{
				if (romanMap.ContainsKey(expression[curr]))
				{
					romanCoupleDigits += expression[curr];
					if (curr + 1 == expression.Length)
					{
						arabicExpr += ToArabic(romanCoupleDigits);
					}
				}
				else
				{
					if (!string.IsNullOrEmpty(romanCoupleDigits))
					{
						arabicExpr += ToArabic(romanCoupleDigits);
						arabicExpr += expression[curr];
						romanCoupleDigits = null;
					}
				}
			}

			DataTable dt = new DataTable();
			return (int)dt.Compute(arabicExpr, "");
		}
	}
}
