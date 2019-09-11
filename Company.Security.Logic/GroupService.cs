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
    public class GroupService : IGroupService
    {
        public IEnumerable<Group> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupRepository.GetAll();
            }
        }

        public Group GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupRepository.GetCount();
            }
        }

        public void Save(Group model, IDataAccess dataAccess)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetOrCreate(dataAccess))
            {
                unitOfWork.GroupRepository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }

        public IEnumerable<Group> GetByUserId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.GroupRepository.GetByUserId(id);
            }
        }
    }
}
