
module AccountModule.Services
{
    export class LocalizationService implements AccountModule.Interfaces.ILocalizationService
    {
        httpService: ng.IHttpService;
        localStorageService: ng.local.storage.ILocalStorageService;
        cookieStoreService: ng.cookies.ICookieStoreService;

        static $inject = ["$http", "localStorageService","$cookieStore"];

        constructor( _httpService: ng.IHttpService, _localStorageService: ng.local.storage.ILocalStorageService,
             _cookieStore: ng.cookies.ICookieStoreService)
        {
            this.httpService = _httpService;
            this.localStorageService = _localStorageService;
            this.cookieStoreService = _cookieStore;
        }


        GetLocalizationData = ( keyGroup:string): ng.IPromise<any> =>
        {
            var self = this;
            var languageCode = self.cookieStoreService.get( 'langCode' ) != null ? self.cookieStoreService.get( 'langCode' ) : 'en-us';
            var config = {
                params: { keyGroup: keyGroup, languageCode: languageCode},
                headers: { 'Accept': 'application/json' }
            } as ng.IRequestShortcutConfig;

            return self.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/Localizations/GetResourceKeys', config )
                .then( function ( response: any )
                {
                    return response;
                })
                .catch( function ( response: any )
                {
                    return response
                });
        }

        public static getInstance()
        {
            var instance = ( $http: ng.IHttpService, _localStorageService: ng.local.storage.ILocalStorageService ) => new AuthService( $http, _localStorageService );
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "AccountModule" ).service( "AccountModule.Services.LocalizationService", LocalizationService );
} 