using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.DataSourceDefinition.Common
{
    public interface IUnitOfWork : IDisposable
    {

        Repositories.App.IModelBase2Repository ModelBase2Repository { get; }
        Repositories.Basic.IPersonRepository PersonRepository { get; }
        Repositories.Security.IGroupRepository GroupRepository { get; }
        Repositories.Security.IGroupPermissionRepository GroupPermissionRepository { get; }
        

        void Complete();
    }
}
