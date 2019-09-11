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
    public class UserService : IUserService
    {
        public IEnumerable<User> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.UserRepository.GetAll();
            }
        }

        public User GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.UserRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.UserRepository.GetCount();
            }
        }

        public void Save(User model, IDataAccess dataAccess)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetOrCreate(dataAccess))
            {
                unitOfWork.UserRepository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }

        public IEnumerable<User> GetByGroupId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetByGroupId(id);
            }
        }
    }
}
