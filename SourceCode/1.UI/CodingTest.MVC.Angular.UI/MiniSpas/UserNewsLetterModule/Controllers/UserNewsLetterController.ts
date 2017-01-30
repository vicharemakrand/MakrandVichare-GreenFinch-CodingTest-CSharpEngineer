
module UserNewsLetterModule.Controllers
{
    export class UserNewsLetterController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "UserNewsLetterModule.Services.UserNewsLetterService", "AccountModule.Services.AuthService"];

        constructor( _injectorService: ng.auto.IInjectorService, private userNewsLetterService: UserNewsLetterModule.Interfaces.IUserNewsLetterService, private authService: AccountModule.Interfaces.IAuthService )
        {
            super( _injectorService );
          // this.Initialize();
        }

        myNewsLetterList: Array<UserNewsLetterModule.ViewModels.IUserNewsLetterVM>;

        Initialize()
        {
            var self = this;
            self.authService.GetAuthData();
            self.GetUserNewsLetters();
        }

        GetUserNewsLetters = () =>
        {
            var self = this;
            self.StartProcess();
            self.userNewsLetterService.GetUserNewsLetters( self.authService.authVM.Id)
                .then( function ( response: any )
                {
                    self.myNewsLetterList = response.data.viewModels;
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
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

        UpdateMyNewsLetters = ( newsLetterId: string ) =>
        {
            var self = this;
            self.StartProcess();

            self.userNewsLetterService.UpdateMyNewsLetters( newsLetterId, self.authService.authVM.Id )
                .then( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });
        }

    }
    MiniSpas.ModuleInitiator.GetModule( "UserNewsLetterModule" ).controller( "UserNewsLetterModule.Controllers.UserNewsLetterController", UserNewsLetterController );
} 