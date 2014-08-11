using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooURLMe.Models
{
	public class Home
	{
		public bool IsBadRedirect { get; set; }
		public string URLAttempted { get; set; }
	}
}