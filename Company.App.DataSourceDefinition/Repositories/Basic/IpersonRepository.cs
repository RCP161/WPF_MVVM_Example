using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Repositories.App;

namespace Company.App.DataSourceDefinition.Repositories.Basic
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        IEnumerable<User> GetByGroupId(int id);
        Person GetByIdForEdit(int id);
    }
}
