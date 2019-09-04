using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Security;

namespace Company.App.DataSourceDefinition.Repositories.Security
{
    public interface IGroupPermissionRepository
    {
        IEnumerable<GroupPermission> GetByGroupId(int id);
    }
}
