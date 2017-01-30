
module HomeModule.Controllers
{
    export class HomeController extends Common.Controllers.BaseController
    {
        static $inject = ["HomeModule.Services.TestApiService", "$injector"];
        users: Array<AccountModule.ViewModels.IUserVM>;
        constructor( private testApiService: HomeModule.Interfaces.ITestApiService, _injectorService: ng.auto.IInjectorService )
        {
            super( _injectorService);
        }

        CheckApiUrl = () =>
        {
            var self = this;
            self.StartProcess();

            self.testApiService.GetTestValuesList()
                .then(function ( response: any )
                {
                    self.users = response.data.result;
                    self.ProcessInfo.Message = response.data.message;
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
    }
    MiniSpas.ModuleInitiator.GetModule("HomeModule").controller( "HomeModule.Controllers.HomeController", HomeController );
} 