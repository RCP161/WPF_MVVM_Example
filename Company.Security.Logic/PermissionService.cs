using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Logic;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;

namespace Company.Security.Logic
{
    public class PermissionService : ModelBase2Service<Permission>, IPermissionService
    {
        public IEnumerable<Permission> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PermissionRepository.GetAll();
            }
        }

        public Permission GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PermissionRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PermissionRepository.GetCount();
            }
        }

        #region Delete

        public bool IsDeleteAllowed(Permission model, IEnumerable<string> conflicts)
        {
            // Sind noch GroupPermissions damit verknüpft
            conflicts = new List<string>();
            return true;
        }

        public bool TryDelete(Permission model, IEnumerable<string> conflicts)
        {
            if(!IsDeleteAllowed(model, conflicts))
                return false;

            return Delete(model);
        }

        private bool Delete(Permission model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                model.MarkAsDeleted();
                unitOfWork.PermissionRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion

        #region Save

        public bool Validate(Permission model, IEnumerable<string> conflicts)
        {
            conflicts = new List<string>();
            return true;
        }

        public bool TrySave(Permission model, IEnumerable<string> conflicts)
        {
            if(!Validate(model, conflicts))
                return false;

            return Save(model);
        }

        private bool Save(Permission model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                unitOfWork.PermissionRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion
    }
}
