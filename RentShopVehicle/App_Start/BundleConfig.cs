using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RentShopVehicle.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //styles
            bundles.Add(new StyleBundle("~/bundles/bootstrap/min/css").Include(
                "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                "~/Content/font-awesome.min.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/elegant-icons/css").Include(
                "~/Content/elegant-icons.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/nice-select/css").Include(
                "~/Content/nice-select.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include(
                "~/Content/magnific-popup.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/jquery-ui/css").Include(
                "~/Content/jquery-ui.min.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/carousel/css").Include(
                "~/Content/owl.carousel.min.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/slicknav/css").Include(
                "~/Content/slicknav.min.css", new CssRewriteUrlTransform())); 
            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                "~/Content/style.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/second_main/css").Include(
                "~/Content/other/style.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/other/materialdesignicons.min/css").Include(
                "~/Content/other/materialdesignicons.min.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/other/style1/css").Include(
                "~/Content/other/style1.css", new CssRewriteUrlTransform()));

            //scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery-331/js").Include(
                "~/Scripts/jquery-3.3.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/min/js").Include(
                "~/Scripts/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-nice-select/js").Include(
                "~/Scripts/jquery.nice-select.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui/js").Include(
                "~/Scripts/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-magnific-popup/js").Include(
                "~/Scripts/jquery.magnific-popup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/mixitup/js").Include(
                "~/Scripts/mixitup.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-slicknav/js").Include(
                "~/Scripts/jquery.slicknav.js"));
            bundles.Add(new ScriptBundle("~/bundles/carousel/js").Include(
                "~/Scripts/owl.carousel.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/other/dashboard/js").Include(
                "~/Scripts/dashboard.js"));//dashboard
            bundles.Add(new ScriptBundle("~/bundles/other/hoverable-collapse/js").Include(
                "~/Scripts/hoverable-collapse.js"));//hoverable-collapse
            bundles.Add(new ScriptBundle("~/bundles/other/Chart.min/js").Include(
                "~/Scripts/Chart.min.js"));//Chart.min
            bundles.Add(new ScriptBundle("~/bundles/other/misc/js").Include(
                "~/Scripts/misc.js"));//misc
            bundles.Add(new ScriptBundle("~/bundles/other/off-canvas/js").Include(
                "~/Scripts/off-canvas.js"));//off-canvas
            bundles.Add(new ScriptBundle("~/bundles/other/progressbar.min/js").Include(
                "~/Scripts/progressbar.min.js"));//progressbar.min
            bundles.Add(new ScriptBundle("~/bundles/other/settings/js").Include(
                "~/Scripts/settings.js"));//settings
            bundles.Add(new ScriptBundle("~/bundles/other/todolist/js").Include(
                "~/Scripts/todolist.js"));//todolist
            bundles.Add(new ScriptBundle("~/bundles/other/vendor.bundle.base/js").Include(
                "~/Scripts/vendor.bundle.base.js"));//vendor.bundle.base
            bundles.Add(new ScriptBundle("~/bundles/other/jquery-jvectormap-world-mill-en/js").Include(
                "~/Scripts/jquery-jvectormap-world-mill-en.js"));//jquery-jvectormap-world-mill-en
            bundles.Add(new ScriptBundle("~/bundles/other/jquery-jvectormap.min/js").Include(
                "~/Scripts/jquery-jvectormap.min.js"));//jquery-jvectormap.min
        }
    }
}