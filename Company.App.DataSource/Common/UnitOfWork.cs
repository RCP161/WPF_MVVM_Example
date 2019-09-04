using System;
using Catel.IoC;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.App;
using Company.App.DataSourceDefinition.Repositories.Basic;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Common
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



        private IModelBase2Repository modelBase2Repository;
        public IModelBase2Repository ModelBase2Repository
        {
            get
            {
                if(modelBase2Repository == null)
                    modelBase2Repository = new Repositories.App.ModelBase2Repository(DataAccess);

                return modelBase2Repository;
            }
        }


        private IPersonRepository personRepository;
        public IPersonRepository PersonRepository
        {
            get
            {
                if(personRepository == null)
                    personRepository = new Repositories.Basic.PersonRepository(DataAccess);

                return personRepository;
            }
        }


        private IGroupRepository groupRepository;
        public IGroupRepository GroupRepository
        {
            get
            {
                if(groupRepository == null)
                    groupRepository = new Repositories.Security.GroupRepository(DataAccess);

                return groupRepository;
            }
        }


        private IGroupPermissionRepository groupPermissionRepository;
        public IGroupPermissionRepository GroupPermissionRepository
        {
            get
            {
                if(groupPermissionRepository == null)
                    groupPermissionRepository = new Repositories.Security.GroupPermissionRepository(DataAccess);

                return groupPermissionRepository;
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
