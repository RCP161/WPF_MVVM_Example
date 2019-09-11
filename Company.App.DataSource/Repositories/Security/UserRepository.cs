using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSource.Repositories.App;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Repositories.Security
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        internal UserRepository(IDataAccess dataAccess) : base(dataAccess)
        { }
    }
}
