using System.Collections.Generic;
using Catel.IoC;
using Company.App.Core.Logic.Basic;
using Company.App.Core.Models.Basic;
using Company.App.DataSourceDefinition.Common;

namespace Company.Basic.Logic
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> LoadPersons()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetAll();
            }
        }
    }
}
