module MiniSpas
{
    export class ModuleInitiator
    {
        static modulesList = [
            { name: 'MiniSpas', dependencies: Array<string>() },
            { name: 'Common', dependencies: Array<string>() },
            { name: 'AccountModule', dependencies: Array<string>( "ngRoute", "NewsLetterModule", "Common", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies" ) },
            { name: 'UserNewsLetterModule', dependencies: Array<string>( "ngRoute","AccountModule", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies") },
            {
                name: 'HomeModule', dependencies: Array<string>( "ngRoute", "AccountModule", "Common", "UserNewsLetterModule", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies" ) },
            { name: 'NewsLetterModule', dependencies: Array<string>( "ngRoute", "AccountModule", "UserNewsLetterModule", "Common", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies" ) },
        ];

        static GetModule( moduleName: string ): ng.IModule
        {
            try
            {
               return angular.module( moduleName );
            } catch (error)
            {
                var dependencies = this.modulesList.filter( o => o.name == moduleName ).shift().dependencies;
                return angular.module( moduleName, dependencies );
            }
        };
    }

    MiniSpas.ModuleInitiator.GetModule("MiniSpas").service( "MiniSpas.ModuleInitiator", ModuleInitiator );
}