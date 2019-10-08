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
    public class GroupService : ModelBase2Service<Group>, IGroupService
    {
        public IEnumerable<Group> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupRepository.GetAll();
            }
        }

        public Group GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupRepository.GetCount();
            }
        }

        public IEnumerable<Group> GetByUserId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.GroupRepository.GetByUserId(id);
            }
        }
               
        #region Delete

        public bool IsDeleteAllowed(Group model, IEnumerable<string> conflicts)
        {
            // GroupPermissions fragen

            conflicts = new List<string>();
            return true;
        }

        public bool TryDelete(Group model, IEnumerable<string> conflicts)
        {
            if(!IsDeleteAllowed(model, conflicts))
                return false;

            return Delete(model);
        }

        private bool Delete(Group model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                IGroupPermissionService groupPermissionService = ServiceLocator.Default.ResolveType<IGroupPermissionService>();
                IEnumerable<GroupPermission> groupPermissions = unitOfWork.GroupPermissionRepository.GetByGroupId(model.Id);

                foreach(GroupPermission permission in groupPermissions)
                {
                    if(!groupPermissionService.TryDelete(permission, null))
                        return false;
                }

                model.MarkAsDeleted();
                unitOfWork.GroupRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion

        #region Save

        public bool Validate(Group model, IEnumerable<string> conflicts)
        {
            conflicts = new List<string>();
            return true;
        }

        public bool TrySave(Group model, IEnumerable<string> conflicts)
        {
            if(!Validate(model, conflicts))
                return false;

            return Save(model);
        }

        private bool Save(Group model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                unitOfWork.GroupRepository.SaveOrUpdate(model);

                foreach(GroupPermission permission in model.GroupPermissions)
                    unitOfWork.GroupPermissionRepository.SaveOrUpdate(permission);

                return unitOfWork.Complete();
            }
        }

        #endregion
    }
}
