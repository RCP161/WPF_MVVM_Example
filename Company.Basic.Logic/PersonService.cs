using System.Collections.Generic;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.Core.Logic.Basic;
using Company.App.Core.Models.Basic;
using Company.App.DataSourceDefinition.Common;

namespace Company.Basic.Logic
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetAll();
            }
        }

        public Person GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetCount();
            }
        }

        public void Save(Person model, IDataAccess dataAccess)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetOrCreate(dataAccess))
            {
                unitOfWork.PersonRepository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }


        public Person GetByIdForEdit(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetByIdForEdit(id);
            }
        }
    }
}
