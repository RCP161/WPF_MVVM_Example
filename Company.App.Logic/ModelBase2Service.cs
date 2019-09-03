using System.Collections.Generic;
using Catel.IoC;
using Company.App.Core.Logic;
using Company.App.Core.Logic.App;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;

namespace Company.App.Logic
{
    public class ModelBase2Service<T> : IModelBase2Service<T> where T : ModelBase2
    {
        public IEnumerable<T> GetAll()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ModelBase2Repository.GetAll<T>();
            }
        }

        public T GetById(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ModelBase2Repository.GetById<T>(id);
            }
        }

        public int GetCount()
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.ModelBase2Repository.GetCount<T>();
            }
        }
    }
}
