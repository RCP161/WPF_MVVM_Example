using Catel.IoC;
using Company.App.Core.Logic.App;
using Company.App.Core.Models;
using Company.App.DataSourceDefinition.Common;

namespace Company.App.Logic
{
    public class SaveableService : ISaveableService
    {
        public void Save<T>(T model) where T : ModelBase2
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                unitOfWork.ModelBase2Repository.SaveOrUpdate(model);
                unitOfWork.Complete();
            }
        }
    }
}
