using CodingTest.EntityModels.Localization;
using CodingTest.IRepositories.Core;
using System.Collections.Generic;

namespace CodingTest.IRepositories.Localization
{
    public interface IKeyGroupRepository : IIdentityBaseRepository<KeyGroupEntityModel>
    {
        KeyGroupEntityModel GetResourceKeysByGroup(string groupId);
        List<KeyGroupEntityModel> GetResourceKeysByGroups(List<string> groupIds);
    }
}
