using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.App.Core.Models;

namespace Company.App.DataSourceDefinition.Repositories
{
    public interface IBaseRepository<T> where T : ModelBase2
    {
        /// <summary>
        /// Liefert das Objekt des Typs anhand der Id in dem Repository
        /// </summary>
        /// <param name="id">Id des Objekts</param>
        /// <returns>Objekt mit der angegebenen Id, sonst null</returns>
        T GetById(int id);

        /// <summary>
        /// Liefert das Objekt des Typs mit all seinen Verknüpfungen anhand der Id in dem Repository
        /// </summary>
        /// <param name="id">Id des Objekts</param>
        /// <returns>Objekt mit der angegebenen Id, sonst null</returns>
        T GetCompleteById(int id);

        /// <summary>
        /// Liefert alle Objekte des Typs in dem Repository
        /// </summary>
        /// <returns>Auflistung von Objekten des Datentyps</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Speichert das Objekt in dem angegeben Zustand
        /// </summary>
        /// <param name="model">Objekt das gespeichert oder geupdated werden soll</param>
        /// <returns>Upgedates oder gespeichertes Objekt. Bei gelöschtem Objekt null</returns>
        T SaveOrUpdate(T model);
    }
}
