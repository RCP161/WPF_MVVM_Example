using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Logic;
using Company.App.Core.Logic.App;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Repositories;

namespace Company.App.Logic
{
    public class SaveableService : ISaveableService
    {
        public void Save(ModelBase2 model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                unitOfWork.ModelBase2Repository.SaveOrUpdate(model);
            }
        }
    }
}
