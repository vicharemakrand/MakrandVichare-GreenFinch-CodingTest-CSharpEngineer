
module Common
{
    export class AppConstants
    {
        static get BaseWebApiUrl(): string { return "http://localhost:8888" };

        static get HeardAboutUsList(): Array<Object>
        {
            return [
                { id: Common.HeardAboutUsList.Advert, name: "Advert" },
                { id: Common.HeardAboutUsList.WordOfMouth, name: "Word of Mouth" },
                { id: Common.HeardAboutUsList.Other, name: "Other" }
            ];
        };
    }

    export enum HeardAboutUsList
    {
        Advert = 1,
        WordOfMouth = 2,
        Other = 3
    }

    MiniSpas.ModuleInitiator.GetModule( "Common" ).constant( "Common.AppConstants", AppConstants);
}