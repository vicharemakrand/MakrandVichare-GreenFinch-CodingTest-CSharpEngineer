
module AccountModule.Controllers
{
    export class SignupController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "AccountModule.Services.AuthService", "$timeout", "NewsLetterModule.Services.NewsLetterService","AccountModule.Services.LocalizationService"];

        constructor( _injectorService: ng.auto.IInjectorService,
            private authService: AccountModule.Interfaces.IAuthService,
            private timeOutService: ng.ITimeoutService,
            private newsLetterService: NewsLetterModule.Interfaces.INewsLetterService,
            private localizationService: AccountModule.Interfaces.ILocalizationService
            )
        { 
            super( _injectorService );
            this.Initialize();
        }

        signUpVM: AccountModule.ViewModels.ISignUpVM;
        fieldCaptions: IDictionary<string>;

        private GetSelectedIds(newsLetterIds: Array<NewsLetterModule.ViewModels.INewsLetterListVM>)
        {
            var self = this;
            var output = '';
            angular.forEach( newsLetterIds, function ( newsLetter: any,key:any )
            {
                if ( newsLetter.isSubscribed )
                {
                    output += newsLetter.id + ',';
                }
            });

            return output;
        }

        SignUp = () =>
        {
            var self = this;
            self.StartProcess();

            self.signUpVM.NewsLetterIds = self.GetSelectedIds( self.signUpVM.NewsLetterList);

            self.authService.SignUp( self.signUpVM )
                .then( function ( response: any ) {
                    if ( response.status == 400 )
                    {
                        if ( response.data.modelState != null )
                        {
                            var errors = new Array<string>();
                            for ( var key in response.data.modelState )
                            {
                                for ( var i = 0; i < response.data.modelState[key].length; i++ )
                                {
                                    errors.push( response.data.modelState[key][i] );
                                }
                            }
                            self.ProcessInfo.Message = "Failed to register user due to:" + errors.join( ' ' );
                        }
                        else
                        {
                            self.ProcessInfo.Message = response.data.message;
                        }
                    }
                    else
                    {
                        self.ProcessInfo.Message = response.data.message;
                        self.ProcessInfo.IsSucceed = true;
                        self.StartTimer();
                    }
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = "Failed to register user due to:" + response.data.message;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });;
        }

        StartTimer = () =>
        {
            var self = this;
            var timer = self.timeOutService( function ()
                                            {
                self.timeOutService.cancel( timer );
                self.locationService.path( '/login' );
            }, 2000 ) as ng.IPromise<void>;
        }

        GetLocalizedValue = ( key: string ): string =>
        {
            var self = this;
            var result = ( this.fieldCaptions != null && this.fieldCaptions[key] != null ) ? this.fieldCaptions[key] : '$' + key + '$';
            return result;
        }

        Initialize()
        {
            var self = this;
            self.signUpVM = {
                Password: "",
                Id: null,
                UserName: "",
                HeardAboutUsList: Common.AppConstants.HeardAboutUsList,
                HeardAboutUs : Common.HeardAboutUsList.Advert,
            } as AccountModule.ViewModels.ISignUpVM;

            self.newsLetterService.GetTopNewsLetters(0)
                .then( function ( response: any )
                {
                    self.signUpVM.NewsLetterList = response.data.viewModels;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data.message;
                })
                .finally( function ()
                {
                });

            self.localizationService.GetLocalizationData('SignUpPage')
                .then( function ( response: any )
                {
                    self.fieldCaptions = response.data;
                })
                .catch( function ( response: any )
                {
                })
                .finally( function ()
                {
                });
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "AccountModule" ).controller( "AccountModule.Controllers.SignupController", SignupController );
} 