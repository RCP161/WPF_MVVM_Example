﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Company.Project.Core.Common;
using Company.Project.Core.Models;
using Company.Project.DataSourceDefinition.Common;
using Company.Project.DataSourceDefinition.Repositories;

namespace Company.Project.DataSource.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : ModelBase2
    {
        public BaseRepository(IDataAccess dataAccess)
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
        /// Liefert das Objekt mit allen Verknüpfungen anhand der Id in dem Repository
        /// </summary>
        /// <param name="id">Id des Objekts</param>
        /// <returns>Objekt mit der angegebenen Id, sonst null</returns>
        public abstract T GetCompleteById(int id);

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

        public T SaveOrUpdate(T entity)
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

            // Sollte doch über die Usercontrol Geschichte laufen!
            // SaveRecursively(entity);

            return entity;
        }


        private void SaveRecursively(ModelBase2 entity)
        {
            if(entity == null)
                return;

            List<string> dependents = new List<string>();

            IEnumerable<System.Reflection.PropertyInfo> properties = entity.GetType()
                .GetProperties()
                .Where(p => typeof(IEnumerable<ModelBase2>).IsAssignableFrom(p.PropertyType) || typeof(ModelBase2).IsAssignableFrom(p.PropertyType));

            foreach(System.Reflection.PropertyInfo property in properties)
            {
                object value = property.GetValue(entity);
                if(value is IEnumerable<ModelBase2>)
                {
                    IEnumerable<ModelBase2> childs = value as IEnumerable<ModelBase2>;
                    if(childs == null)
                        continue;

                    foreach(ModelBase2 child in childs)
                        child.Save();
                }
                else if(value is ModelBase2)
                {
                    ModelBase2 child = value as ModelBase2;
                    if(child == null)
                        continue;

                    child.Save();
                }
            }
        }
    }
}