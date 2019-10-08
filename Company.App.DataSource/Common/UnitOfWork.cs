using System;
using Catel.IoC;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.Basic;
using Company.App.DataSourceDefinition.Repositories.Security;

namespace Company.App.DataSource.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constructor

        internal UnitOfWork(IDataAccess dataAccess)
        {
            Counter = 0;
            DataAccess = dataAccess;
        }

        #endregion

        #region Properties

        private IDataAccess DataAccess { get; set; }

        internal int Counter { get; set; }


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


        private IUserRepository userRepository;     
        public IUserRepository UserRepository
        {
            get
            {
                if(userRepository == null)
                    userRepository = new Repositories.Security.UserRepository(DataAccess);

                return userRepository;
            }
        }


        private IPermissionRepository permissionRepository;
        public IPermissionRepository PermissionRepository
        {
            get
            {
                if(permissionRepository == null)
                    permissionRepository = new Repositories.Security.PermissionRepository(DataAccess);

                return permissionRepository;
            }
        }

        #endregion

        #region Methods

        public bool Complete()
        {
            bool res = true;

            try
            {
                // TODO : [Prio2] [UnitOfWork] Eventuelles ErrorHandling an dieser Stelle? 
                DataAccess.Complete();
            }
            catch(Exception)
            {
                // Log;
                res = false;
            }

            return res;
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
            if(Counter > 0)
            {
                Counter--;
                return;
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
