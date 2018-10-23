﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.IoC;
using Company.Core.App.Models;
using Company.Core.App.Data;
using Company.Core.App.Data.Interfaces;
using Company.Core.App.Services.Data.Interfaces;

namespace Company.Core.App.Services.Data
{
    public class PrdouctDataService : IProductDataService
    {
        public Product GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                Product product = unitOfWork.ProductRepository.GetById(id);
                product.AfterLoad();
                return product;
            }
        }

        public Product GetCompleteById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                Product product = unitOfWork.ProductRepository.GetById(id);
                product.AfterLoad();
                return product;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                IEnumerable<Product> products = unitOfWork.ProductRepository.GetAll();
                foreach(Product p in products)
                    p.AfterLoad();

                return products;
            }
        }

        public IEnumerable<Product> GetByCustomerId(int customerId)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ProductRepository.GetByCustomerId(customerId);
            }
        }

        public Product SaveOrUpdate(Product model)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                model = unitOfWork.ProductRepository.SaveOrUpdate(model);
                unitOfWork.Complete(); // AfterLoad?
            }

            return model;
        }
    }
}
