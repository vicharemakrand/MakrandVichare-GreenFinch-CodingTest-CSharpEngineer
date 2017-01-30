/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

((): void =>
{
    var homeModule = MiniSpas.ModuleInitiator.GetModule( "HomeModule" );

    homeModule.config( HomeModule.HomeModuleRoutes.ConfigureRoutes );
    homeModule.config( ( $httpProvider: ng.IHttpProvider ) =>
    {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    homeModule.run( ['AccountModule.Services.AuthService', function ( authService: AccountModule.Services.AuthService )
    {
        authService.GetAuthData();
    }] );
})() 