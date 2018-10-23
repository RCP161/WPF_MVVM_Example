using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models.Interfaces;

namespace Company.Core.App.Data.DataBase.Interfaces
{
    public interface IDataAccess : IDisposable
    {
        IEnumerable<T> GetAll<T>() where T : class, IEntity;

        IQueryable<T> Query<T>() where T : class, IEntity;

        T GetById<T>(int id) where T : class, IEntity;


        T Add<T>(T entity) where T : class, IEntity;

        void Delete<T>(T entity) where T : class, IEntity;


        void Complete();
    }
}
