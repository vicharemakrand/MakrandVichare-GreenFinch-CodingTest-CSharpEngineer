
module UserNewsLetterModule.Services
{
    export class UserNewsLetterService implements UserNewsLetterModule.Interfaces.IUserNewsLetterService
    {
        static $inject = ["$http"];
        constructor( private httpService: ng.IHttpService)
        {
        }

        UpdateMyNewsLetters( newsLetterId: string, userId: any ): ng.IPromise<any> 
        {
            var self = this;
            var data = { newsLetterId: newsLetterId, userId: userId };

            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/api/UserNewsLetter/UpdateMyNewsLetters', data );
        }

        GetUserNewsLetters( userId:any): ng.IPromise<any> 
        {
            var config = {
                params: { userId: userId },
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/UserNewsLetter/GetUserNewsLetters', config);
        }

        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService ) => new UserNewsLetterService( $http );
            return instance;
        }
   }

    MiniSpas.ModuleInitiator.GetModule( "UserNewsLetterModule" ).service( "UserNewsLetterModule.Services.UserNewsLetterService", UserNewsLetterService);
} 