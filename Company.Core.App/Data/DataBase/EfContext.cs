using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Catel.Data;
using Company.Core.App.Data.DataBase.Interfaces;
using Company.Core.App.Models;
using Orc.EntityFramework;

namespace Company.Core.App.Data.DataBase
{
    public class EfContext : DbContext, IDataAccess
    {
        /// <summary>
        /// Konstruktor zum erstellen des Kontext
        /// </summary>
        /// <param name="ConnectionString">Connection String</param>
        public EfContext(IDbConfigruation config) : base(config.ConnectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Reflection.MethodInfo entityMethod1 = typeof(DbModelBuilder).GetMethod("Entity");

            List<Type> modelCollection = (from t in typeof(EfContext).Assembly.GetTypes() where Attribute.IsDefined(t, typeof(TableAttribute)) select t).ToList();

            foreach(Type item in modelCollection)
                entityMethod1.MakeGenericMethod(item).Invoke(modelBuilder, new object[] { });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }


        public T Add<T>(T entity) where T : ModelBase2
        {
            entity = Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Added;
            return entity;
        }

        public T Delete<T>(T entity) where T : ModelBase2
        {
            entity = Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public T Update<T>(T entity) where T : ModelBase2
        {
            entity = Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<T> GetAll<T>() where T : ModelBase2
        {
            return Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : ModelBase2
        {
            return Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> Query<T>() where T : ModelBase2
        {
            return Set<T>();
        }

        public void Complete()
        {
            SaveChanges();
        }
    }
}