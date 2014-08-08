using System.Web;
using System.Web.Optimization;

namespace WooURLMe
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.UseCdn = true;

			//Javascript Bundles
			bundles.Add(new ScriptBundle("~/bundles/jquery", "//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/knockout", "//cdnjs.cloudflare.com/ajax/libs/knockout/3.1.0/knockout-min.js").Include(
						"~/Scripts/knockout-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap", "//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js").Include(
						"~/Scripts/bootstrap.js",
						"~/Scripts/respond.js"));

			bundles.Add(new ScriptBundle("~/bundles/wooURL").Include("~/Scripts/wooUrl.js"));

			//CSS Bundles
			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/bootstrap", "//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css").Include(
						"~/Content/bootstrap.css"));

			bundles.Add(new StyleBundle("~/Content/fontawesome", "//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css").Include(
						"~/Content/font-awesome.css"));

			BundleTable.EnableOptimizations = true;
		}
	}
}
