using System;
using Catel.IoC;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories;
using Company.App.DataSourceDefinition.Repositories.App;
using Company.App.DataSourceDefinition.Repositories.Basic;

namespace Company.App.DataSource.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructor

        public UnitOfWork(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        #endregion

        #region Properties

        private IDataAccess DataAccess { get; set; }


        public IModelBase2Repository ModelBase2Repository
        {
            get { return ServiceLocator.Default.ResolveType<IModelBase2Repository>(); }
        }

        public IPersonRepository PersonRepository
        {
            get { return ServiceLocator.Default.ResolveType<IPersonRepository>(); }
        }

        #endregion

        #region Methods

        public void Complete()
        {
            // TODO : [Prio2] [UnitOfWork] Eventuelles ErrorHandling an dieser Stelle? 
            DataAccess.Complete();
        }

        #endregion

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DataAccess is IDisposable disp)
                        disp.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
