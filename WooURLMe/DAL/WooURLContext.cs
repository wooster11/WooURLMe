using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WooURLMe.Models;

namespace WooURLMe.DAL
{
	public class WooURLContext : DbContext
	{

		public WooURLContext()
			: base("WooURLConn")
		{
		}

		public DbSet<WooURL> WooUrls { get; set; }
		
	}
}