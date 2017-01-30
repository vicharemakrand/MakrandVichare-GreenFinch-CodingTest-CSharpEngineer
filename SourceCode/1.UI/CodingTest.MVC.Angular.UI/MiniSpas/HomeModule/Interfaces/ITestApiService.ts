module HomeModule.Interfaces
{
    export interface ITestApiService
    {
        GetTestValuesList(): ng.IPromise<any>;
    }
}