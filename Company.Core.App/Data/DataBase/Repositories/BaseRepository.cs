﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Data.DataBase.Interfaces;
using Company.Core.App.Data.Interfaces;
using Company.Core.App.Models;

namespace Company.Core.App.Data.DataBase.Repositories
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
            return DataAccess.GetById<T>(id);
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
            return DataAccess.GetAll<T>().ToList();
        }

        public T SaveOrUpdate(T entity)
        {
            switch(entity.State)
            {
                case Common.StateEnum.Unchanged:
                    break;
                case Common.StateEnum.Created:
                    DataAccess.Add(entity);
                    break;
                case Common.StateEnum.Modified:
                    DataAccess.Update(entity);
                    break;
                case Common.StateEnum.Deleted:
                    DataAccess.Delete(entity);
                    break;
                default:
                    break;
            }

            return entity;
        }
    }
}
