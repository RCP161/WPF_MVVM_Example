using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.Core.Common
{
    public interface IDataAccess : IDisposable
    {
        T GetById<T>(int id) where T : ModelBase2<T>;
        IEnumerable<T> GetAll<T>() where T : ModelBase2<T>;
        IQueryable<T> Query<T>() where T : ModelBase2<T>;

        void Add<T>(T entity) where T : ModelBase2<T>;
        void Delete<T>(T entity) where T : ModelBase2<T>;
        void Update<T>(T entity) where T : ModelBase2<T>;


        void Complete();
    }
}
