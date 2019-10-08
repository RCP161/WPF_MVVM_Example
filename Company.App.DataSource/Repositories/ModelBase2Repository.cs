using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories;

namespace Company.App.DataSource.Repositories
{
    public abstract class ModelBase2Repository<T> : IModelBase2Repository<T> where T : ModelBase2 
    {
        internal ModelBase2Repository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        protected IDataAccess DataAccess { get; private set; }

        /// <summary>
        /// Liefert das Objekt anhand der Id in dem Repository
        /// </summary>
        /// <param name="id">Id des Objekts</param>
        /// <returns>Objekt mit der angegebenen Id, sonst null</returns>
        public T GetById(int id)
        {
            T t = DataAccess.GetById<T>(id);
            t.MarkAsUnchanged();
            return t;
        }

        /// <summary>
        /// Liefert alle Objekte des Typs in dem Repository
        /// </summary>
        /// <returns>Auflistung von Objekten des Datentyps</returns>
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> ts = DataAccess.GetAll<T>().ToList();

            foreach(T t in ts)
                t.MarkAsUnchanged();

            return ts;
        }


        public int GetCount()
        {
            return DataAccess.Query<T>().Count();
        }


        public void SaveOrUpdate(T entity)
        {
            switch(entity.State)
            {
                case StateEnum.Unchanged:
                    break;
                case StateEnum.Created:
                    DataAccess.Add(entity);
                    break;
                case StateEnum.Modified:
                    DataAccess.Update(entity);
                    break;
                case StateEnum.Deleted:
                    DataAccess.Delete(entity);
                    break;
                default:
                    break;
            }
        }
    }
}
