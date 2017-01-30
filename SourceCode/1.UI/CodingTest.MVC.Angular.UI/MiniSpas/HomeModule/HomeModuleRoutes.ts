module HomeModule
{
    export class HomeModuleRoutes
    {
        static $inject = ["$routeProvider"];
        static ConfigureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                .when( "/",
                {
                    controller: "AccountModule.Controllers.SignupController",
                    templateUrl: "/MiniSpas/AccountModule/Views/signup.html",
                    controllerAs: "signupCtrl"
                })
                .when( "/home",
                {
                    controller: "HomeModule.Controllers.HomeController",
                    templateUrl: "/MiniSpas/HomeModule/Views/home.html",
                    controllerAs: "homeCtrl"
                })
                .when( "/login",
                {
                    controller: "AccountModule.Controllers.LoginController",
                    templateUrl: "/MiniSpas/AccountModule/Views/login.html",
                    controllerAs: "loginCtrl"
                })
                .when( "/signup",
                {
                    controller: "AccountModule.Controllers.SignupController",
                    templateUrl: "/MiniSpas/AccountModule/Views/signup.html",
                    controllerAs: "signupCtrl"
                });

            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}