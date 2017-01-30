/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

( (): void =>
{
    var userNewsLetterModule = MiniSpas.ModuleInitiator.GetModule( "UserNewsLetterModule" );
    userNewsLetterModule.config( UserNewsLetterModule.UserNewsLetterModuleRoutes.configureRoutes );

    userNewsLetterModule.config( function ( $httpProvider: ng.IHttpProvider )
    {
         $httpProvider.defaults.withCredentials = true;
         $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    userNewsLetterModule.run( ['AccountModule.Services.AuthService', function ( authService: AccountModule.Services.AuthService )
    {
        authService.GetAuthData();
    }]);

})();