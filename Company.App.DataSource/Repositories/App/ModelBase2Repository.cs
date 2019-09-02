using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.App.Core.Common;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;
using Company.App.DataSourceDefinition.Repositories.App;

namespace Company.App.DataSource.Repositories.App
{
    public class ModelBase2Repository : IModelBase2Repository
    {
        public ModelBase2Repository(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        protected IDataAccess DataAccess { get; private set; }


        public void SaveOrUpdate(ModelBase2 entity)
        {
            switch(entity.State)
            {
                case StateEnum.Unchanged:
                    break;
                case StateEnum.Created:
                    DataAccess.Add(entity);
                    break;
                case StateEnum.Modified:
                    DataAccess.Update(entity);
                    break;
                case StateEnum.Deleted:
                    DataAccess.Delete(entity);
                    break;
                default:
                    break;
            }
        }


        // Brauche ich das???
        private void SaveRecursively(ModelBase2 entity)
        {
            if(entity == null)
                return;

            List<string> dependents = new List<string>();

            IEnumerable<System.Reflection.PropertyInfo> properties = entity.GetType()
                .GetProperties()
                .Where(p => typeof(IEnumerable<ModelBase2>).IsAssignableFrom(p.PropertyType) || typeof(ModelBase2).IsAssignableFrom(p.PropertyType));

            foreach(System.Reflection.PropertyInfo property in properties)
            {
                object value = property.GetValue(entity);
                if(value is IEnumerable<ModelBase2>)
                {
                    IEnumerable<ModelBase2> childs = value as IEnumerable<ModelBase2>;
                    if(childs == null)
                        continue;

                    foreach(ModelBase2 child in childs)
                        child.SaveModel();
                }
                else if(value is ModelBase2)
                {
                    ModelBase2 child = value as ModelBase2;
                    if(child == null)
                        continue;

                    child.SaveModel();
                }
            }
        }
    }
}
