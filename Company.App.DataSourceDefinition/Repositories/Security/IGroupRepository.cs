using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;

namespace Company.App.DataSourceDefinition.Repositories.Security
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetByUserId(int id);
    }
}
