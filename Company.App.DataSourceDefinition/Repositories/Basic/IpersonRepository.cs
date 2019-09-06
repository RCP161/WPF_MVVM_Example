using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;

namespace Company.App.DataSourceDefinition.Repositories.Basic
{
    public interface IPersonRepository
    {
        IEnumerable<User> GetByGroupId(int id);
        Person GetByIdForEdit(int id);
    }
}
