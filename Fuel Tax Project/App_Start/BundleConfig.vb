Imports System.Web.Optimization

Public Module BundleConfig
    ' For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Use the development version of Modernizr to develop with and learn from. Then, when you're
        ' ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css",
                  "~/Content/bootstrap-responsive.css"))
        bundles.Add(New StyleBundle("~/Content/map").Include(
                    "~/Content/mapstyle.css"))

        ' jqplot bundle

        bundles.Add(New StyleBundle("~/Content/Plugins/JQplot/CSS").Include(
                    "~/Content/jplot/jquery.jqplot.css"))

        bundles.Add(New ScriptBundle("~/Content/Plugins/JQplot/JS").Include(
                    "~/Content/jplot/jquery.jqplot.js",
                    "~/Content/jplot/jqplot.barRenderer.js",
                    "~/Content/jplot/jqplot.highlighter.js",
                    "~/Content/jplot/jqplot.pointLabels.js",
                    "~/Content/jplot/jqplot.cursor.js"))
        bundles.Add(New ScriptBundle("~/Content/Plugins/highchart").Include(
                    "~/Content/highcharts/highcharts.js",
                    "~/Content/highcharts/highcharts-more.js",
                    "~/Content/highcharts/highcharts-convert.js",
                    "~/Content/highcharts/data.js",
                    "~/Content/highcharts/exporting.js",
                    "~/Content/highcharts/export-csv.js"))
        bundles.Add(New ScriptBundle("~/Content/Plugins/excelexport").Include(
                    "~/Content/excelexport/jquery.btechco.excelexport.js"))
    End Sub
End Module

