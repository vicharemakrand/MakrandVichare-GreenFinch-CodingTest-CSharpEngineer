module AccountModule.ViewModels
{
    export class IAuthenticationVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        IsAuth: boolean;
        Email: string;
    }
}