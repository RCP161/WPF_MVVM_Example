using System.Collections.Generic;
using System.Linq;
using Catel.IoC;
using Company.App.Core.Common;
using Company.App.Core.Logic;
using Company.App.Core.Logic.App;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;

namespace Company.App.Logic
{
    public class ModelBase2Service<T> : IModelBase2Service<T>, ISaveableService<T> where T : ModelBase2<T>
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


        // Das als BaseService, von dem man ableiten kann???
        // Zusammen legen mit ModelBase2Service

        public void Save(T model, IDataAccess dataAccess)
        {
            throw new System.Exception("UnitOfWork Manager. Wenn null neu, sonst den.");

            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                unitOfWork.ModelBase2Repository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }
    }
}
