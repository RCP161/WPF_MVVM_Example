using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Logic.App;
using Company.App.Core.Models.Security;

namespace Company.App.Core.Logic.Security
{
    public interface IGroupPermissionService : IModelBase2Service<GroupPermission>, ISaveableService<GroupPermission>
    {
        IEnumerable<GroupPermission> GetByGroupId(int id);
    }
}
