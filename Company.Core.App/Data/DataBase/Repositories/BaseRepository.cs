using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.App.Data.DataBase.Interfaces;
using Company.Core.App.Data.Interfaces;
using Company.Core.App.Models.Interfaces;

namespace Company.Core.App.Data.DataBase.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
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

        /// <summary>
        /// Fügt das frische Objekt dem Repository hinzu
        /// </summary>
        /// <param name="entity">Objekt das hinzugefügt werden soll</param>
        /// <returns>Objekt das hinzugefügt wurde mit Id</returns>
        public T Add(T entity)
        {
            return DataAccess.Add(entity);
        }

        /// <summary>
        /// Löscht das angegebene Objekt in dem Repository
        /// </summary>
        /// <param name="entity">Objekt das gelöscht werden soll</param>
        public void Delete(T entity)
        {
            DataAccess.Delete(entity);
        }

        /// <summary>
        /// Setzt die Änderungen des Objekts zurück
        /// </summary>
        /// <param name="entity">Objekt das zurück gesetzt werden soll</param>
        public void Revert(ref T entity)
        {
            entity = DataAccess.GetById<T>(entity.Id);
        }

        public T SaveOrUpdate(T entity)
        {
            // Mit States? Oder Ef States setzen?
            throw new NotImplementedException();
        }
    }
}
