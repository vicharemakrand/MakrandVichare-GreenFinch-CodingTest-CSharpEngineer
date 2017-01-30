module AccountModule
{
    export class AccountModuleRoutes
    {
        static $inject = ["$routeProvider"];
        static ConfigureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            //$routeProvider
            //    .when( "/account",
            //    {
            //        controller: "AccountModule.Controllers.LoginController",
            //        templateUrl: "/MiniSpas/AccountModule/Views/login.html",
            //        controllerAs: "loginCtrl"
            //    })

            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}