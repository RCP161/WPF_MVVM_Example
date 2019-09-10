using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.DataSourceDefinition.Common
{
    public interface IDataAccess : IDisposable
    {
        T GetById<T>(int id) where T : ModelBase2;
        IEnumerable<T> GetAll<T>() where T : ModelBase2;
        IQueryable<T> Query<T>() where T : ModelBase2;

        void Add<T>(T entity) where T : ModelBase2;
        void Delete<T>(T entity) where T : ModelBase2;
        void Update<T>(T entity) where T : ModelBase2;


        void Complete();
    }
}
