using Company.Data.Enities;
using Company.Data.If;
using Company.DataAccess.If;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataAccess.Ef
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
            var entityMethod1 = typeof(DbModelBuilder).GetMethod("Entity");

            List<Type> modelCollection = (from t in typeof(Customer).Assembly.GetTypes() where Attribute.IsDefined(t, typeof(TableAttribute)) select t).ToList();

            foreach (var item in modelCollection)
                entityMethod1.MakeGenericMethod(item).Invoke(modelBuilder, new object[] { });

            base.OnModelCreating(modelBuilder);
        }

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
