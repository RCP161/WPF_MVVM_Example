﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.App;

namespace Company.App.DataSource.Repositories.App
{
    public class ModelBase2Repository : IModelBase2Repository
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
        public T GetById<T>(int id) where T : ModelBase2
        {
            T t = DataAccess.GetById<T>(id);
            t.AfterLoad();
            return t;
        }

        /// <summary>
        /// Liefert alle Objekte des Typs in dem Repository
        /// </summary>
        /// <returns>Auflistung von Objekten des Datentyps</returns>
        public IEnumerable<T> GetAll<T>() where T : ModelBase2
        {
            IEnumerable<T> ts = DataAccess.GetAll<T>().ToList();

            foreach(T t in ts)
                t.AfterLoad();

            return ts;
        }


        public int GetCount<T>() where T : ModelBase2
        {
            return DataAccess.Query<T>().Count();
        }

        public void SaveOrUpdate<T>(T entity) where T : ModelBase2
        {
            throw new NotSupportedException("Soll so nicht funktionieren. Würde die Saves in viele kleine UoWs verteilen ...");


            if(entity == null || entity.State == StateEnum.Unchanged)
                return;

            SaveOrUpdateModel(entity);

            List<string> dependents = new List<string>();

            IEnumerable<System.Reflection.PropertyInfo> properties = entity.GetType()
                .GetProperties()
                .Where(p => typeof(IEnumerable<ModelBase2>).IsAssignableFrom(p.PropertyType) || typeof(ModelBase2).IsAssignableFrom(p.PropertyType));

            foreach(System.Reflection.PropertyInfo property in properties)
            {
                object value = property.GetValue(entity);

                if(value == null)
                    continue;
                
                if(value is IEnumerable<ModelBase2>)
                {
                    IEnumerable<ModelBase2> childs = value as IEnumerable<ModelBase2>;

                    foreach(ModelBase2 child in childs)
                        child.Save();
                }
                else if(value is ModelBase2)
                {
                    ModelBase2 child = value as ModelBase2;
                    SaveOrUpdate(child);
                }
            }
        }


        private void SaveOrUpdateModel<T>(T entity) where T : ModelBase2
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
