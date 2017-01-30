using AutoMapper;
using CodingTest.EntityModels;
using CodingTest.InfraStructure.Logging;
using CodingTest.ViewModels;
using System;
using System.Globalization;
using System.Linq;

namespace CodingTest.IDomainServices.AutoMapper
{

    class ListCommaSeparatedStringResolver : IMemberValueResolver<NewsLetterEntityModel, NewsLetterViewModel, string[], string>
    {
        public string Resolve(NewsLetterEntityModel source, NewsLetterViewModel destination, string[] sourceMember, string destMember, ResolutionContext context)
        {
            return string.Join("','", sourceMember.Select(i => i).ToArray());
        }

    }

    public class DateResolver : IValueResolver<string, DateTime?, DateTime?>
    {
        public DateTime? Resolve(string source, DateTime? destination, DateTime? destMember, ResolutionContext context)
        {
            try
            {
                return DateTime.ParseExact(source, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException ex)
            {
                NLogLogger.Instance.Log(ex);
                return null;
            }
            catch (FormatException ex)
            {
                NLogLogger.Instance.Log(ex);
                return null;
            }
        }
    }
}
