using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;

namespace Company.App.DataSourceDefinition.Repositories.Basic
{
    public interface IPersonRepository : IModelBase2Repository<Person>
    {
        Person GetByIdForEdit(int id);
    }
}
