﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Project.Core.Models;

namespace Company.Project.DataSourceDefinition.Common
{
    public interface IDataAccess : IDisposable
    {
        IEnumerable<T> GetAll<T>() where T : ModelBase2;

        IQueryable<T> Query<T>() where T : ModelBase2;

        T GetById<T>(int id) where T : ModelBase2;


        T Add<T>(T entity) where T : ModelBase2;
        T Delete<T>(T entity) where T : ModelBase2;
        T Update<T>(T entity) where T : ModelBase2;


        void Complete();
    }
}
