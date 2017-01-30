module NewsLetterModule.ViewModels
{
    export class INewsLetterListVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        Title: string;
        Publisher: string;
        Description: string;
        Author: string;
        IsSubscribed: boolean;
    }
}