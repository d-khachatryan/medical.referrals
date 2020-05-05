﻿using System.Web;
using System.Web.Optimization;

namespace Medicalreferrals
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                //"~/Scripts/jquery-{version}.js"
                "~/Scripts/kendo/2016.2.714/jquery.min.js"));
                        

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/reset.css",
            //          "~/Content/bootstrap.css",
            //          "~/Content/style.css",
            //          "~/Content/jquery.mmenu.all.css",
            //          "~/Content/site.css").Include(
            //    "~/Content/font-awesome/css/font-awesome.min.css",
            //    new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/reset.css",
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/jquery.mmenu.all.css",
                      "~/Content/site.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/font-awesome/css/css").Include(
                      "~/Content/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/kendo/2016.2.714/kendo").Include(
                     "~/Content/kendo/2016.2.714/kendo.common.min.css",
                     "~/Content/kendo/2016.2.714/kendo.mobile.all.min.css",
                     "~/Content/kendo/2016.2.714/kendo.dataviz.min.css",
                     "~/Content/kendo/2016.2.714/kendo.metro.min.css",
                     "~/Content/kendo/2016.2.714/kendo.dataviz.default.min.css"));

            //Kendo Scripts
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        //"~/Scripts/kendo/2016.2.714/jquery.min.js",
                        "~/Scripts/kendo/2016.2.714/jszip.min.js",
                        "~/Scripts/kendo/2016.2.714/kendo.all.min.js",
                        "~/Scripts/kendo/2016.2.714/kendo.aspnetmvc.min.js",
                        "~/Scripts/kendo.modernizr.custom.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/mmenu").Include(
                        "~/Scripts/jquery.mmenu.all.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/site.js"));
        }
    }
}
