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
            bundles.Add(new StyleBundle("~/bundles/tempusdominus/css").Include(
                "~/Content/other/tempusdominus-bootstrap-4.min.css", new CssRewriteUrlTransform()));


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

            bundles.Add(new Bundle("~/bundles/other/chart-min/js").Include(
                "~/Scripts/other/chart.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/easing-min/js").Include(
                "~/Scripts/other/easing.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/moment-timezone-min/js").Include(
                "~/Scripts/other/moment-timezone.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/moment-min/js").Include(
                "~/Scripts/other/moment.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/owl-carousel-min/js").Include(
                "~/Scripts/other/owl.carousel.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/tempusdominus-bootstrap4min/js").Include(
                "~/Scripts/other/tempusdominus-bootstrap-4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/waypoints-min/js").Include(
                "~/Scripts/other/waypoints.min.js"));
            bundles.Add(new Bundle("~/bundles/bootstrap-bundle-min/js").Include(
                "~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-371/js").Include(
                "~/Scripts/jquery-3.7.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/other/second-main/js").Include(
                "~/Scripts/other/main.js"));
        }
    }
}