/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

((): void =>
{
    var accountModule = MiniSpas.ModuleInitiator.GetModule( "AccountModule" );

    accountModule.config( AccountModule.AccountModuleRoutes.ConfigureRoutes );
    accountModule.config( ( $httpProvider: ng.IHttpProvider ) =>
    {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    accountModule.run( ['AccountModule.Services.AuthService', function ( authService: AccountModule.Services.AuthService )
    {
        authService.GetAuthData();
    }]);
})() 