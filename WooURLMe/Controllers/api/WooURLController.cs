using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WooURLMe.DAL;
using WooURLMe.Core;
using WooURLMe.Models;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WooURLMe.Controllers.api
{
	public class WooURLController : ApiController
	{
		private WooURLContext db = new WooURLContext();

		public IHttpActionResult PostWooURL(JObject longUrlJson)
		{
			try
			{
				var longUrl = longUrlJson.GetValue("longUrl").ToString();
				var urlHashed = longUrl.SHA1Hash();
				var wooUrl = db.WooUrls.FirstOrDefault(w => w.LongURLHash == urlHashed);
				if (wooUrl == null)
				{
					//Create a new Woo URL since it doesn't exist
					wooUrl = new WooURL();
					wooUrl.LongURL = longUrl;
					wooUrl.LongURLHash = urlHashed;
					db.WooUrls.Add(wooUrl);
					db.SaveChanges();
					wooUrl.ShortWooURL = String.Format("{0}/{1}", HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority), BaseWoo.BaseWooEncode(wooUrl.WooURLID));
					db.SaveChanges();
				}

				return Ok(wooUrl.ShortWooURL);
			}
			catch
			{
				return StatusCode(HttpStatusCode.InternalServerError);
			}
			
		}

	}
}