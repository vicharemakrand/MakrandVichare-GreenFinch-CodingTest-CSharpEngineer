/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

( (): void =>
{
    var newsLetterModule = MiniSpas.ModuleInitiator.GetModule( "NewsLetterModule" );
    newsLetterModule.config( NewsLetterModule.NewsLetterModuleRoutes.configureRoutes );

    newsLetterModule.config(( $httpProvider: ng.IHttpProvider ) =>
    {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    newsLetterModule.run( ['AccountModule.Services.AuthService', function ( authService: AccountModule.Services.AuthService )
    {
        authService.GetAuthData();
    }]);
})() 