module AccountModule.Interfaces
{
    export interface IAuthService
    {
        Login( loginData: AccountModule.ViewModels.ILoginVM ) : ng.IPromise<any>;
        LogOut(): void;
        SignUp( registration: AccountModule.ViewModels.ISignUpVM ): ng.IPromise<any>;
        GetAuthData(): void;
        GetAntiForgeryToken(): ng.IPromise<any>;
        authVM: AccountModule.ViewModels.IAuthenticationVM;
    }
}