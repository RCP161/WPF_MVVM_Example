using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Catel.Data;
using Company.Core.App.Data.DataBase.Interfaces;
using Company.Core.App.Models.Interfaces;
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
            //var entityMethod1 = typeof(DbModelBuilder).GetMethod("Entity");

            //List<Type> modelCollection = (from t in typeof(EfContext).Assembly.GetTypes() where Attribute.IsDefined(t, typeof(TableAttribute)) select t).ToList();

            // modelBuilder.Entity<Family>().IgnoreCatelProperties()

            //foreach(var item in modelCollection)
            //    entityMethod1.MakeGenericMethod(item).Invoke(modelBuilder, new object[] { });

            modelBuilder.Entity<Models.Customer>().IgnoreCatelProperties();
            modelBuilder.Entity<Models.Product>().IgnoreCatelProperties();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Product> Products { get; set; }

        public T Add<T>(T entity) where T : class, IEntity
        {
            return Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class, IEntity
        {
            Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : class, IEntity
        {
            return Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : class, IEntity
        {
            return Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> Query<T>() where T : class, IEntity
        {
            return Set<T>();
        }

        public void Complete()
        {
            // TODO : [Prio2] [Ef] Commit-Verhalten
            // Das SaveChanges wird automatisch eine Transaction gekapselt
            // Eine explizite Transaction müsste durchgreicht und noch eingerichtet werden
            SaveChanges();
        }
    }
}