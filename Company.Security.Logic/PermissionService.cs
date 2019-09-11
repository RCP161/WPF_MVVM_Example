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
    public class PermissionService : IPermissionService
    {
        public IEnumerable<Permission> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PermissionRepository.GetAll();
            }
        }

        public Permission GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PermissionRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PermissionRepository.GetCount();
            }
        }

        public void Save(Permission model, IDataAccess dataAccess)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetOrCreate(dataAccess))
            {
                unitOfWork.PermissionRepository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }
    }
}
