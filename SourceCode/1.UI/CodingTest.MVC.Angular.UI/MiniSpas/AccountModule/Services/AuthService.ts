
module AccountModule.Services
{
    export class AuthService implements AccountModule.Interfaces.IAuthService
    {
        httpService: ng.IHttpService;
        localStorageService: ng.local.storage.ILocalStorageService;
        static $inject = ["$http", "localStorageService"];

        constructor( $http: ng.IHttpService, _localStorageService: ng.local.storage.ILocalStorageService )
        {
            this.httpService = $http;
            this.localStorageService = _localStorageService;
        }

        isAuth: boolean = false;

        authVM: AccountModule.ViewModels.IAuthenticationVM = {
            IsAuth: this.isAuth,
            Email: "",
            Id :0
        };

        Login = (loginData: AccountModule.ViewModels.ILoginVM): ng.IPromise<any> =>
        {
            var self = this;

            var data = "grant_type=password&username=" + loginData.Email + "&password=" + loginData.Password;

            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then( function( response:any )
                {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                Email: loginData.Email,
                                Id: response.data.id
                            } as AccountModule.ViewModels.IAuthorizationVM );

                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.Email = loginData.Email;
                        self.authVM.Id = response.data.id;

                    return response;

                }).catch( function ( response: any )
                {
                    self.LogOut();
                    return response;
                });
        }

        SignUp( registration: AccountModule.ViewModels.ISignUpVM ): ng.IPromise<any> 
        {
            var self = this;
            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/api/Account/Register', registration )
                .then( function ( response: any )
                {
                    return response;

                }).catch( function ( response: any )
                {
                    return response;
                });
        }

        LogOut = () =>
        {
            var self = this;
            self.localStorageService.remove( 'authorizationData' );
            self.authVM.IsAuth = self.isAuth;
            self.authVM.Id = 0;
            self.authVM.Email = "";
        }

        GetAuthData = () =>
        {
            var self = this;

            var authData = self.localStorageService.get( 'authorizationData' ) as AccountModule.ViewModels.IAuthorizationVM;
            if ( authData != null )
            {
                self.authVM.IsAuth = !self.isAuth;
                self.authVM.Email = authData.Email;
                self.authVM.Id = authData.Id;

            }
        }

        GetAntiForgeryToken = (): ng.IPromise<any> =>
        {
            var self = this;

            return self.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/Antiforgerytoken/GetAntiForgeryToken')
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
            var instance = ( $http: ng.IHttpService, _localStorageService: ng.local.storage.ILocalStorageService ) => new AuthService( $http, _localStorageService);
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "AccountModule" ).service( "AccountModule.Services.AuthService", AuthService );
} 