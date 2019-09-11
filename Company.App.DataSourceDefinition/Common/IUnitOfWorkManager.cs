using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Common;

namespace Company.App.DataSourceDefinition.Common
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork GetOrCreate(IDataAccess dataAccess);
    }
}
