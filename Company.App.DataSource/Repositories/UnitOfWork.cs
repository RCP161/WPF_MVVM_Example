using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Project.DataSource.Repositories.Basic;
using Company.Project.DataSourceDefinition.Common;
using Company.Project.DataSourceDefinition.Repositories;
using Company.Project.DataSourceDefinition.Repositories.Basic;

namespace Company.Project.DataSource.Repositories
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


        private IPersonRepository personRepository;
        public IPersonRepository PersonRepository
        {
            get
            {

                if (personRepository == null)
                    personRepository = new PersonRepository(DataAccess);

                return personRepository;
            }
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
