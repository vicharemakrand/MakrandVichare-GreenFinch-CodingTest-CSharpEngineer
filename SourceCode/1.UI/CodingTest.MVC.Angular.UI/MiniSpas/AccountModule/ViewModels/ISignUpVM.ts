module AccountModule.ViewModels
{
    export class ISignUpVM extends AccountModule.ViewModels.IUserVM
    {
        Password: string;
        NewsLetterIds: string;
        HeardAboutUs: number;
        SignUpReason: string;
        NewsLetterList: Array<NewsLetterModule.ViewModels.INewsLetterListVM>;
        HeardAboutUsList: Array<Object>;
    }
}