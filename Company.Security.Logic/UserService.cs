using System;
using System.Collections.Generic;
using System.Text;
using Catel.IoC;
using Company.App.Core.Logic.Security;
using Company.App.Core.Models.Security;
using Company.App.DataSourceDefinition.Common;
using Company.App.Logic;

namespace Company.Security.Logic
{
    public class UserService : ModelBase2Service<User>, IUserService
    {
        public IEnumerable<User> GetByGroupId(int id)
        {
            using(IUnitOfWork unitOfWork = ServiceLocator.Default.ResolveType<IUnitOfWork>())
            {
                return unitOfWork.PersonRepository.GetByGroupId(id);
            }
        }
    }
}
