using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Repositories.Security
{
    public class PermissionRepository : ModelBase2Repository<Permission>, IPermissionRepository
    {
        internal PermissionRepository(IDataAccess dataAccess) : base(dataAccess)
        { }
    }
}
