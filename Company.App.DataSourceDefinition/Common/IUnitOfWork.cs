using System;
using System.Collections.Generic;
using System.Text;

namespace Company.App.DataSourceDefinition.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Repositories.Basic.IPersonRepository PersonRepository { get; }
        Repositories.Security.IUserRepository UserRepository { get; }
        Repositories.Security.IGroupRepository GroupRepository { get; }
        Repositories.Security.IPermissionRepository PermissionRepository { get; }
        Repositories.Security.IGroupPermissionRepository GroupPermissionRepository { get; }

        bool Complete();
    }
}
