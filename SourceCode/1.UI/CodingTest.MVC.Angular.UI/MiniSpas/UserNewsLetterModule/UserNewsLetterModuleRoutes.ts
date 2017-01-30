module UserNewsLetterModule
{
    export class UserNewsLetterModuleRoutes
    {
        static $inject = ["$routeProvider"];
        static configureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                .when( "/",
                            {
                                controller: "UserNewsLetterModule.Controllers.UserNewsLetterController",
                                templateUrl: "/MiniSpas/UserNewsLetterModule/Views/userNewsLetters.html",
                                controllerAs: "userNewsLetterCtrl"
                            }
                );
            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}