using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Catel.Data;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Company.App.DataSource.Common
{
    public class EfContext : DbContext
    {
        private IDbConfigruation config;


        public EfContext(IDbConfigruation config)
        {
            this.config = config;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            System.Reflection.MethodInfo entityMethod1 = typeof(ModelBuilder).GetMethod("Entity",new Type[0]);

            List<Type> modelCollection = (from t in typeof(ModelBase2).Assembly.GetTypes() where Attribute.IsDefined(t, typeof(TableAttribute)) select t).ToList();

            foreach(Type item in modelCollection)
                entityMethod1.MakeGenericMethod(item).Invoke(modelBuilder, new object[] { });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.ConnectionString);
        }

        public T GetById<T>(int id) where T : ModelBase2
        {
            return Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll<T>() where T : ModelBase2
        {
            return Set<T>().ToList();
        }

        public new IQueryable<T> Query<T>() where T : ModelBase2
        {
            return Set<T>();
        }

        public new void Add<T>(T entity) where T : ModelBase2
        {
            Entry(entity).State = EntityState.Added;
        }

        public void AddAllRelations<T>(T entity) where T : ModelBase2
        {
            base.Add(entity);
        }

        public void Delete<T>(T entity) where T : ModelBase2
        {
            base.Remove(entity);
        }

        public new void Update<T>(T entity) where T : ModelBase2
        {
            base.Update(entity);
        }

        public void Complete()
        {
            SaveChanges();
        }
    }
}