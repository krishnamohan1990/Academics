using System.Web;
using System.Web.Optimization;

namespace MvcApp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
	    public static void RegisterBundles(BundleCollection bundles)
	    {
		    bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
			    "~/Scripts/jquery-1.11.2.js",
			    "~/Scripts/jquery-migrate-1.2.1.min.js",
			    "~/Scripts/jquery.unobtrusive-ajax.js",
			    "~/Scripts/commonscript.js"));
		    bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui.js"));

		    bundles.Add(new ScriptBundle("~/bundles/jqueryvalidate").Include(
			    "~/Scripts/jquery.unobtrusive*",
			    "~/Scripts/jquery.validate*"));

		    // Use the development version of Modernizr to develop with and learn from. Then, when you're
		    // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
		    bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
			    "~/Scripts/modernizr-*"));

		    bundles.Add(new StyleBundle("~/Styles/bootstrap").Include(
				"~/Content/Stylesheets/bootstrap/bootstrap.css",
				"~/Content/Stylesheets/bootstrap/bootstrap-dialog.css",
				 "~/Styles/Site.css",
				"~/Styles/InputControls.css"
				));
		    bundles.Add(new StyleBundle("~/Styles/menu").Include("~/Styles/Menu/menu.css"));
		    bundles.Add(new StyleBundle("~/Styles/Layout").Include("~/Styles/MainLayout.css"));
		    bundles.Add(new StyleBundle("~/Styles/TableStyles").Include("~/Styles/TableStyle.css"));
		    bundles.Add(new StyleBundle("~/Styles/datepicker").Include(
			    "~/Styles/themes/base/jquery.ui.css",
			    // "~/Styles/themes/base/jquery-ui.css",
			    // "~/Styles/themes/base/jquery-ui.theme.css",
			    "~/Styles/themes/base/jquery.ui.theme.css",
			    "~/Styles/themes/base/jquery-ui.structure.css",
			    "~/Styles/themes/base/jquery.ui.datepicker.css",
			    "~/Styles/themes/base/dataTables.jqueryui.css"
			    ));

		    bundles.Add(new StyleBundle("~/Styles/jquery").Include(
			    "~/Styles/themes/base/jquery-ui.css",
			    "~/Styles/themes/base/jquery-ui.theme.css",
			    "~/Styles/themes/base/jquery-ui.structure.css",
			    "~/Styles/themes/base/jquery.ui.core.css",
			    "~/Styles/themes/base/jquery.ui.resizable.css",
			    "~/Styles/themes/base/jquery.ui.selectable.css",
			    "~/Styles/themes/base/jquery.ui.accordion.css",
			    "~/Styles/themes/base/jquery.ui.autocomplete.css",
			    "~/Styles/themes/base/jquery.ui.button.css",
			    "~/Styles/themes/base/jquery.ui.dialog.css",
			    "~/Styles/themes/base/jquery.ui.slider.css",
			    "~/Styles/themes/base/jquery.ui.tabs.css",
			    "~/Styles/themes/base/jquery.ui.datepicker.css",
			    "~/Styles/themes/base/jquery.ui.progressbar.css",
			    "~/Styles/themes/base/Style.css"));

		    bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
			    "~/Scripts/bootstrap-alert.js",
			    "~/Scripts/bootstrap-button.js",
			    "~/Scripts/bootstrap-carousel.js",
			    "~/Scripts/bootstrap-collapse.js",
			    "~/Scripts/bootstrap-dropdown.js",
			    "~/Scripts/bootstrap-modal.js",
			    "~/Scripts/bootstrap-dialog.js",
			    "~/Scripts/bootstrap-scrollspy.js",
			    "~/Scripts/bootstrap-tab.js",
			    "~/Scripts/bootstrap-tooltip.js",
			    //"~/Scripts/bootstrap-transition.js",
			    "~/Scripts/bootstrap-typeahead.js"
			    //"~/Scripts/bootstrapPager.js"));
			    ));
	    }
    }
}