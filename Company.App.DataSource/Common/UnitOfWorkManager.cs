using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.DataSourceDefinition.Common;

namespace Company.App.DataSource.Common
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private static Dictionary<IDataAccess, UnitOfWork> unitOfWorks = new Dictionary<IDataAccess, UnitOfWork>();

        public IUnitOfWork GetOrCreate(IDataAccess dataAccess)
        {
            if(dataAccess != null && unitOfWorks.ContainsKey(dataAccess))
            {
                unitOfWorks[dataAccess].UsingCounter++;
                return unitOfWorks[dataAccess];
            }

            UnitOfWork uow = new UnitOfWork(ServiceLocator.Default.ResolveType<IDataAccess>());

            unitOfWorks.Add(uow.DataAccess, uow);
            return uow;
        }
    }
}
