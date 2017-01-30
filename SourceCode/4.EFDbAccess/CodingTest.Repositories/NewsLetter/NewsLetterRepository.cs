using CodingTest.Repositories.Core;
using CodingTest.EntityModels;
using CodingTest.IRepositories.NewsLetter;
using System.Collections.Generic;
using CodingTest.Utility.ParamViewModels;
using System.Linq;

namespace CodingTest.Repositories.NewsLetter
{
    public class NewsLetterRepository : IdentityBaseRepository<NewsLetterEntityModel>, INewsLetterRepository
    {

        public List<NewsLetterEntityModel> GetNewsLetters(SearchNewLetterViewModel searchParam)
        {
            var query = DbSet.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchParam.Publisher))
            {
                query = query.Where(o => o.Publisher.ToLower().Trim().Contains(searchParam.Publisher.ToLower().Trim()));
            }

            if (!string.IsNullOrWhiteSpace(searchParam.Author))
            {
                query = query.Where(o => o.Author.StartsWith(searchParam.Author.Trim()));
            }

            return query.ToList();
        }

        public List<NewsLetterEntityModel> GetNewsLettersByIds(List<long> Ids)
        {

            var query = DbSet.Where(o=> Ids.Contains(o.Id)).ToList();

            return query.ToList();
        }
    }
}
