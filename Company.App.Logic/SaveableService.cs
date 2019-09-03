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
        public void Save<T>(T model) where T : ModelBase2
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                unitOfWork.ModelBase2Repository.SaveOrUpdate<T>(model);
                unitOfWork.Complete();
            }
        }
    }
}
