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
    public class UserService : ModelBase2Service<User>, IUserService
    {
        public IEnumerable<User> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.UserRepository.GetAll();
            }
        }

        public User GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.UserRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.UserRepository.GetCount();
            }
        }

        public IEnumerable<User> GetByGroupId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.UserRepository.GetByGroupId(id);
            }
        }

        #region Delete

        public bool IsDeleteAllowed(User model, IEnumerable<string> conflicts)
        {
            // User verknüpft?

            conflicts = new List<string>();
            return true;
        }

        public bool TryDelete(User model, IEnumerable<string> conflicts)
        {
            if(!IsDeleteAllowed(model, conflicts))
                return false;

            return Delete(model);
        }

        private bool Delete(User model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                IGroupService groupService = ServiceLocator.Default.ResolveType<IGroupService>();
                IEnumerable<Group> groups = unitOfWork.GroupRepository.GetByUserId(model.Id);

                foreach(Group group in groups)
                {
                    if(!groupService.TryDelete(group, null))
                        return false;
                }

                model.MarkAsDeleted();
                unitOfWork.UserRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion

        #region Save

        public bool Validate(User model, IEnumerable<string> conflicts)
        {
            conflicts = new List<string>();
            return true;
        }

        public bool TrySave(User model, IEnumerable<string> conflicts)
        {
            if(!Validate(model, conflicts))
                return false;

            return Save(model);
        }

        private bool Save(User model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                unitOfWork.UserRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion
    }
}
