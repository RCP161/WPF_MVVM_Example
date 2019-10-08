using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Repositories.Security
{
    public class GroupPermissionRepository : ModelBase2Repository<GroupPermission>, IGroupPermissionRepository
    {
        internal GroupPermissionRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public IEnumerable<GroupPermission> GetByGroupId(int id)
        {
            return DataAccess.Query<GroupPermission>().Where(x => x.Group.Id == id).ToList();
        }
    }
}
