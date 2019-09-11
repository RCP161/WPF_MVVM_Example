﻿using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Repositories.App;

namespace Company.App.DataSourceDefinition.Repositories.Security
{
    public interface IGroupPermissionRepository : IBaseRepository<GroupPermission>
    {
        IEnumerable<GroupPermission> GetByGroupId(int id);
    }
}
