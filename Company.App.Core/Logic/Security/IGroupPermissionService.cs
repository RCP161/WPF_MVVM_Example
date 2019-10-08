using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Security;

namespace Company.App.Core.Logic.Security
{
    public interface IGroupPermissionService : ModelBase2Service<GroupPermission>
    {
        IEnumerable<GroupPermission> GetByGroupId(int id);
    }
}
