using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories;

namespace Company.Project
{
    internal class TestData
    {
        internal TestData()
        {
            TestOrCreatePersons();
        }

        private void TestOrCreatePersons()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                int c = unitOfWork.PersonRepository.GetCount();

                if(c > 5)
                    return;
            }

            Company.App.Core.Models.Basic.Person p;
            for(int i = 0; i < 5; i++)
            {
                p = new Company.App.Core.Models.Basic.Person();
                p.Name = "Person";
                p.Surename = Guid.NewGuid().ToString();

                p.SaveModel();
            }
        }
    }
}
