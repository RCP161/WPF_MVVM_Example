﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;
using Company.Core.App.Data.Interfaces;
using Company.Core.App.Data.DataBase.Interfaces;
using System.Data.Entity;

namespace Company.Core.App.Data.DataBase.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDataAccess dataAccess) : base(dataAccess)
        { }

        public override Product GetCompleteById(int id)
        {
            return DataAccess.Query<Product>().Include("Owner").Where(p => p.Id == id).FirstOrDefault(); 
        }

        public IEnumerable<Product> GetByCustomerId(int id)
        {
            return DataAccess.Query<Product>().Where(p => p.Owner != null && p.Owner.Id == id).ToList();
        }
    }
}
