using Company.Data.If;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataQueries.If
{
    public interface IBaseRepository<T> where T : IEntity
    {
        /// <summary>
        /// Liefert das Objekt des Typs anhand der Id in dem Repository
        /// </summary>
        /// <param name="Id">Id des Objekts</param>
        /// <returns>Objekt mit der angegebenen Id, sonst null</returns>
        T GetById(int Id);

        /// <summary>
        /// Liefert alle Objekte des Typs in dem Repository
        /// </summary>
        /// <returns>Auflistung von Objekten des Datentyps</returns>
        List<T> GetAll();

        /// <summary>
        /// Fügt das frische Objekt dem Repository hinzu
        /// </summary>
        /// <param name="entity">Objekt das hinzugefügt werden soll</param>
        /// <returns>Objekt das hinzugefügt wurde mit Id</returns>
        T Add(T entity);

        /// <summary>
        /// Löscht das angegebene Objekt in dem Repository
        /// </summary>
        /// <param name="entity">Objekt das gelöscht werden soll</param>
        void Delete(T entity);

        /// <summary>
        /// Setzt die Änderungen des Objekts zurück
        /// </summary>
        /// <param name="entity">Objekt das zurück gesetzt werden soll</param>
        void Revert(ref T entity);
    }
}
