using CodingTest.Repositories.Core;
using System.Collections.Generic;
using System.Linq;
using CodingTest.EntityModels.Localization;
using CodingTest.IRepositories.Localization;

namespace CodingTest.Repositories.Localization
{
    public class KeyGroupRepository : IdentityBaseRepository<KeyGroupEntityModel>, IKeyGroupRepository
    {

        public KeyGroupEntityModel GetResourceKeysByGroup(string groupId)
        {
            if (!string.IsNullOrWhiteSpace(groupId))
            {

                return DbSet.FirstOrDefault(o => o.KeyGroup.ToLower().Trim() == groupId.ToLower().Trim());
            }
            else
            {
                return null;
            }
        }

        public List<KeyGroupEntityModel> GetResourceKeysByGroups(List<string> groupIds)
        {
            if (groupIds != null && groupIds.Count > 0)
            {
                return DbSet.Where(o => groupIds.Contains(o.KeyGroup.ToLower().Trim())).ToList();
            }
            else
            {
                return new List<KeyGroupEntityModel>();
            }
        }
    }
}
