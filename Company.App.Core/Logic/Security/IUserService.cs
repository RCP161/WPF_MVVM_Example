using System;
using System.Collections.Generic;
using System.Text;
using Company.App.Core.Logic.App;
using Company.App.Core.Models.Basic;
using Company.App.Core.Models.Security;

namespace Company.App.Core.Logic.Security
{
    public interface IUserService : IModelBase2Service<User>, ISaveableService<User>
    {
        IEnumerable<User> GetByGroupId(int id);
    }
}
