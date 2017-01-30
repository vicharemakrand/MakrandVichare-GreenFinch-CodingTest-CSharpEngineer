
module NewsLetterModule.Services
{
    export class NewsLetterService implements NewsLetterModule.Interfaces.INewsLetterService
    {
        static $inject = ["$http"];
        constructor( private httpService: ng.IHttpService)
        {
        }

        GetTopNewsLetters(userId:number): ng.IPromise<any> 
        {
            var config = {
                params: { userId: userId  },
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/NewsLetters/GetTopNewsLetters', config );
        }

        GetNewsLetters ( searchParam: NewsLetterModule.ViewModels.INewsLetterParamVM): ng.IPromise<any> 
        {
            var config = {
                params:  searchParam ,
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/NewsLetters/GetNewsLetters', config );
        }

        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService ) => new NewsLetterService( $http );
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "NewsLetterModule" ).service( "NewsLetterModule.Services.NewsLetterService", NewsLetterService );
} 