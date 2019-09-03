using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models.Basic;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;

namespace Company.App.DataSource.Repositories.Basic
{
    public class PersonRepository : IPersonRepository
    {
        internal PersonRepository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        protected IDataAccess DataAccess { get; private set; }
    }
}
