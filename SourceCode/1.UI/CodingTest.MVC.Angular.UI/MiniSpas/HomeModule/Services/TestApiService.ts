
module HomeModule.Services
{
    export class TestApiService implements HomeModule.Interfaces.ITestApiService
    {
        static $inject = ["$http","$location"];
        constructor( private httpService: ng.IHttpService)
        {
        }

        GetTestValuesList(): ng.IPromise<any> 
        {
            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/TestApi' );
        }

        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService ) => new TestApiService( $http );
            return instance;
        }
   }

    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).service( "HomeModule.Services.TestApiService", TestApiService);
} 