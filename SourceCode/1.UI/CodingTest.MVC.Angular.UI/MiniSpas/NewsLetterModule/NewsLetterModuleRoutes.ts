module NewsLetterModule
{
    export class NewsLetterModuleRoutes
    {
        static $inject = ["$routeProvider"];
        static configureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                    .when( "/",
                            {
                                controller: "NewsLetterModule.Controllers.NewsLetterController",
                                templateUrl: "/MiniSpas/NewsLetterModule/Views/newsLetters.html",
                                controllerAs: "newsLetterCtrl"
                            }
                   );
            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}