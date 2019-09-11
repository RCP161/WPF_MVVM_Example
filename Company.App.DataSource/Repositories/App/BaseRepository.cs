using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.App;

namespace Company.App.DataSource.Repositories.App
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : ModelBase2<T>
    {
        internal BaseRepository(IDataAccess dataAccess)
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
            t.AfterLoad();
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
                t.AfterLoad();

            return ts;
        }


        public int GetCount()
        {
            return DataAccess.Query<T>().Count();
        }

        public void SaveOrUpdate(T entity)
        {
            throw new Exception("Kann nicht funktionieren. Springt immer zwischen den Mappin Properties hin und her ...");


            if(entity == null || entity.State == StateEnum.Unchanged)
                return;

            SaveOrUpdateModel(entity);

            IEnumerable<System.Reflection.PropertyInfo> properties = entity.GetType()
                .GetProperties()
                .Where(p => typeof(IEnumerable<IEditable>).IsAssignableFrom(p.PropertyType) || typeof(IEditable).IsAssignableFrom(p.PropertyType));

            foreach(System.Reflection.PropertyInfo property in properties)
            {
                object value = property.GetValue(entity);

                if(value == null)
                    continue;
                
                if(value is IEnumerable<IEditable>)
                {
                    IEnumerable<IEditable> childs = value as IEnumerable<IEditable>;

                    foreach(IEditable child in childs)
                        child.Save(DataAccess);
                }
                else if(value is IEditable)
                {
                    IEditable child = value as IEditable;
                    child.Save(DataAccess);
                }
            }
        }


        private void SaveOrUpdateModel(T entity)
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
