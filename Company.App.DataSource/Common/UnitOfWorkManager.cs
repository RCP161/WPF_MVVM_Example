using System;
using System.Collections.Generic;
using System.Threading;
using Catel.IoC;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Common
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private IDataAccess _dataAccess;
        private Dictionary<int, UnitOfWork> _unitOfWorks;

        public UnitOfWorkManager(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _unitOfWorks = new Dictionary<int, UnitOfWork>();
        }

        public IUnitOfWork GetorCreateUnitOfWork()
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            if(_unitOfWorks.ContainsKey(id))
            {
                _unitOfWorks[id].Counter++;
                return _unitOfWorks[id];
            }

            UnitOfWork uow = new UnitOfWork(_dataAccess);
            uow.Counter++;

            _unitOfWorks.Add(id, uow);

            return uow;
        }
    }
}
