module AccountModule.ViewModels
{
    export class IAuthorizationVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        Token: string;
        Email: string;
    }
}