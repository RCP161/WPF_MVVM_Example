using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Models;

namespace Company.Core.App.Data.DataBase.Interfaces
{
    public interface IDataAccess : IDisposable
    {
        IEnumerable<T> GetAll<T>() where T : ModelBase2;

        IQueryable<T> Query<T>() where T : ModelBase2;

        T GetById<T>(int id) where T : ModelBase2;


        T Add<T>(T entity) where T : ModelBase2;
        T Delete<T>(T entity) where T : ModelBase2;
        T Update<T>(T entity) where T : ModelBase2;


        void Complete();
    }
}
