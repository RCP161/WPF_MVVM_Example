using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.DataSourceDefinition.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Security.IPersonRepository PersonRepository { get; }

        void Complete();
    }
}
