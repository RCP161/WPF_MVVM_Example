using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;

namespace Company.App.DataSourceDefinition.Repositories.Security
{
    public interface IUserRepository : IModelBase2Repository<User>
    {
        IEnumerable<User> GetByGroupId(int id);
        User GetByPersonId(int id);
    }
}
