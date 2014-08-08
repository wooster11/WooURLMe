using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooURLMe.Core
{
	public class BaseWoo
	{
		private const string BASEWOOCHARACTERS = "KJbP6hf8vFBDrYzLGdkTQtp9ZcC2Hl4wxnNgMyjm5Vs7qW31RXS";

		public static string BaseWooEncode(int numberToConvert)
		{
			var chars = new List<char>();
			do
			{
				chars.Add(BASEWOOCHARACTERS[numberToConvert % BASEWOOCHARACTERS.Length]);
				numberToConvert /= BASEWOOCHARACTERS.Length;
			} while (numberToConvert > 0);

			chars.Reverse(); //Reverse for proper base encoding

			return new string(chars.ToArray());
		}

		public static int BaseWooDecode(string baseWooEncodedString)
		{
			double decodedValue = 0;
			int power = 0;

			foreach (char c in baseWooEncodedString.Reverse()) //Reverse the string for proper calculation of decoder
			{
				decodedValue += BASEWOOCHARACTERS.IndexOf(c) * Math.Pow(BASEWOOCHARACTERS.Length, power);
				power++; //Increment the power value for calculation
			}

			return Convert.ToInt32(decodedValue);
		}
	}
}