module UserNewsLetterModule.Interfaces
{
    export interface IUserNewsLetterService
    {
        GetUserNewsLetters( userId: any ): ng.IPromise<any>;
        UpdateMyNewsLetters( newsLetterId: string, userId: any ): ng.IPromise<any>;
    }
}