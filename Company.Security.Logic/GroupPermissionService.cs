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
    public class GroupPermissionService : ModelBase2Service<GroupPermission>, IGroupPermissionService
    {
        public IEnumerable<GroupPermission> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupPermissionRepository.GetAll();
            }
        }

        public GroupPermission GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupPermissionRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupPermissionRepository.GetCount();
            }
        }

        public IEnumerable<GroupPermission> GetByGroupId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupPermissionRepository.GetByGroupId(id);
            }
        }
        #region Delete

        public bool IsDeleteAllowed(GroupPermission model, IEnumerable<string> conflicts)
        {
            // Person iwo verknüpft
            conflicts = new List<string>();
            return true;
        }

        public bool TryDelete(GroupPermission model, IEnumerable<string> conflicts)
        {
            if(!IsDeleteAllowed(model, conflicts))
                return false;

            return Delete(model);
        }

        private bool Delete(GroupPermission model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                model.MarkAsDeleted();
                unitOfWork.GroupPermissionRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion

        #region Save

        public bool Validate(GroupPermission model, IEnumerable<string> conflicts)
        {
            conflicts = new List<string>();
            return true;
        }

        public bool TrySave(GroupPermission model, IEnumerable<string> conflicts)
        {
            if(!Validate(model, conflicts))
                return false;

            return Save(model);
        }

        private bool Save(GroupPermission model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                unitOfWork.GroupPermissionRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion
    }
}
