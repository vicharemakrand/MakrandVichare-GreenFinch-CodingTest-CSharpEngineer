using System.Web.Optimization;

namespace CodingTest.MVC.Angular.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
            "~/Scripts/angular.js",
            "~/Scripts/angular-cookies.js",
            "~/Scripts/angular-route.js",
            "~/Scripts/angular-local-storage.js",
            "~/Scripts/loading-bar.js",
            "~/Scripts/angular-messages.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css",
            "~/Content/loading-bar.css"
            ));
      
            #region "common module Section"

            bundles.Add(new ScriptBundle("~/bundles/common-modules").Include(
                "~/MiniSpas/ModuleInitiator.js",
                "~/MiniSpas/Common/AppConstants.js",
                "~/MiniSpas/Common/BaseController.js",
                "~/MiniSpas/Common/AuthenticationInterceptor.js",
                "~/MiniSpas/Common/LocalizationService.js"
            ));

            //bundles.Add(new ScriptBundle("~/bundles/common-viewmodels").Include(
            //    "~/MiniSpas/Common/IBaseVM.js",
            //    "~/MiniSpas/Common/IDictionary.js",
            //    "~/MiniSpas/Common/IMessageVM.js",
            //   "~/MiniSpas/Common/ILocalizationService.js"
            //));

            bundles.Add(new ScriptBundle("~/bundles/common-directives").Include(
                "~/MiniSpas/Common/Directives/AntiForgeryTokenDirective.js"
            ));

            #endregion

            #region "Home module section"

            bundles.Add(new ScriptBundle("~/bundles/home-modules").Include(
                "~/MiniSpas/HomeModule/HomeModuleRoutes.js",
                "~/MiniSpas/HomeModule/HomeModuleApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-services").Include(
                "~/MiniSpas/HomeModule/Services/TestApiService.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/home-controllers").Include(
                "~/MiniSpas/HomeModule/Controllers/HomeController.js"
            ));

            #endregion

            #region "Account module Section"

            //bundles.Add(new ScriptBundle("~/bundles/account-modules").Include(
            //    "~/MiniSpas/AccountModule/AccountModuleRoutes.js",
            //    "~/MiniSpas/AccountModule/AccountModuleApp.js"
            //));

            bundles.Add(new ScriptBundle("~/bundles/account-services").Include(
                "~/MiniSpas/AccountModule/Services/AuthService.js",
                "~/MiniSpas/AccountModule/Services/AuthInterceptorService.js"
            ));

            //bundles.Add(new ScriptBundle("~/bundles/account-viewmodels").Include(
            //    "~/MiniSpas/AccountModule/ViewModels/IAuthenticationVM.js",
            //    "~/MiniSpas/AccountModule/ViewModels/IAuthorizationVM.js",
            //    "~/MiniSpas/AccountModule/ViewModels/ILoginVM.js",
            //    "~/MiniSpas/AccountModule/ViewModels/ISignUpVM.js",
            //    "~/MiniSpas/AccountModule/ViewModels/IUserVM.js"
            //));

            bundles.Add(new ScriptBundle("~/bundles/account-controllers").Include(
                "~/MiniSpas/AccountModule/Controllers/LoginController.js",
                "~/MiniSpas/AccountModule/Controllers/SignupController.js"
            ));

            #endregion

            #region "User newsLetter module Section"

            bundles.Add(new ScriptBundle("~/bundles/userNewsLetter-modules").Include(
            "~/MiniSpas/UserNewsLetterModule/UserNewsLetterModuleRoutes.js",
            "~/MiniSpas/UserNewsLetterModule/UserNewsLetterModuleApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/userNewsLetter-services").Include(
            "~/MiniSpas/UserNewsLetterModule/Services/UserNewsLetterService.js"
            ));

            //bundles.Add(new ScriptBundle("~/bundles/userNewsLetter-viewmodels").Include(
            //"~/MiniSpas/UserNewsLetterModule/ViewModels/IUserNewsLetterVM.js"
            //));

            bundles.Add(new ScriptBundle("~/bundles/userNewsLetter-controllers").Include(
                "~/MiniSpas/UserNewsLetterModule/Controllers/UserNewsLetterController.js"
            ));

            #endregion

            #region "NewsLetter module Section"

            bundles.Add(new ScriptBundle("~/bundles/newsLetter-modules").Include(
            "~/MiniSpas/NewsLetterModule/NewsLetterModuleRoutes.js",
            "~/MiniSpas/NewsLetterModule/NewsLetterModuleApp.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/newsLetter-services").Include(
            "~/MiniSpas/NewsLetterModule/Services/NewsLetterService.js"
            ));

            //bundles.Add(new ScriptBundle("~/bundles/newsLetter-viewmodels").Include(
            //"~/MiniSpas/NewsLetterModule/ViewModels/INewsLetterListVM.js"
            //));

            bundles.Add(new ScriptBundle("~/bundles/newsLetter-controllers").Include(
                "~/MiniSpas/NewsLetterModule/Controllers/NewsLetterController.js"
            ));

            #endregion

        }
    }
}
