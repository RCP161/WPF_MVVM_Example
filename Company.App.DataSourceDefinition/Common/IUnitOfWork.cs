using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.DataSourceDefinition.Common
{
    public interface IUnitOfWork : IDisposable
    {

        Repositories.App.IModelBase2Repository ModelBase2Repository { get; }
        Repositories.Basic.IPersonRepository PersonRepository { get; }

        void Complete();
    }
}
