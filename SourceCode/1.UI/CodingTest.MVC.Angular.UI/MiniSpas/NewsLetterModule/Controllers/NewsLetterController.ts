
module NewsLetterModule.Controllers
{
    export class NewsLetterController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "NewsLetterModule.Services.NewsLetterService", "AccountModule.Services.AuthService"];
        constructor( _injectorService: ng.auto.IInjectorService, private newsLetterService: NewsLetterModule.Interfaces.INewsLetterService, private authService: AccountModule.Interfaces.IAuthService )
        {
            super( _injectorService );
           // this.Initialize();
        }

        newsLetterList: Array<NewsLetterModule.ViewModels.INewsLetterListVM>;
        searchNewsLetterParamVM: NewsLetterModule.ViewModels.INewsLetterParamVM;
        authenticationVM: AccountModule.ViewModels.IAuthenticationVM;

        Initialize()
        {
            var self = this;
            self.GetTopNewsLetters();
            self.authService.GetAuthData();
            self.authenticationVM = self.authService.authVM;
            self.searchNewsLetterParamVM = {
                Publisher: "",
                Author: "",
                UserId: self.authService.authVM.Id
            } as NewsLetterModule.ViewModels.INewsLetterParamVM;
        }

        GetTopNewsLetters = () =>
        {
            var self = this;
            self.StartProcess();

            self.newsLetterService.GetTopNewsLetters(0)
                .then( function ( response: any )
                {
                    self.newsLetterList = response.data.viewModels;
                    self.ProcessInfo.IsSucceed = true;
                    self.ProcessInfo.Message = response.data.message;
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

        GetNewsLetters = () =>
        {
            var self = this;
            self.StartProcess();

            self.newsLetterService.GetNewsLetters( self.searchNewsLetterParamVM)
                .then( function ( response: any )
                {
                    self.newsLetterList = response.data.viewModels;
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
    MiniSpas.ModuleInitiator.GetModule( "NewsLetterModule" ).controller( "NewsLetterModule.Controllers.NewsLetterController", NewsLetterController );
} 