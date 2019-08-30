using System;
using System.Collections.Generic;
using Catel.IoC;
using Company.Project.Core.Logic.Basic;
using Company.Project.Core.Models.Basic;
using Company.Project.DataSourceDefinition.Repositories;

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
