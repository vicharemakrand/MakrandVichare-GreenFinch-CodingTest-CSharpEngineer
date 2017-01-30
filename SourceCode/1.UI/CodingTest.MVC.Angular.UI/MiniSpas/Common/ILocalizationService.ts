module AccountModule.Interfaces
{
    export interface ILocalizationService
    {
        GetLocalizationData( keyGroup: string): ng.IPromise<any>;
    }
}