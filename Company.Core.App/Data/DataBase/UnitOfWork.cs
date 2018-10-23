using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Data.DataBase.Interfaces;
using Company.Core.App.Data.DataBase.Repositories;
using Company.Core.App.Data.Interfaces;

namespace Company.Core.App.Data.DataBase
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


        private ICustomerRepository customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get
            {

                if (customerRepository == null)
                    customerRepository = new CustomerRepository(DataAccess);

                return customerRepository;
            }
        }


        private IProductRepository productRepository;
        public IProductRepository ProductRepository
        {
            get
            {

                if (productRepository == null)
                    productRepository = new ProductRepository(DataAccess);

                return productRepository;
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
