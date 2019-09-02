using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.DataSourceDefinition.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Basic.IPersonRepository PersonRepository { get; }

        App.IModelBase2Repository ModelBase2Repository { get; }

        void Complete();
    }
}
