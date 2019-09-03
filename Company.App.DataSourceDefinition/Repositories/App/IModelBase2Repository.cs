using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Models;

namespace Company.App.DataSourceDefinition.Repositories.App
{
    public interface IModelBase2Repository
    {
        /// <summary>
        /// Speichert das Objekt in dem angegeben Zustand
        /// </summary>
        /// <param name="model">Objekt das gespeichert oder geupdated werden soll</param>
        void SaveOrUpdate<T>(T model) where T : ModelBase2;
    }
}
