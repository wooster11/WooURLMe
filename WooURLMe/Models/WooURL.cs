using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooURLMe.Models
{
	public class WooURL
	{
		public int WooURLID { get; set; }
		public string LongURL { get; set; }
		public string ShortWooURL { get; set; }
		public string LongURLHash { get; set; }
	}
}