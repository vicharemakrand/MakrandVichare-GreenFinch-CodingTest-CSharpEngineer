
module AccountModule.Controllers
{
    export class LoginController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "AccountModule.Services.AuthService", "$cookieStore"];

        constructor( _injectorService: ng.auto.IInjectorService, private authService: AccountModule.Interfaces.IAuthService, private cookieStoreService: ng.cookies.ICookieStoreService)
        {
            super( _injectorService);
            this.Initialize();
        }

        loginVM: AccountModule.ViewModels.ILoginVM = {
            Email: "",
            Password: ""
        };

        authenticationVM: AccountModule.ViewModels.IAuthenticationVM ;

        Login(loginData:AccountModule.ViewModels.ILoginVM)
        {
            var self = this;
            self.authService.Login(loginData).then( function ( response: any )
            {
                if ( response.data != null )
                {
                    self.windowService.location.href = '/NewsLetter';
                }

            })
            .catch( function ( response: any )
            {
                self.ProcessInfo.Message = response.data;
            })
            .finally( function ()
            {
                self.ProcessInfo.Loading = false;
            });
        }

        selectedLanguage: string;

        OnLanguageChange()
        {
            var self = this;
            self.cookieStoreService.put( 'langCode', self.selectedLanguage );
        }

        LogOut()
        {
            var self = this;
            self.authService.LogOut();
            self.windowService.location.href = '/Home/#/home';
        }

        Initialize()
        {
            var self = this;
            self.authenticationVM = self.authService.authVM;
            self.selectedLanguage = self.cookieStoreService.get( 'langCode' ) != null ? self.cookieStoreService.get( 'langCode' ) : 'en-us';
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "AccountModule" ).controller( "AccountModule.Controllers.LoginController", LoginController );
} 