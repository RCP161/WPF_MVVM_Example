using System.Collections.Generic;
using Catel.IoC;
using Company.App.Core.Logic.Basic;
using Company.App.Core.Models.Basic;
using Company.App.DataSourceDefinition.Common;
using Company.App.Logic;

namespace Company.Basic.Logic
{
    public class PersonService : ModelBase2Service<Person>, IPersonService
    {
        public Person GetByIdForEdit(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetByIdForEdit(id);
            }

        }
    }
}
