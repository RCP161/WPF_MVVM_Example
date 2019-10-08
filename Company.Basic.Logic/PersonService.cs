using System.Collections.Generic;
using Catel.IoC;
using Company.App.Core.Logic;
using Company.App.Core.Logic.Basic;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;

namespace Company.Basic.Logic
{
    public class PersonService : ModelBase2Service<Person>, IPersonService
    {
        public IEnumerable<Person> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PersonRepository.GetAll();
            }
        }

        public Person GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PersonRepository.GetById(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PersonRepository.GetCount();
            }
        }

        public Person GetByIdForEdit(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                return unitOfWork.PersonRepository.GetByIdForEdit(id);
            }
        }

        #region Delete

        public bool IsDeleteAllowed(Person model, IEnumerable<string> conflicts)
        {
            // Person iwo verknüpft
            conflicts = new List<string>();
            return true;
        }

        public bool TryDelete(Person model, IEnumerable<string> conflicts)
        {
            if(!IsDeleteAllowed(model, conflicts))
                return false;

            return Delete(model);
        }

        private bool Delete(Person model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                IUserService userService = ServiceLocator.Default.ResolveType<IUserService>();
                User user = unitOfWork.UserRepository.GetByPersonId(model.Id);

                if(!userService.TryDelete(user, null))
                    return false;

                model.MarkAsDeleted();
                unitOfWork.PersonRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion

        #region Save

        public bool Validate(Person model, IEnumerable<string> conflicts)
        {
            conflicts = new List<string>();
            return true;
        }

        public bool TrySave(Person model, IEnumerable<string> conflicts)
        {
            if(!Validate(model, conflicts))
                return false;

            return Save(model);
        }

        private bool Save(Person model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWorkManager>().GetorCreateUnitOfWork())
            {
                unitOfWork.PersonRepository.SaveOrUpdate(model);
                return unitOfWork.Complete();
            }
        }

        #endregion
    }
}
