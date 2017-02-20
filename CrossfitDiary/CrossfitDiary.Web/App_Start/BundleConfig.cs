﻿using System.Web.Optimization;

namespace CrossfitDiary.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                   .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-select/bootstrap-select.js",
                "~/Scripts/knockout-3.4.0.js",
                "~/Scripts/knockout.validation.js",
                "~/Scripts/ko.bindingHandlers.js",
                "~/Scripts/typings/q/q.min.js"));


            /*   --Crossfitter--   */
            
            /* Manage workout */
            bundles.Add(new ScriptBundle("~/bundles/crossfitter/manageWorkout")
                .Include(
                    "~/Scripts/jqueryPlugins/jquery.inputmask.bundle.min.js"
                    , "~/Scripts/bootstrap-datepicker/moment.min.js"
                    , "~/Scripts/bootstrap-datepicker/bootstrap-datetimepicker.min.js"
                    , "~/Scripts/Crossfitter/CrossfitterController.js"
                    , "~/Scripts/Crossfitter/SimpleRoutine.js"
                    , "~/Scripts/Crossfitter/ExerciseMeasureType.js"
                    , "~/Scripts/Crossfitter/WorkoutType.js"
                    , "~/Scripts/Crossfitter/ExerciseMeasureTypeValue.js"
                    , "~/Scripts/Crossfitter/CrossfitterService.js"
                    
                    , "~/Scripts/Crossfitter/ManageWorkout/CreateWorkoutController.js"
                    , "~/Scripts/Crossfitter/ManageWorkout/ChooseExistingWorkoutController.js"
                    , "~/Scripts/Crossfitter/ManageWorkout/LogWorkoutController.js"
                    , "~/Scripts/Crossfitter/ManageWorkout/ManageWorkoutController.js"
                ));

            /*   --Home--   */
            bundles.Add(new ScriptBundle("~/bundles/home")
                .Include("~/Scripts/Home/HomePageController.js"));


            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css"
                    , "~/Content/css/font-awesome.min.css"
                    , "~/Content/bootstrap-datepicker/bootstrap-datepicker.css"));

        }
    }
}