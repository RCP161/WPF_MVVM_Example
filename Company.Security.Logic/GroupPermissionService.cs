using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;

namespace Company.Security.Logic
{
    public class GroupPermissionService : IGroupPermissionService
    {
        public IEnumerable<GroupPermission> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupPermissionRepository.GetAll();
            }
        }

        public GroupPermission GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupPermissionRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupPermissionRepository.GetCount();
            }
        }

        public void Save(GroupPermission model, IDataAccess dataAccess)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetOrCreate(dataAccess))
            {
                unitOfWork.GroupPermissionRepository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }

        public IEnumerable<GroupPermission> GetByGroupId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupPermissionRepository.GetByGroupId(id);
            }
        }
    }
}
