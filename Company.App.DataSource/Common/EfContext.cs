using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Catel.Data;
using Company.App.Core.Common;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;

namespace Company.App.DataSource.Common
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
            Database.SetInitializer<EfContext>(new DropCreateDatabaseAlways<EfContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext, EfConfiguration>());


            System.Reflection.MethodInfo entityMethod1 = typeof(DbModelBuilder).GetMethod("Entity");

            List<Type> modelCollection = (from t in typeof(ModelBase1).Assembly.GetTypes() where Attribute.IsDefined(t, typeof(TableAttribute)) select t).ToList();

            foreach(Type item in modelCollection)
                entityMethod1.MakeGenericMethod(item).Invoke(modelBuilder, new object[] { });

            base.OnModelCreating(modelBuilder);
        }

        public T GetById<T>(int id) where T : ModelBase2<T>
        {
            return Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll<T>() where T : ModelBase2<T>
        {
            return Set<T>().ToList();
        }

        public IQueryable<T> Query<T>() where T : ModelBase2<T>
        {
            return Set<T>();
        }

        public void Add<T>(T entity) where T : ModelBase2<T>
        {
            Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : ModelBase2<T>
        {
            Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : ModelBase2<T>
        {
            entity = Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Modified;
        }

        public void Complete()
        {
            SaveChanges();
        }
    }
}