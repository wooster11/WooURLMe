using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooURLMe.Core;
using WooURLMe.DAL;
using WooURLMe.Models;

namespace WooURLMe.Controllers
{
	public class HomeController : Controller
	{
		private WooURLContext db = new WooURLContext();

		public ActionResult Index()
		{
			var homeModel = new Home() { IsBadRedirect = false, URLAttempted = HttpContext.Request.Url.AbsoluteUri };
			try
			{
				//Get the path of the URL
				var abPath = HttpContext.Request.Url.AbsolutePath;

				if (abPath.StartsWith("/"))
					abPath = abPath.Substring(1);

				if (String.IsNullOrWhiteSpace(abPath))
					return View(homeModel);

				var wooUrlID = BaseWoo.BaseWooDecode(abPath);
				
				var wooUrl = db.WooUrls.FirstOrDefault(w => w.WooURLID == wooUrlID);

				if (wooUrl == null)
				{
					homeModel.IsBadRedirect	= true;
					return View(homeModel);
				}
				else
					return Redirect(wooUrl.LongURL);
			}
			catch (Exception e)
			{
				Trace.WriteLine(String.Format("Redirect Failure: {0} | {1}", e.Message, HttpContext.Request.Url.AbsoluteUri), "Error");
				homeModel.IsBadRedirect = true;
				return View(homeModel);
			}			
		}
	}
}
