using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WooURLMe.Core
{
	public static class StringExtensions
	{
		public static string SHA1Hash(this string valueToHash)
		{
			var bytes = new byte[valueToHash.Length * sizeof(char)];
			System.Buffer.BlockCopy(valueToHash.ToCharArray(), 0, bytes, 0, bytes.Length);

			using (var sha = new SHA1Managed())
			{
				return BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", "");
			}
		}
	}
}