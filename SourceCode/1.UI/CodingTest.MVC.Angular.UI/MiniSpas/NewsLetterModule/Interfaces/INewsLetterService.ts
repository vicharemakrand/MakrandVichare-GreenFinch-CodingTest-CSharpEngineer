module NewsLetterModule.Interfaces
{
    export interface INewsLetterService
    {
        GetTopNewsLetters(userId:number): ng.IPromise<any>;
        GetNewsLetters( searchParam: NewsLetterModule.ViewModels.INewsLetterParamVM ): ng.IPromise<any>;
    }
}