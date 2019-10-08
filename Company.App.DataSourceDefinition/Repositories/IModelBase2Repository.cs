using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.DataSourceDefinition.Repositories
{
    public interface IModelBase2Repository<T> where T : ModelBase2
    {

        /// <summary>
        /// Liefert das Objekt des Typs anhand der Id in dem Repository
        /// </summary>
        /// <param name="id">Id des Objekts</param>
        /// <returns>Objekt mit der angegebenen Id, sonst null</returns>
        T GetById(int id);

        /// <summary>
        /// Liefert alle Objekte des Typs in dem Repository
        /// </summary>
        /// <returns>Auflistung von Objekten des Datentyps</returns>
        IEnumerable<T> GetAll();

        int GetCount();

        /// <summary>
        /// Speichert das Objekt in dem angegeben Zustand
        /// </summary>
        /// <param name="model">Objekt das gespeichert oder geupdated werden soll</param>
        void SaveOrUpdate(T model);
    }
}
